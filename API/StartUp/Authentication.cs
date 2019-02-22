using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Cryptography;

namespace Api.StartUp
{
    /// <summary>
    /// Api Authentication
    /// </summary>
    public static class Authentication
    {
        /// <summary>
        /// Auth Name
        /// </summary>
        public static string Name { get { return "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"; } } //ClaimTypes.NameIdentifier
        /// <summary>
        /// Auth User
        /// </summary>
        public static string UserId { get { return "sid"; } } //ClaimTypes.Sid

        #region RSA
        private static RSAParameters GetRSAParameters(IConfiguration configuration)
        {
            var _rsa = new RSACryptoServiceProvider();
            _rsa.ImportParameters(new RSAParameters()
            {
                Modulus = FromBase64Url(configuration["RSA:Modulus"]),
                Exponent = FromBase64Url(configuration["RSA:Exponent"])
            });

            return _rsa.ExportParameters(false);
        }

        private static byte[] FromBase64Url(string base64Url)
        {
            string padded = base64Url.Length % 4 == 0
                ? base64Url : base64Url + "====".Substring(base64Url.Length % 4);
            string base64 = padded.Replace("_", "/")
                                  .Replace("-", "+");
            return Convert.FromBase64String(base64);
        }
        #endregion

        /// <summary>
        /// Authentication Register
        /// </summary>
        /// <param name="services">Services Collection</param>
        /// <param name="configuration">Api Configuration</param>
        /// <param name="env">Api Environment</param>
        public static void Register(IServiceCollection services, IConfiguration configuration, IHostingEnvironment env = null)
        {
            var isDebug = env != null && env.IsDevelopment();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(x =>
            {
                //x.RequireHttpsMetadata = false;
                //x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = Name,
                    //RoleClaimType = Role,

                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new RsaSecurityKey(GetRSAParameters(configuration)),
                    ValidateLifetime = !isDebug
                };
            });
        }
    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Api.StartUp
{
    /// <summary>
    /// Api Authorization
    /// </summary>
    public static class Authorization
    {
        /// <summary>
        /// Authorization Policy
        /// </summary>
        public const string Policy = "JwtPolicy";

        /// <summary>
        /// JWT allowed Types
        /// </summary>
        private static string[] JwtTypes { get { return new List<string>() { "A" }.ToArray(); } }

        private static bool s_claimValidate = true;
        private static bool ClaimValidate { get => s_claimValidate; set => s_claimValidate = s_claimValidate && value; }

        /// <summary>
        /// Authorization Register
        /// </summary>
        /// <param name="services">Api Services</param>
        public static void Register(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policy, policy =>
                {
                    policy.RequireClaim("typ", JwtTypes);
                    policy.RequireAssertion(context =>
                    {
                        if (context.User.FindFirst(Authentication.UserId) is null || context.User.FindFirst(Authentication.Name) is null)
                            return false;

                        ClaimValidate = int.TryParse(context.User.FindFirst(Authentication.UserId).Value, out var result1);
                        var nameIdentifier = context.User.FindFirst(Authentication.Name).Value;
                        ClaimValidate = nameIdentifier.Contains("@")
                            && !string.IsNullOrWhiteSpace(nameIdentifier.Split('@')[0]) && int.TryParse(nameIdentifier.Split('@')[1], out var result2);

                        return ClaimValidate;
                    });
                });
            });
        }
    }
}

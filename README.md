# Library
Book Store

> DataBase:

Script to create DataBase and objects (tables and procedures) are (under Repository Project)

AppSettings has the strings to connect to the DataBase (under Api Project)

> Environment

https://dotnet.microsoft.com/download/dotnet-core/2.1 (dotnet core 2.1.*)

https://www.microsoft.com/en-us/download/details.aspx?id=48264 (IIS Express)

*(commands should be run over command prompt)*
> Build:

dotnet restore api/api.csproj

dotnet build api/api.csproj

> Run:

dotnet run --project api/api.csproj (It runs over IIS Express and dotnet core 2.1.8)

> Test:

dotnet test unittest/unittest.csproj (For test purpouses)

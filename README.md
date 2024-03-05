
  

# Web API Template
.NET Core Web API Solution with

 - Dependency Injection (see Lamar configuration)

 - Entity Framework with basic unit of work

 - Automapper

 - SMTP mail sender library

 - Language resource library

 - Stylecop, code rules

 - Swagger
&nbsp;

Start the web api in the Web project with dotnet run.  

## How to use EF

[Entity Framework commands](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

Example command in Lib.Database project:

    dotnet ef migrations add "Initial Migration" -s ../Web

  

## How to use a codegen for frontend ts projects

Installation:

    yarn add openapi-typescript openapi-typescript-codegen --dev

Use script in package.json:

    "generate": "openapi -i http://localhost:5291/swagger/v1/swagger.json -o openapi"

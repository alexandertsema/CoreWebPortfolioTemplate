# PortfolioTemplate

## Overview

This projects implements my personal website with portfolio

### Architecture

The web application is devided into 6 projects:

1. AlexanderTsema.Storage.Abstractions
2. AlexanderTsema.Storage.Concretes
3. AlexanderTsema.Storage.Entities
4. AlexanderTsema.WebServices
5. AlexanderTsema.UI.Client
6. AlexanderTsema.UI.Admin

### Motivation

Why .Net Core? Microsoft wants .Net community to move forward, and I, beeing a great fan of the Microsoft will always support that direction.

## Tech stack

* .Net Core 1.1 (C#)
* .Net Standart 1.6 (C#)
* AngularJS 2 (proposed)

### Tools

* Visual Studio 2017 RC

## Issues

* ...

## Future work

* Working on web services
* Incrementing framework versions

## Notes

* Migrations in Package Manager Console work with .Net Standart Class Library
* This project should have following dependencies:
	<PackageReference Include="Microsoft.EntityFrameworkCore" Version="1.1.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="1.1.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="1.1.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="1.1.0-preview4-final" />
* The start up project (output exe) should have:
	<PackageReference Include="Microsoft.NETCore.App" Version="1.1.0" />
	In properties the .NetCore should be 1.1

* No individual user accounts
* No lazy load in EF
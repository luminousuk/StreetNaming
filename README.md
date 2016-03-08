# StreetNaming

Project to manage street naming and numbering requests.

## What is it?

This project serves as a replacement for the manual property naming/numbering request process for the B&NES Council GIS Team. Digitising and publishing the paper forms on the web streamlines their accessibility and provisions the use of online payments through the Civica gateway.

## Technologies used

Project built entirely in **ASP.NET Core 1.0** using **ASP.NET MVC 6** and **Entity Framework 7** with the **npgsql** connector.

## Build

Visual Studio 2015 is required to build the project, and is available [here](https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx).

## Deployment

### Database

The persistence layer has been written *code-first* using *EF Migrations* and targets a PostgreSQL database. The database can be publishing using the following command (whilst in the `StreetNaming.Web` directory):
```
.\dnx ef database update
```

### Web

The web application containing the forms can be hosted using IIS (minimum of .NET 4.5.1 must be installed) using the Visual Studio publish wizard, or can be self-hosted using the following command (whilst in the `StreetNaming.Web` directory):
```
dnx web
```

## Usage

TODO: Write usage instructions

## Third party licensing

TODO: List any relevant licences.  

## Licence

Original code licensed with MIT Licence

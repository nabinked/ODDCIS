# ODDCIS
Ontology Driven Information System (ISIT990 Final Year Project 2017)

# Get Started

## Requirement
* [dotnet core 2.0](https://download.microsoft.com/download/7/3/A/73A3E4DC-F019-47D1-9951-0453676E059B/dotnet-sdk-2.0.2-win-x64.exe)

 To check if dotnet core 2.0 is installed. Open command prompt and run `dotnet --version`. If it gives a version then dotnet is installed.
* [node](https://nodejs.org/dist/v6.11.5/node-v6.11.5-x64.msi)

To check if node is installed. Open command prompt and run `node --version`. If it gives a version then node is installed.
 
 ## How to run locally
 ### Without Visual Studio
 * Make sure above requirements are met
 * Git clone this repository or download project
 * Go to the /src/ODDCIS.Web/ folder inside this repository
 * Open the command line in that folder and do a `npm install` followed by`dotnet build` and then `dotnet run`
 * Go to localhost:[port] in your browser. Check the command line for [port] number after running `dotnet run`. 
 
 ### With Visual Studio 2017 or above
 * Git clone this repository or download project
 * Go to the /src/ODDCIS.Web/ folder inside this repository.
 * Open the command line in that folder and do a `npm install`.
 * In the root folder, find the solution file ODDCIS.sln. Open it with visual studio 2017
 * Ctrl + F5 to run the solution. A browser will open up the application. 
 
Continously Deployed to http://isit990.azurewebsites.net/

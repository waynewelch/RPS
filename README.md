# RPS
RpsPolicyApp and the associated UnitTests projects were developed using .Net Core 2.0 and Angular 4

Before attempting to install and run, please read this entire document and ensure you have all of the required items.

## Dependencies

#### Node.js with NPM is required to run a .Net Core Angular 4 application. 

Verify Node.js is installed:
open a command prompt and type
`node --version`

If the node command goes unrecognized, you need to install Node.js.
  - Visit the [Node.js download page](https://nodejs.org/en/download/) and choose either the Windows or Mac installer based on your OS.
  - Accept the agreement, choose an installation folder, and hit Next on the Custom Setup page. By default, it will install the npm package manager which we will need.
  
 
Verify NPM is installed via
`npm --version`

If the version is returned, these are the minimum recommended versions:
  - node.js >= 6.9.x
  - npm >= 3.x.x 

Prerequisites for running a Core application can be found [here](https://docs.microsoft.com/en-us/dotnet/core/windows-prerequisites?tabs=netcore2x). 

## Install and setup:
- Clone project from **Develop** branch to local directory
- Open .sln file with **_Visual Studio 2017 version 15.3 (26730.01) or higher_**
- Open Visual Studio *Package Manager Console* and run `Update-Database`
- Build
- Run
- Bask in the glory that is my mediocre excellence!

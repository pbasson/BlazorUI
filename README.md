# Blazor UI By Preetpal Basson 

-----------
## Overview

Blazor Framework demonstration implementing components with clean, scalable code.

-----------
## Features

Features such as 

| Technology | Version |
|---|---|
| ASP.NET | 8.0 |
| Blazor Serverside | - |
| Radzen | - |


| Languages |
|---|
| C# |
| CSS |
| HTML |

-----------
## Usage

Project can be executed in any of the following Methods. Prefered way would via Dockerfile or Docker Compose. 

### Dotnet CLI

1. From Project Directory, Execute Dotnet Run (below)
    1. ``` dotnet run --project Blazor.UI/Blazor.UI.csproj ```

### Dockerfile

1. From Project Directory, Execute Dockerfile 
    1. Build Image:
        - ```docker build -t Blazor.UI:latest -f Blazor.UI/Dockerfile . ```
    2. Run Container:
        - ``` docker run --rm -it -p 5147:5147 Blazor.UI:latest ```

### Dockerfile

1. From Project Directory, Execute Docker Compose 
    1. Execute Docker Compose with Build 
        - ``` docker compose up --build ```

------------------------
# END

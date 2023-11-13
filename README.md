# How to build and launch the API

## With dotnet build
  - In a command prompt navigate to this r
  - Execute `dotnet publish -c Release -o published"` via command prompt in this directory to build the API
  - Execute `dotnet published/Web.dll --urls="http://localhost:8888""` to run the API
  - API will be available at `http://localhost:8888/`
  - The endpoint is available at POST `Production/productionplan`

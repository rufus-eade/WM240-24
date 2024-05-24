FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src

COPY ./*.sln ./
COPY ./details/Shared/details.Shared.csproj ./Shared/
COPY ./details/Client/details.Client.csproj ./Client/
COPY ./details/Server/details.Server.csproj ./Server/

RUN dotnet restore ./Server/details.Server.csproj

COPY ./details/Shared/. ./Shared/
COPY ./details/Client/. ./Client/
COPY ./details//Server/. ./Server/

RUN dotnet publish ./Server/details.Server.csproj -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "details.Server.dll"]
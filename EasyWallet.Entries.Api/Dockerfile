#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["EasyWallet.Entries.Api/EasyWallet.Entries.Api.csproj", "EasyWallet.Entries.Api/"]
RUN dotnet restore "EasyWallet.Entries.Api/EasyWallet.Entries.Api.csproj"
COPY . .
WORKDIR "/src/EasyWallet.Entries.Api"
RUN dotnet build "EasyWallet.Entries.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyWallet.Entries.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyWallet.Entries.Api.dll"]
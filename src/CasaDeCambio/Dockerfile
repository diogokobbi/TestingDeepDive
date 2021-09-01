FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ConversorDeMoedas/ConversorDeMoedas.csproj", "ConversorDeMoedas/"]
RUN dotnet restore "ConversorDeMoedas/ConversorDeMoedas.csproj"
COPY . .
WORKDIR "/src/ConversorDeMoedas"
RUN dotnet build "ConversorDeMoedas.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConversorDeMoedas.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConversorDeMoedas.dll"]

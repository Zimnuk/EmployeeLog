FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EmployeeLog.Api/EmployeeLog.Api.csproj", "EmployeeLog.Api/"]
RUN dotnet restore "EmployeeLog.Api/EmployeeLog.Api.csproj"
COPY . .
WORKDIR "/src/EmployeeLog.Api"
RUN dotnet build "EmployeeLog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeeLog.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeLog.Api.dll"]

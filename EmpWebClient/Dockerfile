FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 8998

ENV ASPNETCORE_URLS=http://+:8998


FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["EmpWebClient.csproj", "."]
RUN dotnet restore "EmpWebClient.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "EmpWebClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmpWebClient.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmpWebClient.dll"]

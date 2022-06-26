FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as base
WORKDIR /app
USER root

ENV TZ 'Asia/Tehran'
Run echo $TZ > /etc/timezone && \
         apt-get update && apt-get install -y tzdata && \
         rm /etc/localtime && \
         ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && \
         dpkg-reconfigure -f noninteractive tzdata && \
         apt-get clean 
         
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Margs.Api.csproj","."]
RUN dotnet restore "./Margs.Api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Margs.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Margs.Api.csproj" -c Release 0o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Margs.Api.dll"]


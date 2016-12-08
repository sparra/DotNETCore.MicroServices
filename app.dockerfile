FROM microsoft/dotnet:latest

MAINTAINER Salvador Parra

WORKDIR /var/www/
COPY ./src/MicroServices.DotNETCore.Domain.CORE ./MicroServices.DotNETCore.Domain.CORE
COPY ./global.docker.json ./global.json

WORKDIR /var/www/MicroServices.DotNETCore.Domain.CORE
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]


WORKDIR /var/www/aspnetcoreapp
COPY ./src/MicroServices.DotNETCore.Web.MVC .

################## BEGIN INSTALLATION ######################

WORKDIR /var/www/

RUN ["dotnet", "restore", "./aspnetcoreapp"]

RUN ["dotnet", "build", "./aspnetcoreapp"]

# RUN ["dotnet", "ef", "database", "update"]

##################### INSTALLATION END #####################

# Expose the default port
EXPOSE 80/tcp

WORKDIR /var/www/aspnetcoreapp

ENTRYPOINT ["dotnet", "run"]

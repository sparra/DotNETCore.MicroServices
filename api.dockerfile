FROM microsoft/dotnet:latest

MAINTAINER Salvador Parra

WORKDIR /var/www/
COPY ./src/MicroServices.DotNETCore.Domain.CORE ./MicroServices.DotNETCore.Domain.CORE
COPY ./global.docker.json ./global.json

WORKDIR /var/www/MicroServices.DotNETCore.Domain.CORE
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]


WORKDIR /var/www/aspnetcoreapi
COPY ./src/MicroServices.DotNETCore.Web.API .

################## BEGIN INSTALLATION ######################

WORKDIR /var/www/

RUN ["dotnet", "restore", "./aspnetcoreapi"]

RUN ["dotnet", "build", "./aspnetcoreapi"]

# RUN ["dotnet", "ef", "database", "update"]

##################### INSTALLATION END #####################

# Expose the default port
EXPOSE 9000/tcp

WORKDIR /var/www/aspnetcoreapi

ENTRYPOINT ["dotnet", "run"]

#!/bin/bash
echo "Getting docker images from registry"
echo
sudo docker pull microsoft/mssql-server-linux
sudo docker pull microsoft/dotnet
echo "Getting SQL Server Tools"
echo
sudo curl https://packages.microsoft.com/keys/microsoft.asc | sudo apt-key add -
sudo curl https://packages.microsoft.com/config/ubuntu/16.04/prod.list | sudo tee /etc/apt/sources.list.d/msprod.list
sudo apt-get update 
sudo apt-get install mssql-tools

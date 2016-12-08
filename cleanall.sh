#!/bin/bash

# Stop containers
sudo docker stop aspnetcoreapp
sudo docker stop aspnetcoreapi
sudo docker stop sqlserverlinux

# Remove containers
sudo docker rm aspnetcoreapp
sudo docker rm aspnetcoreapi
sudo docker rm sqlserverlinux

# Remove images (just the web projects)
sudo docker rmi aspnetcoreapp
sudo docker rmi aspnetcoreapi

# Show it's clean
sudo docker ps -a
sudo docker images

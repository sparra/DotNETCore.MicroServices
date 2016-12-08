# Microservicios de .NET Core en Docker Containers de Azure

Demostración del stack de DotNETCore para crear microservicios simples con Docker para el Microsoft TechTour México, utilizando Microsoft SQL Server Linux y una Arquitectura Opinada en Capas con Núcleo de Dominio simple. 

El microservicio API puede verse como un Bounded Context de Domain Driven Design y la aplicación Web de ASP.NET Core MVC usa inversión de control para demostrar los principios de diseño mencionados en la presentación.

Puede consultarse los slides de la presentación en:
https://speakerdeck.com/sparra/microservicios-de-net-core-en-docker-containers-de-azure

##Para ejecutar los contenedores y desplegar los servicios:

###Ejecutar los microservicios y el servidor de base de datos con Docker Compose

1. Traer las imagenes del registro de Docker y preparar el ambiente de conexión a la base de datos

    `./prepare.sh`

2. Componer los contenedores y compilar los microservicios de ASP.NET Core MVC y ASP.NET Core Web API

    `docker-compose`

3. Levantar los contenedores y publicar los microservicios

    `docker-up`

4. Abrir a http://localhost en el navegador web para visualizar la aplicación de ASP.NET MVC

5. Abrir a http://localhost:9000/swagger/ui en el navegador web para consultar el microservicio API REST con la interfaz swagger.

###Eliminar los contenedores y las imágenes para reiniciar el ambiente de ejecución

1. Ejecute el script de limpieza (elimina todos contenedores e imágenes de Docker)

    `./cleanall`

[Salvador Parra](https://twitter.com/salvadorparra "¡Mándame saluditos!")

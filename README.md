# Exploring RabbitMQ
RabbitMQ is a messaging queue system that we will be exploring here. For mor info [RabitMQ](https://www.rabbitmq.com/)

## Getting started

To run any of the RabbitMQ examples on dot net core you need 2 things:
- RabbitMQ.Client (nuget package for your visual studio)
- RabbitMQ docker image installed

In my particular case I'm using docker desktop so, just running the docker run command that they recommend on the [installation docs](https://www.rabbitmq.com/download.html) it should go it

docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.9-management
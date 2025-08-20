# RabbitMQ Producer and Multiple Consumers with Docker in C#

This project demonstrates a simple example of using RabbitMQ in C# with Docker. It includes:

- Starting and managing RabbitMQ Docker container programmatically.
- A Producer that sends messages asynchronously to a RabbitMQ exchange.
- Two asynchronous Consumers that receive and process messages from the RabbitMQ queue concurrently.
- Usage of `AsyncEventingBasicConsumer` for asynchronous message handling.
- Thread-based parallel execution of Producer and Consumers.

## ✨ Features

- Starts RabbitMQ container automatically using Docker CLI.
- Uses `AsyncEventingBasicConsumer` for async message handling.
- Demonstrates parallel processing using C# `Thread` and `async/await`.
- Clear structure with `Producer`, `Receiver`, `Receiver1`, and `DockerRun` components.

## 📦 Dependencies

These NuGet packages are required:

- [`RabbitMQ.Client`](https://www.nuget.org/packages/RabbitMQ.Client)
- [`Newtonsoft.Json`](https://www.nuget.org/packages/Newtonsoft.Json)

You can install them using the following commands:

```bash
dotnet add package RabbitMQ.Client
dotnet add package Newtonsoft.Json


## Prerequisites

- Docker Desktop installed and running.
- .NET SDK installed.
- RabbitMQ Docker image pulled automatically by the program.

## How to Run

1. Run the program to start Docker (if not running) and launch RabbitMQ container.
2. Producer publishes 100 messages asynchronously.
3. Two consumers listen and process messages concurrently.
4. Console output shows message flow.

---

Feel free to contribute or report issues!

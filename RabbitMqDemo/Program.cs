using RabbitMqDemo;
DockerRun.Main();

Thread producerThread = new Thread(() =>
{
    Task.Run(async () => await Producer.Main()).Wait();
});

Thread receiverThread = new Thread(() =>
{
    Task.Run(async () => await Receiver.Main()).Wait();
}); 
Thread receiver1Thread = new Thread(() =>
{
    Task.Run(async () => await Receiver1.Main()).Wait();
});

producerThread.Start();
receiverThread.Start();
receiver1Thread.Start();

producerThread.Join();
receiverThread.Join();
receiver1Thread.Join();

Console.WriteLine("Producer and Receiver have finished.");
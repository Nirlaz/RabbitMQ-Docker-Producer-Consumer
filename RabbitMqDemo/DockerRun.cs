using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqDemo
{
    public static class DockerRun
    {
        public static string Main()
        {
            Console.WriteLine("Checking if Docker is running...");
            if (!IsDockerRunning())
            {
                Console.WriteLine("Docker is not running. Starting Docker Desktop...");
                StartDockerDesktop();

                // Wait for Docker to start (adjust time if needed)
                Console.WriteLine("Waiting for Docker to initialize...");
                int waitSeconds = 30;
                for (int i = 0; i < waitSeconds; i++)
                {
                    if (IsDockerRunning())
                    {
                        Console.WriteLine("Docker started successfully.");
                        break;
                    }
                    Thread.Sleep(1000);
                }

                if (!IsDockerRunning())
                {
                    Console.WriteLine("Docker did not start within the timeout period. Exiting.");
                    return "ok";
                }
            }
            else
            {
                Console.WriteLine("Docker is already running.");
             
            }

            Console.WriteLine("Starting RabbitMQ container...");
            RunRabbitMqContainer();

            Console.WriteLine("All done!");
            return "ok";
        }

        static bool IsDockerRunning()
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "docker",
                    Arguments = "info",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(startInfo))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    return process.ExitCode == 0;
                }
            }
            catch
            {
                return false;
            }
        }

        static void StartDockerDesktop()
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = @"C:\Program Files\Docker\Docker\Docker Desktop.exe",
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to start Docker Desktop: " + ex.Message);
            }
        }

        static void RunRabbitMqContainer()
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "docker",
                    Arguments = "run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(startInfo))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (process.ExitCode == 0)
                    {
                        Console.WriteLine("RabbitMQ container started successfully.");
                        Console.WriteLine("Container ID: " + output.Trim());
                    }
                    else
                    {
                        Console.WriteLine("Failed to start RabbitMQ container.");
                        Console.WriteLine("Error: " + error);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error running RabbitMQ container: " + ex.Message);
            }
        }
    }
}
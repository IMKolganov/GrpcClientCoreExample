﻿// See https://aka.ms/new-console-template for more information
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
// using Grpc.Net.Client.Web;
using GrpcServiceClientCoreExample;

Console.WriteLine("Start!");

try
{
    Console.WriteLine($"Create chanell");
// создаем канал для обмена сообщениями с сервером
// параметр - адрес сервера gRPC
    using var channel = GrpcChannel.ForAddress("http://localhost:5063");
// создаем клиент
    var client = new Greeter.GreeterClient(channel);
    Console.Write("Enter name: ");
    var name = Console.ReadLine();
// обмениваемся сообщениями с сервером
    var reply = await client.SayHelloAsync(new HelloRequest { Name = name });
    Console.WriteLine($"Response server: {reply.Message}");
    Console.ReadKey();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.ReadKey();
}
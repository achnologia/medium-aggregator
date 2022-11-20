// See https://aka.ms/new-console-template for more information

using ArticlesAggregator.Aggregator.Client.Medium.IoC;
using ArticlesAggregator.Aggregator.Contracts;
using MediumAggregator.Aggregator.IoC;
using MediumAggregator.DataAccess.IoC;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Scanning..");

var c = new ServiceCollection();

c.RegisterAggregatorWorker();

var p = c.BuildServiceProvider();

var service = p.GetRequiredService<IAggregatorService>();

await service.ScanAndSaveAsync();

Console.WriteLine("Done.");
Console.WriteLine("Check DataBase.txt file for the articles.");
Console.ReadLine();
using Microsoft.Extensions.Configuration;
using OnellectTest;

var res = NumbersGenerator.GetRandomNumbers();

foreach (var item in res)
    Console.Write(item + " ");

Console.WriteLine();

var sortedRes = NumbersGenerator.Sort(res);

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

if (sortedRes is not null)
{
    foreach (var item in sortedRes)
        Console.Write(item + " ");

    if (config.GetSection("Url").Value is not null)
        WebHandler.Post(config.GetSection("Url").Value, sortedRes);
}
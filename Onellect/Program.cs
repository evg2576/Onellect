using OnellectTest;

var res = NumbersGenerator.GetRandomNumbers();

foreach (var item in res)
    Console.Write(item + " ");

Console.WriteLine();

var sortedRes = NumbersGenerator.Sort(res);

if (sortedRes is not null)
    foreach (var item in sortedRes)
        Console.Write(item + " ");
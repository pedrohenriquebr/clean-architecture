using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

[MinColumn, MaxColumn, BaselineColumn]
public class ArrayVsList
{
    readonly int[] numbers = Enumerable.Range(0, 100).ToArray();
    readonly List<int> numbersList = new List<int>(100);


    [Benchmark(Baseline = true)]
    public int GetNumberFromArray()
    {
        return numbers[numbers.Count() - 10];
    }

    [Benchmark]
    public int GetNumberFromList()
    {
        return numbersList[numbersList.Count() - 10];
    }
}


public class Program
{
    public static void Main(string [] args)
    {
        BenchmarkRunner.Run<ArrayVsList>();
    }
}
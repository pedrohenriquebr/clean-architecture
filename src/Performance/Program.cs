using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Performance;

[MinColumn, MaxColumn, BaselineColumn]
public class ArrayVsList
{
    private readonly int[] _numbers = Enumerable.Range(0, 100).ToArray();
    private readonly List<int> _numbersList = new(100);


    [Benchmark(Baseline = true)]
    public int GetNumberFromArray()
    {
        return _numbers[_numbers.Count() - 10];
    }

    [Benchmark]
    public int GetNumberFromList()
    {
        return _numbersList[_numbersList.Count() - 10];
    }
}


public class Program
{
    public static void Main(string [] args)
    {
        BenchmarkRunner.Run<ArrayVsList>();
    }
}
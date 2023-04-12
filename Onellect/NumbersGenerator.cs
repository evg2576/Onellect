namespace OnellectTest;
public static class NumbersGenerator
{
    public const int SIZE_MIN = 20;
    public const int SIZE_MAX = 101;

    public const int RANGE_MIN = -100;
    public const int RANGE_MAX = 101;

    public const int METHODS_COUNT = 2;

    static Random _rnd = new Random();

    public static IEnumerable<int> GetRandomNumbers()
    {
        var intList = new List<int>();

        int size = _rnd.Next(SIZE_MIN, SIZE_MAX);

        for (int i = 0; i < size; i++)
            intList.Add(_rnd.Next(RANGE_MIN, RANGE_MAX));

        return intList;
    }

    public static IEnumerable<int>? Sort(IEnumerable<int> numbers)
    {
        int methodNumber = _rnd.Next(0, METHODS_COUNT);

        switch (methodNumber)
        {
            case 0:
                return BubbleSort(numbers);
            case 1:
                return QuickSort(numbers);
            default:
                return default;
        }
    }

    static IEnumerable<int> BubbleSort(IEnumerable<int> numbers)
    {
        var result = numbers.ToArray();
        int count = numbers.Count();

        for (int i = 0; i < count - 1; i++)
            for (int j = i + 1; j < count; j++)
                if (result[i] > result[j])
                    (result[i], result[j]) = (result[j], result[i]);

        return result;
    }

    static IEnumerable<int> QuickSort(IEnumerable<int> array) =>
        QuickSort(array.ToArray(), 0, array.Count() - 1);

    static int[] QuickSort(int[] array, int minIndex, int maxIndex)
    {
        if (minIndex >= maxIndex)
            return array;

        int pivotIndex = GetPivotIndex(array, minIndex, maxIndex);

        QuickSort(array, minIndex, pivotIndex - 1);

        QuickSort(array, pivotIndex + 1, maxIndex);

        return array;
    }

    static int GetPivotIndex(int[] array, int minIndex, int maxIndex)
    {
        int pivot = minIndex - 1;

        for (int i = minIndex; i <= maxIndex; i++)
            if (array[i] < array[maxIndex])
            {
                pivot++;
                (array[pivot], array[i]) = (array[i], array[pivot]);
            }

        pivot++;
        (array[pivot], array[maxIndex]) = (array[maxIndex], array[pivot]);

        return pivot;
    }
}

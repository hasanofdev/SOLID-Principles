// Liskov Substitution Prinsipi Bize Base Class-larinin Obyektlerini Programi Qarisdirmadan Derived Class-larinin
// Obyektleri Ile Deyismeyi Bildirir.Buna Sebeb Eger Biz Base Class-lari deyisdirsek Kodumuz Qarisa Biler.Meselen:
// Rectangle Class-miz var Ve Biz Bunu Bir Nece Yerde Istifade Etmisik Eger Biz Bu Classi Deyissek Kodumuzda Qarisacaq 
// Liskov Prinsipi Ise Bu Classi Deyisdirmek Evezine Onun Fieldlerini Yeni Yaratdigimiz Classa Oturmekdir

// Before

//public class SumCalculator
//{
//    protected readonly int[] _numbers;
//    public SumCalculator(int[] numbers)
//    {
//        _numbers = numbers;
//    }
//    public int Calculate() => _numbers.Sum();
//}

//public class EvenNumbersSumCalculator : SumCalculator
//{
//    public EvenNumbersSumCalculator(int[] numbers)
//        : base(numbers)
//    {
//    }
//    // Bu Methoda Baxsaq Gorerikki SumCalculator Class-nin Calculate Methodunu Deysirik.
//    // Liskov Prinsipi Bu Methodu Evez Etmek Yerine Bu Methodu EvenNumbersSumCalculator Class-a Uygun Yazmagi Teklif Edir.
//    // Buna Sebeb Biz SumCalculator Classini Icerisini Deyserek Onun Anlamini Deysirik.
//    public new int Calculate() => _numbers.Where(x => x % 2 == 0).Sum();
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        var numbers = new int[] { 5, 7, 9, 8, 1, 6, 4 };
//        SumCalculator sum = new SumCalculator(numbers);
//        Console.WriteLine($"The sum of all the numbers: {sum.Calculate()}");
//        Console.WriteLine();
//        EvenNumbersSumCalculator evenSum = new EvenNumbersSumCalculator(numbers);
//        Console.WriteLine($"The sum of all the even numbers: {evenSum.Calculate()}");
//    }
//}

// After

public abstract class Calculator
{
    protected readonly int[] _numbers;
    public Calculator(int[] numbers)
    {
        _numbers = numbers;
    }
    public abstract int Calculate(); // Bu Methodu Abstract Etmekde Meqsed Bedenini Base Class Daxilinde yazmamaqdir
}

public class SumCalculator : Calculator
{
    public SumCalculator(int[] numbers)
        : base(numbers)
    {
    }
    public override int Calculate() => _numbers.Sum();
}

public class EvenNumbersSumCalculator : Calculator
{
    public EvenNumbersSumCalculator(int[] numbers)
       : base(numbers)
    {
    }
    public override int Calculate() => _numbers.Where(x => x % 2 == 0).Sum();
}
class Program
{
    static void Main(string[] args)
    {
        var numbers = new int[] { 5, 7, 9, 8, 1, 6, 4 };
        Calculator sum = new SumCalculator(numbers);
        Console.WriteLine($"The sum of all the numbers: {sum.Calculate()}");
        Console.WriteLine();
        Calculator evenSum = new EvenNumbersSumCalculator(numbers);
        Console.WriteLine($"The sum of all the even numbers: {evenSum.Calculate()}");
    }
}
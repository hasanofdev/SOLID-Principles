// Open/Closed Prinsipi Yaratdigimiz Classlarin Genislenmeye Aciq Amma Desyisikliye Bagli Olmagini Teleb Edir.
// Bizim Maas Hesablayan Calculator Class-miz Var.Bu Class-in Icerisinde Butun Maaslarin Cemini Hesablayan CalculateTotalSalaries
// Metodu Yer Alir.Ilkin Baxisda Kodumuz Duzgundur.Yalniz Layihe Direktoru Eger Deseki Junior Dveloperlerin Maasin Ayri,
// Middle-larin Ayri,Seniorlarin Ayri Hesablasin Program.Bu Zaman Biz Classi Deyismeye Mecbur Qaliriq.Kodumuz Islesede Burada Kodumuz 
// Oxunaqsiz Ve Biraz Cirkin Gorsenecek.Bunu Duzeltmek Ucun Yazdigim Koda Baxaq:

// After 

public class DeveloperReport
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Level { get; set; }
    public int WorkingHours { get; set; }
    public double HourlyRate { get; set; }
}

//public class SalaryCalculator // <-- Bu Classmiz Maas Hesablayir Az Once Dediyi Kimi.
//{
//    private readonly IEnumerable<DeveloperReport> _developerReports;
//    public SalaryCalculator(List<DeveloperReport> developerReports)
//    {
//        _developerReports = developerReports;
//    }
//    public double CalculateTotalSalaries()
//    {
//        double totalSalaries = 0D;


//        //foreach (var devReport in _developerReports) //Bu Foreach Ilkin Versiyadaki Foreachdir Asagidaki Ise Direktorun Seniorlarin Maasinin Ayri
//        //{                                               //Hesablanmasini Istediyi ForEach-dir.
//        //    totalSalaries += devReport.HourlyRate * devReport.WorkingHours;
//        //}

//        foreach (DeveloperReport devReport in _developerReports)
//        {
//            if (devReport.Level == "Senior developer")
//            {
//                totalSalaries += devReport.HourlyRate * devReport.WorkingHours * 1.2;
//            }
//            else
//            {
//                totalSalaries += devReport.HourlyRate * devReport.WorkingHours;
//            }
//        }
//        return totalSalaries;
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        var devReports = new List<DeveloperReport>
//    {
//        new DeveloperReport {Id = 1, Name = "Dev1", Level = "Senior developer", HourlyRate  = 30.5, WorkingHours = 160 },
//        new DeveloperReport {Id = 2, Name = "Dev2", Level = "Junior developer", HourlyRate  = 20, WorkingHours = 150 },
//        new DeveloperReport {Id = 3, Name = "Dev3", Level = "Senior developer", HourlyRate  = 30.5, WorkingHours = 180 }
//    };
//        var calculator = new SalaryCalculator(devReports);
//        Console.WriteLine($"Sum of all the developer salaries is {calculator.CalculateTotalSalaries()} dollars");
//    }
//}

// Before - Indi Kodumuzu Biraz Duzeltek😉

public abstract class BaseSalaryCalculator // Bunu Interface Kimide Yarada Bilerdik.
{
    protected DeveloperReport DeveloperReport { get; private set; }
    public BaseSalaryCalculator(DeveloperReport developerReport)
    {
        DeveloperReport = developerReport;
    }
    public abstract double CalculateSalary();
}

// Indi Ise Her Level Gore Bir Derived Class Yaradacayiq

public class SeniorDevSalaryCalculator : BaseSalaryCalculator
{
    public SeniorDevSalaryCalculator(DeveloperReport report)
        : base(report) { }
    public override double CalculateSalary() => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours * 1.2;
}

public class JuniorDevSalaryCalculator : BaseSalaryCalculator
{
    public JuniorDevSalaryCalculator(DeveloperReport developerReport)
        : base(developerReport) { }
    public override double CalculateSalary() => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours;
}

// Artiq Istesek Middle-a gorede base clasmizi deyismeden Calculator Yara bilerik

public class SalaryCalculator // Artiq Her Developer-in Leveline Uygun If Yazmaga Ehtyac Yoxdur
{
    private readonly IEnumerable<BaseSalaryCalculator> _developerCalculation;
    public SalaryCalculator(IEnumerable<BaseSalaryCalculator> developerCalculation)
    {
        _developerCalculation = developerCalculation;
    }
    public double CalculateTotalSalaries()
    {
        double totalSalaries = 0D;
        foreach (var devCalc in _developerCalculation)
        {
            totalSalaries += devCalc.CalculateSalary();
        }
        return totalSalaries;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var devCalculations = new List<BaseSalaryCalculator>
        {
            new SeniorDevSalaryCalculator(new DeveloperReport {Id = 1, Name = "Dev1", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 160 }),
            new JuniorDevSalaryCalculator(new DeveloperReport {Id = 2, Name = "Dev2", Level = "Junior developer", HourlyRate = 20, WorkingHours = 150 }),
            new SeniorDevSalaryCalculator(new DeveloperReport {Id = 3, Name = "Dev3", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 180 })
        };
        var calculator = new SalaryCalculator(devCalculations);
        Console.WriteLine($"Sum of all the developer salaries is {calculator.CalculateTotalSalaries()} dollars");
    }
}
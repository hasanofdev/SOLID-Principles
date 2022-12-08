// Interface Segregation Prinsipi Interface daxilindeki Ehtyac Olmayan Methodlari Implement Elememeyi Meselehet Gorur

// Before 

//public interface IPrinterTasks
//{
//    void Print(string PrintContent);
//    void Scan(string ScanContent);
//    void Fax(string FaxContent);
//    void PrintDuplex(string PrintDuplexContent);
//}

//public class HPLaserJetPrinter : IPrinterTasks // Bu Class-da Interfacin Butun Methodlarini Implement Etmeye Ehtyac Var
//{
//    public void Print(string PrintContent)
//    {
//        Console.WriteLine("Print Done");
//    }
//    public void Scan(string ScanContent)
//    {
//        Console.WriteLine("Scan content");
//    }
//    public void Fax(string FaxContent)
//    {
//        Console.WriteLine("Fax content");
//    }
//    public void PrintDuplex(string PrintDuplexContent)
//    {
//        Console.WriteLine("Print Duplex content");
//    }
//}

//class LiquidInkjetPrinter : IPrinterTasks // Bu Class-da Ise Sadece Ikisine Ehtyac Var Amma Biz Standardlara Esasen Butun Methodlari Implement Etmeliyik
//{
//    public void Print(string PrintContent)
//    {
//        Console.WriteLine("Print Done");
//    }
//    public void Scan(string ScanContent)
//    {
//        Console.WriteLine("Scan content");
//    }
//    public void Fax(string FaxContent)
//    {
//        throw new NotImplementedException();
//    }
//    public void PrintDuplex(string PrintDuplexContent)
//    {
//        throw new NotImplementedException();
//    }
//}

// After

public interface IPrinterTasks
{
    void Print(string PrintContent);
    void Scan(string ScanContent);
}
public interface IFaxTasks
{
    void Fax(string content);
}
public interface IPrintDuplexTasks
{
    void PrintDuplex(string content);
}
public class HPLaserJetPrinter : IPrinterTasks, IFaxTasks,
                                     IPrintDuplexTasks
{
    public void Print(string PrintContent)
    {
        Console.WriteLine("Print Done");
    }
    public void Scan(string ScanContent)
    {
        Console.WriteLine("Scan content");
    }
    public void Fax(string FaxContent)
    {
        Console.WriteLine("Fax content");
    }
    public void PrintDuplex(string PrintDuplexContent)
    {
        Console.WriteLine("Print Duplex content");
    }
}
public class LiquidInkjetPrinter : IPrinterTasks
{
    public void Print(string PrintContent)
    {
        Console.WriteLine("Print Done");
    }
    public void Scan(string ScanContent)
    {
        Console.WriteLine("Scan content");
    }
}
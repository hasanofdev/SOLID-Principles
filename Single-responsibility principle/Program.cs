// Single Responsibility Prinsipi Bize Klassmizin Bir Isi Goermesini Meslehet Gorur.
// Bununla Bizim Klasslarimiz Seliqeli Ve Oxunaqli Olur.
// Meselen Bir Kompyuter Servisi Tesvir Edek.Bildiyimiz Kimi Servislere Cox Zaman Temir Ucun Gedilir.
// Servis Klass-i Yaratsaq Ve Hemin Classda Temir Ucun Detal Istehsal Eden Method Yazsaq ->
// Bu Biraz Mentiqsiz Olar Ve Single Responsibility Prinsipini Pozar.Birde Kodla Baxaq:

// Before

using System.Reflection.Metadata.Ecma335;

public class Ram
{
    public string? Title { get; set; }
    public int? Size { get; set; }
}

public class Computer
{
    public string? Name { get; set; } = "HP Pavilion";
    public Ram? Ram { get; set; } = new Ram() { Title="Kingston16Gb",Size=16};

    public override string ToString() => $"Name:{Name}\nRam:{Ram!.Title}";
}

public class ComputerService
{
    public void Format() => Console.WriteLine("Computer Formatted!");
    public void ChangeRam(Computer comp, Ram newRam) => comp.Ram = newRam;
    public Ram CreateRam() => new Ram() { Size = 64, Title = "Kingston FURY Renegade 64GB" }; // Buradaki Methoda Baxsaq Gorerikki
                                                                                              // Classmizin Adi Servis Olsada Hemde
                                                                                              // Ram Istehsal Edir.Yeni Tek Is Gormur.
}

// After

public interface IComputerDetalFactory
{
    public Ram CreateRam();

    // public void CreateKeyboard(); // Bu Iki Ona Gore Commentledimki Burada Bu Methodlarda Ola Bilerdi
    // public void CreateTouchPad();    Amma Hal Hazirda Bunlara Ehtiyac Yoxdur
}

public interface IComputerService
{
    public void Format();
    public void ChangeRam(Computer comp, Ram newRam);
}

public class MyCompService : IComputerService
{
    public void ChangeRam(Computer comp, Ram newRam) => comp.Ram = newRam;

    public void Format() => Console.WriteLine("Computer Formatted!");
}

public class MicrosoftDetailFactory : IComputerDetalFactory
{
    public Ram CreateRam() => new Ram() { Size = 64, Title = "Kingston FURY Renegade 64GB" };
}



class Program
{
    static void Main(string[] args)
    {
        MyCompService compService = new MyCompService();
        MicrosoftDetailFactory detailFactory = new MicrosoftDetailFactory();

        Computer comp = new Computer();


        Console.WriteLine(comp);
        compService.ChangeRam(comp, detailFactory.CreateRam());
        Console.WriteLine("\nRam Changed");
        Console.WriteLine($"\n{comp}");        
    }
}


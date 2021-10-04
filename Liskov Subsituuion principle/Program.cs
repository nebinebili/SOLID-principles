using System;

namespace Liskov_Subsitution_principle
{
    // Bad Example

    //public abstract class AccessDataFile
    //{
    //    protected AccessDataFile(string filePath)
    //    {
    //        FilePath = filePath;
    //    }

    //    public string FilePath { get; set; }
    //    public abstract void ReadFile();
    //    public abstract void WriteFile();
    //}

    //public class AdminDataFileUser : AccessDataFile
    //{
    //    public AdminDataFileUser(string filePath) : base(filePath) { }
    //    public override void ReadFile()
    //    {
    //        Console.WriteLine($"File {FilePath} has been read");
    //    }

    //    public override void WriteFile()
    //    {
    //        Console.WriteLine($"File {FilePath} has been written");
    //    }
    //}


    //public class RegularDataFileUser : AccessDataFile
    //{
    //    public RegularDataFileUser(string filePath) : base(filePath) { }
    //    public override void ReadFile()
    //    {
    //        Console.WriteLine($"File {FilePath} has been read");
    //    }

    //    public override void WriteFile()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}



    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        AdminDataFileUser admin = new AdminDataFileUser("Admin Files");
    //        RegularDataFileUser regular = new RegularDataFileUser("Regular Files");

    //        AccessFile(admin);
    //        AccessFile(regular);
    //    }

    //    static void AccessFile(AccessDataFile accessData)
    //    {
    //        accessData.ReadFile();
    //        accessData.WriteFile();
    //    }
    //}


    // Good Example

    public abstract class AccessDataFile
    {
        protected AccessDataFile(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; set; }
        public abstract void ReadFile();
    }

    public interface IWriteFile
    {
        void WriteFile();
    }

    public class AdminDataFileUser : AccessDataFile, IWriteFile
    {
        public AdminDataFileUser(string filePath) : base(filePath) { }

        public override void ReadFile()
        {
            Console.WriteLine($"File {FilePath} has been read");
        }

        public void WriteFile()
        {
            Console.WriteLine($"File {FilePath} has been written");
        }
    }


    public class RegularDataFileUser : AccessDataFile
    {
        public RegularDataFileUser(string filePath) : base(filePath) { }
        public override void ReadFile()
        {
            Console.WriteLine($"File {FilePath} has been read");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            AdminDataFileUser admin = new AdminDataFileUser("Admin Files");
            RegularDataFileUser regular = new RegularDataFileUser("Regular Files");

            AccessFile(admin);
            AccessFile(regular);
        }

        static void AccessFile(AccessDataFile accessData)
        {
            accessData.ReadFile();
        }
    }

    /*Liskov Subsitutuion Principle-Bu prinsipde bildiri ki her bir derive class Base class yerinde islene bilmelidi
     * 
     *Bad Example da AccesDataFile classi var ve daxilinde ReadFile,Writefile metodlari var.
     *AdminDataFileUser ve RegularDataFileUser classlari bu abstract classdan miras alir ver abstract metodlari override edir.
     *ve uygun mesajlar yazilir.Admin ve Regular classindan obyekt yaradib AccesFile metodu daxilide Base class olan AccessDataFile dan yaranmis obyekte gonderilir.
     *hemin metod daxilinde Read ve Write metodlari cagrilir run etdikde Regular Write bacarigi olmadigi ucun exception atacaq
     *
     *Good Example da bunun qarsini almaq ucun Write metodunu IWriteFile interfacine cixarilir.AdminDataFileUser bu metodu impliment edir
     *Regularda ise bu bacariq olmadigi ucun bu interfaci impliment etmir.Ve kod exception atmadan isleyecek 
     */
}

using System;

namespace Open_Closed_Principle
{
    // Bad Example

    //class HomeEquipment 
    //{

    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public double Price { get; set; }

    //    public HomeEquipment(int id, string name, double price)
    //    {
    //        Id = id;
    //        Name = name;
    //        Price = price;
    //    }

    //    public double PriceWithDiscount()
    //    {
    //        if (Name == "Tv")
    //        {
    //            return Price - ((Price * 20) / 100);
    //        }
    //        else if(Name== "Refrigerator")
    //        {
    //            return Price - ((Price * 40) / 100);
    //        }
    //        else return Price - ((Price * 50) / 100);
    //    }
    //}



    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        HomeEquipment homeEquipment = new HomeEquipment(1, "Tv", 300.5);
    //        Console.WriteLine(homeEquipment.PriceWithDiscount());
    //    }
    //}



    // Good Example

    public abstract class HomeEquipment
    {    
        public int Id { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }

        public HomeEquipment(int id, double price, double discount)
        {
            Id = id;
            Price = price;
            Discount = discount;
        }
        public abstract double PriceWithDiscount();
    }

    public class Tv:HomeEquipment
    {
        public Tv(int id, double price, double discount) : base(id, price, discount) { }

        public override double PriceWithDiscount()
        {
            return Price - ((Price * Discount) / 100);
        }
    }

    public class VacuumCleaner : HomeEquipment
    {
        public VacuumCleaner(int id, double price, double discount) : base(id, price, discount) { }

        public override double PriceWithDiscount()
        {
            return Price - ((Price * Discount) / 100);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Tv tv = new Tv(1, 200, 10);
            Console.WriteLine(tv.PriceWithDiscount());
        }
    }

    /* Open-Closed Principle-Kod Genislenmeye aciq deyisikliye ise qapali olamlidi.Bad Example da
     * Meiset avadanliqalri adli class var ve class daxilinde propertyler ve Avadanliqalrin endirimli
     * qiymetlerini hesabliyan metod var.Metod daxilinde Her yeni endirimli avadanliq ucun ona uygun deyislik edilmeli olacaq.
     * Burda eyni zamanda Single Responsibilty qaydasi da pozulmus gorunur.
     * 
     * Good Example da ise Meiset avadanliqlari adinda abstract class var ve daxilinde abstract metod endirimli qiymetleri hesablamaq ucun var.
     * Her yeni endirimli meiset avadanliq ucun yeni class yaradilir ver abstract classdan miras alir ve metod overrirde olunu  
     */
}

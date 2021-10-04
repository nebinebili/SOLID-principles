using System;

namespace Interface_Segregation_Principle
{
    // Bad Example

    //public interface IVehicle
    //{
    //    void setPrice(double price);
    //    void setColor(string color);
    //    void start();
    //    void stop();
    //    void fly();
    //}

    //public class Car : IVehicle
    //{
    //    public double Price { get; set; }
    //    public string Color { get; set; }
    //    public void fly()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void setColor(string color)
    //    {
    //        this.Color = color;
    //    }

    //    public void setPrice(double price)
    //    {
    //        this.Price = price;
    //    }

    //    public void start()
    //    {
    //        //Something code
    //    }

    //    public void stop()
    //    {
    //        // somethin code
    //    }
    //}


    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Hello World!");
    //    }
    //}


    // Good Example

    public interface IVehicle
    {
        void setPrice(double price);
        void setColor(string color);
    }

    public interface IMovable
    {
        void start();
        void stop();
    }

    public interface IFlyable
    {
        void fly();
    }

    public class Car : IVehicle,IMovable
    {
        public double Price { get; set; }
        public string Color { get; set; }

        public void setColor(string color)
        {
            this.Color = color;
        }

        public void setPrice(double price)
        {
            this.Price = price;
        }

        public void start()
        {
            // something code
        }

        public void stop()
        {
            // something code
        }
    }

    public class Airplane : IVehicle, IMovable,IFlyable
    {
        public double Price { get; set; }
        public string Color { get; set; }

        public void fly()
        {
           // something code
        }

        public void setColor(string color)
        {
            this.Color = color;
        }

        public void setPrice(double price)
        {
            this.Price = price;
        }

        public void start()
        {
            // something code
        }

        public void stop()
        {
            // something code
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    /* Interface Segregation-Bir interface daxilinde her bacarigi yazmaq duzgun deyil.Vezyetden asli olaraq Interface parcalamaq lazimdi
     * Bad Exmaple da IVehicle interfaci daxilinde neqliyyata uygun olaraq start,stop ve fly ve diger metodlari yazilib
     * Car classi yaradilib ve bu interfaci implement edib.Burda Fly metodu car ucun uygun olmur
     * 
     * Good Example da IVehicle da her neqliyyata uygun olan metod saxlanilb.IMovable interfacinde uygun olan ve IFlyable da fly metodu saxlanilb
     * Car classi yaradilir ve ona uygun bacariga esasen IVehicle ve IMovable interfaclerini implement edir
     * Airplane classi yaradilir ve ona uygun olan her uc interfaci implement edir
     * 
     * IVehicle interfacini parcalayaraq Interface segregation prinsipine ugun yazilir
     */
}

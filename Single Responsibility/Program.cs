using System;


namespace Single_Responsibility
{
    // Bad Example

    //public class User 
    //{
    //    public string Name { get; set; }
    //    public string SurName { get; set; }
    //    public string Password { get; set; }

    //    public User(string name, string surName, string password)
    //    {
    //        Name = name;
    //        SurName = surName;
    //        Password = password;
    //    }

    //    public string HashPassword()
    //    {
    //        byte[] data = System.Text.Encoding.ASCII.GetBytes(Password);
    //        data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
    //        String hash = System.Text.Encoding.ASCII.GetString(data);
    //        return hash;
    //    }

    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        User user = new User("Kenan", "Idayetov", "Kenan123");
    //        Console.WriteLine(user.HashPassword());
    //    }
    //}


    // Good Example

    public class User
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Password { get; set; }

        public User(string name, string surName, string password)
        {
            Name = name;
            SurName = surName;
            Password = password;
        }

    }

    public static class HashPassword
    {
        public static string Hash(User user)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(user.Password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);
            return hash;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Kenan", "Idayetov", "Kenan123");
            Console.WriteLine(HashPassword.Hash(user));
        }
    }


   /* Single responsibilty-Her bir komponent (class,metod..) yalniz bir is gormelidi.Bad example da gorunduyu kimi
    * User clasi var.Her bir userin passwordunu hashCode a ceviren metod var.Class 2 is gormus olur.
    * Good Example da ise Userin  Passwordu HasCode a cevirmek ucun ayri bir class icinde metod qeyd olunub
    */
}

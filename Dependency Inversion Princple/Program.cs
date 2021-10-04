using System;
using System.Collections.Generic;

namespace Dependency_Inversion_Princple
{
    // Bad Example

    //public class Email
    //{     
    //    public string ToAddress { get; set; }
    //    public string Subject { get; set; }
    //    public string Content { get; set; }

    //    public Email(string toAddress, string subject, string content)
    //    {
    //        ToAddress = toAddress;
    //        Subject = subject;
    //        Content = content;
    //    }


    //    public void SendEmail()
    //    {
    //        Console.WriteLine("Send Email Message");
    //    }
    //}

    //public class SMS
    //{
    //    public string PhoneNumber { get; set; }
    //    public string Message { get; set; }

    //    public SMS(string phoneNumber, string message)
    //    {
    //        PhoneNumber = phoneNumber;
    //        Message = message;
    //    }


    //    public void SendSMS()
    //    {
    //        Console.WriteLine("Send SMS Message");
    //    }
    //}

    //public class Notification
    //{
    //    private Email _email;
    //    private SMS _sms;
    //    public Notification(Email email,SMS sms)
    //    {
    //        _email = email;
    //        _sms = sms;
    //    }

    //    public void Send()
    //    {
    //        _email.SendEmail();
    //        _sms.SendSMS();
    //    }
    //}


    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Email email = new Email("Sumqayit 18mkr", "Job", "Invite Job interview");
    //        SMS sMS = new SMS("055-555-55-55", "Hello");
    //        Notification notification = new Notification(email, sMS);
    //        notification.Send();
    //    }
    //}

    public interface IMessage
    {
        void SendMessage();
    }

    public class Email : IMessage
    {
        public string ToAddress { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Email(string toAddress, string subject, string content)
        {
            ToAddress = toAddress;
            Subject = subject;
            Content = content;
        }
        public void SendMessage()
        {
            Console.WriteLine("Send Email Message");
        }
    }

    public class SMS : IMessage
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }

        public SMS(string phoneNumber, string message)
        {
            PhoneNumber = phoneNumber;
            Message = message;
        }

        public void SendMessage()
        {
            Console.WriteLine("Send SMS Message");
        }
    }

    public class Notification
    {
        private List<IMessage> _messages;

        public Notification(List<IMessage> messages)
        {
            this._messages = messages;
        }
        public void Send()
        {
            foreach (var message in _messages)
            {
                message.SendMessage();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Email email = new Email("Sumqayit 18mkr", "Job", "Invite Job interview");
            SMS sMS = new SMS("055-555-55-55", "Hello");
            List<IMessage> messages = new List<IMessage>
            {
                email,sMS
            };
            Notification notification = new Notification(messages);
            notification.Send();
        }
    }

    /*Dependency Inversion Principle-Bu prinsipde Boyuk class kicik classlardan asli olmamalidi
     * Bad Example da Notification classinin SMS ve EMail classlardan asli oldugu gorunur.Her yeni sistem yazildiqda Notificatin classi daixlinde 
     * o classi properti kimi saxlmaq mecburiyyeti olur.
     * 
     * Good Example da ortaq xusuiyyet olan message metodunu Interface daxilinde yazin her yeni sistem impliment edir.
     * Notification daxilinde ise bu sistemlerin base adi altinde listi saxlanilr ve boyuk classin kicik classdan asligi yox olur
     */

}

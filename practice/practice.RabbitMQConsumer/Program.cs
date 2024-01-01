using Newtonsoft.Json;
using practice.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net.Mail;
using System.Net;
using System.Text;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Starting connection.....");




var factory = new ConnectionFactory
{
    HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "rabbitmq",
    UserName = Environment.GetEnvironmentVariable("RABBITMQ_USER") ?? "guest",
    Password = Environment.GetEnvironmentVariable("RABBITMQ_PASS") ?? "guest",
    Port = int.Parse(Environment.GetEnvironmentVariable("RABBITMQ_PORT") ?? "5672")
};

Console.WriteLine("Before connection..........");

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

Console.WriteLine("After connection................");

Console.WriteLine("---------------------------------------------------------");

Console.WriteLine("Host -> " + factory.HostName + " | " + "Username and password -> " + factory.UserName + " " + factory.Password + " | " + factory.Port);

Console.WriteLine("---------------------------------------------------------");



channel.QueueDeclare(queue: "hello",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

Console.WriteLine(" [*] Waiting for messages........................");

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
  
      Console.WriteLine("------------------------------------------------");
      var body = ea.Body.ToArray();
      var message = Encoding.UTF8.GetString(body);
      var entity = JsonConvert.DeserializeObject<EmailToken>(message);
      Console.WriteLine("Received an entity: " + entity.mail + " | " + entity.token);
      Sender.Send(entity);
      Console.WriteLine("Sent an email, processing %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
      Console.WriteLine("---------------------------------------");
  
 
};
channel.BasicConsume(queue: "hello",
                     autoAck: true,
                     consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();


class Sender
{
    public static void Send(EmailToken entity)
    {
        string serverAddress = "smtp.gmail.com";
        string mailSender = "eautosalon.verif@gmail.com";
        string mailPass = "frhaexjyedayript";
        int port = 587;
        string to = entity.mail;
        string subject = "Mail Verification";
        string content = "Hvala na ukazanoj prilici, vaš verifikacijski token je " + entity.token;

        SmtpClient client = new SmtpClient(serverAddress)
        {
            Port = port,
            Credentials = new NetworkCredential(mailSender, mailPass),
            EnableSsl = true,
        };

        MailMessage mail = new MailMessage(mailSender, to)
        {
            Subject = subject,
            Body = content,
            IsBodyHtml = false
        };
       
        
        client.Send(mail);
       
        
        Console.WriteLine("Mail uspješno poslan na " + entity.mail);
        
       
    }
}

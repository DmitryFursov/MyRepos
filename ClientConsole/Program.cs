using ClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientConsole
{
    class Program
    {
        // адрес и порт сервера, к которому будем подключаться               
        static void Main(string[] args)
        {
            try
            {
                string server = "127.0.0.1";
                int port = 8888;

                TcpClient client = new TcpClient();
                client.Connect(server, port);

//                byte[] data = new byte[256];

//                StringBuilder response = new StringBuilder();

                NetworkStream stream = client.GetStream();

                StreamWriter writer = new StreamWriter(stream);

                //using (SslStream sslWriter = new SslStream(stream,false, new RemoteCertificateValidationCallback(ValidateSertificate.ValidateServerCertificate), null))
                //{
                //    sslWriter.AuthenticateAsClient(server);
                //    var dataModel = new DataModel();
                //    dataModel.FirstName = "123";
                //    dataModel.MiddleName = "123";
                //    dataModel.SecondName = "123";
                //    dataModel.Sum = 123;
                //    dataModel.IsPaid = true;
                //    dataModel.Date = DateTime.Now;

                //    var json = JsonSerializer.Serialize<DataModel>(dataModel);
                //    var jsonbyte = Encoding.Unicode.GetBytes(json);
                //    sslWriter.Write(jsonbyte);
                //    sslWriter.Flush();

                //}

               

                var dataModel = new DataModel();
                dataModel.FirstName = "123";
                dataModel.MiddleName = "123";
                dataModel.SecondName = "123";
                dataModel.Sum = 123;
                dataModel.IsPaid = true;
                dataModel.Date = DateTime.Now;

                var json = JsonSerializer.Serialize<DataModel>(dataModel);

                Console.WriteLine(json);
                writer.WriteLine(json);
                writer.Flush();

                StreamReader reader = new StreamReader(stream);
                string response = reader.ReadLine();
                Console.WriteLine("Получено: " + response);

                //StringBuilder response = new StringBuilder();
                //byte[] data = new byte[256];

                //do
                //{
                //    int bytes = stream.Read(data, 0, data.Length);
                //    response.Append(Encoding.UTF8.GetString(data, 0, bytes));
                //}
                //while (stream.DataAvailable); // пока данные есть в потоке

                //Console.WriteLine(response.ToString());


                // Закрываем потоки
                stream.Close();
                client.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }

            Console.WriteLine("Запрос завершен...");
            Console.Read();
        }

        //static void Main(string[] args)
        //{
        //    try
        //    {
        //        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

        //        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //        // подключаемся к удаленному хосту
        //        socket.Connect(ipPoint);
        //        Console.Write("Введите сообщение:");
        //        string message = Console.ReadLine();

        //        var dataModel = new DataModel();
        //        dataModel.FirstName = "123";
        //        dataModel.MiddleName = "123";
        //        dataModel.SecondName = "123";
        //        dataModel.Sum = 123;
        //        dataModel.IsPaid = true;
        //        dataModel.Date = DateTime.Now;
        //        var data = Encoding.Unicode.GetBytes(message);

        //        var json = JsonSerializer.Serialize<DataModel>(dataModel);
        //        var jsonbyte = Encoding.Unicode.GetBytes(json);
        //        Console.WriteLine(json);


        //        socket.Send(jsonbyte);

        //        // получаем ответ
        //        data = new byte[256]; // буфер для ответа
        //        StringBuilder builder = new StringBuilder();
        //        int bytes = 0; // количество полученных байт

        //        do
        //        {
        //            bytes = socket.Receive(data, data.Length, 0);
        //            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
        //        }
        //        while (socket.Available > 0);
        //        Console.WriteLine("ответ сервера: " + builder.ToString());

        //        // закрываем сокет
        //        socket.Shutdown(SocketShutdown.Both);
        //        socket.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    Console.Read();
        //}
        //public static bool ValidateServerCertificate(object sender, X509Certificate certificate,
        //X509Chain chain, SslPolicyErrors sslPolicyErrors)
        //{
        //    return true;
        //}


    }

}

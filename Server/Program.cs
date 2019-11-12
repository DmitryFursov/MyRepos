using ClassLibrary;
using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace Server
{
    class Program
    {
        static TcpListener server = null;
        static int port = 8888;
        static IPAddress localAddr;
        static TcpClient client;
        static NetworkStream stream;
        static StreamReader reader;
        static void Main(string[] args)
        {            
            try
            {
                string message;
                OpenServer();
                while (true)
                {                
                    
                     message = reader.ReadLine();

                    Console.WriteLine("Получено: " + message);

                    var dataModel = new DataModel();
                    try
                    {
                        dataModel = JsonSerializer.Deserialize<DataModel>(message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    SendResponse(message);

                    stream.Close();
                    client.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                CloseServer();
            }
        }

        static public bool InitializeComponents()
        {
            try
            {
                localAddr = IPAddress.Parse("127.0.0.1");
                client = server.AcceptTcpClient();
                stream = client.GetStream();
                reader = new StreamReader(stream);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }           
        }

        static public bool OpenServer()
        {

            try
            {
                InitializeComponents();
                server = new TcpListener(localAddr, port);
                server.Start();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }

        static public bool CloseServer()        
        {
            try
            {
                if (server != null)
                    server.Stop();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }

        static public void SendResponse(string message)
        {
            string response = "Сообщение из " + message.Length.ToString() + " байт получено. спасибо";
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(response);
            writer.Flush();
        }

    }

   




    //static void Main(string[] args)
    //{
    //    // получаем адреса для запуска сокета
    //    IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

    //    // создаем сокет
    //    Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    //    try
    //    {
    //        // связываем сокет с локальной точкой, по которой будем принимать данные
    //        listenSocket.Bind(ipPoint);

    //        // начинаем прослушивание
    //        listenSocket.Listen(10);

    //        Console.WriteLine("Сервер запущен. Ожидание подключений...");

    //        while (true)
    //        {
    //            Socket handler = listenSocket.Accept();
    //            // получаем сообщение
    //            StringBuilder builder = new StringBuilder();
    //            int bytes = 0; // количество полученных байтов
    //            byte[] data = new byte[256]; // буфер для получаемых данных

    //            do
    //            {
    //                bytes = handler.Receive(data);
    //                //builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
    //                //bulder
    //                var json = Encoding.Unicode.GetString(data);
    //                Console.WriteLine(json);
    //                var dec = JsonSerializer.Deserialize<DataModel>(json);


    //            }
    //            while (handler.Available > 0);

    //            Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder.ToString());

    //            // отправляем ответ
    //            string message = "ваше сообщение доставлено";
    //            data = Encoding.Unicode.GetBytes(message);
    //            handler.Send(data);
    //            // закрываем сокет
    //            handler.Shutdown(SocketShutdown.Both);
    //            handler.Close();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine(ex.Message);
    //    }

    //    //var dbHandler = new DbHandler();
    //    //var dataModel = new DataModel();
    //    //dataModel.FirstName = "123";
    //    //dataModel.MiddleName = "123";
    //    //dataModel.SecondName = "123";
    //    //dataModel.Sum = 123;
    //    //dataModel.IsPaid = true;
    //    //dataModel.Date = DateTime.Now;

    //    //dbHandler.Insert(dataModel);
    //    Console.ReadLine();
    //}
}


using ClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client
{
    class ConnectionHandler
    {
        private static string server = "127.0.0.1";
        private static int port = 8888;

        private TcpClient client;
        private NetworkStream stream;
        private StreamWriter writer;

        private void InitializeComponents()
        {            
            stream = client.GetStream();
            writer = new StreamWriter(stream);
        }

        private bool OpenConnection()
        {
            try
            {
                client = new TcpClient();
                client.Connect(server, port);
                InitializeComponents();
                return true;
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                stream.Close();
                client.Close();
                writer = null;
                return true;
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                return false;
            }           
        }
        public void SendToServer(DataModel dataModel)
        {           
            try
            {
                OpenConnection();

                var json = JsonSerializer.Serialize<DataModel>(dataModel);

                writer.WriteLine(json);
                writer.Flush();

                CloseConnection();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }           
        }
        public void DownloadFromServer()
        {
            OpenConnection();

            StreamReader reader = new StreamReader(stream);
            string response = reader.ReadLine();
            var json = JsonSerializer.Deserialize<DataModel>(response);

            CloseConnection();
        }
    }
}

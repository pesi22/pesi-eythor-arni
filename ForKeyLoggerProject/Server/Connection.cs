using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Sockets;

namespace ForKeyLoggerProject
{
    class Connection
    {
        private TcpClient client; //þessi breyta heldur utan um tcp
        private string ip; //Breytan fyrir ip töluna


        public delegate void Disconnected(Connection client);
        public event Disconnected DisconnectedEvent;
        public delegate void Received(Connection client, string Message);
        public event Received ReceivedEvent;


        public Connection(TcpClient clientb) //Setur tenginguna í gang
        {
            this.client = clientb; 
            ip = clientb.Client.RemoteEndPoint.ToString().Remove(clientb.Client.RemoteEndPoint.ToString().LastIndexOf(':')); //ip talan sett í breytu
            clientb.GetStream().BeginRead(new byte[] { 0 }, 0, 0, Read, null); 
        }
        void Read(IAsyncResult ar) //les gögnin sem client sendir
        {
            try
            {
                StreamReader reader = new StreamReader(client.GetStream()); 
                string msg = reader.ReadLine(); 
                if (msg == "") //ef messagið er empty þá er það Disconnect merki
                {
                    DisconnectedEvent(this); 
                    return; 
                }
                ReceivedEvent(this, msg);
                client.GetStream().BeginRead(new byte[] { 0 }, 0, 0, Read, null);
            }
            catch
            {
                DisconnectedEvent(this);
            }
        }
        public void Send(string Message) //sendir gögn
        {
            try
            {
                StreamWriter writer = new StreamWriter(client.GetStream());
                writer.WriteLine(Message);
                writer.Flush();
            }
            catch
            {
            }
        }
        public string IPAddress //no comment
        {
            get
            {
                return ip;
            }
        }
    }
}

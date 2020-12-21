//Using necessary libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

//namespace for the project file
namespace CSharpSocketing
{
    // Form1 object of Form class
    public partial class Form1 : Form
    {
        //Setting up variables and configs for the project
        delegate void SetTextCallback(string text);
        TcpListener listener; // Setting TCPListener
        TcpClient client;// Setting TCPClient
        NetworkStream ns;//Setting network stream
        Thread t = null;
        String receiverTitle; //receiver text name
        String type; // connection type

        public Form1()
        {
            InitializeComponent(); // intitialize graphics
        }

        /*
         * Opens up a new form on clicking the NEW WINDOW button
         */
        private void newBtn_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }

        /*
         * This method sets up the TCP Server based on the configurations made
         */
        private void setupTSBtn_Click(object sender, EventArgs e)
        {
            receiverTitle = "CLIENT"; // For server, the sender is "CLIENT";
            type = "TCP"; // type is TCP
            listener = new TcpListener(int.Parse(tsPortFld.Text)); //Setting up listener for server
            listener.Start(); // starting listener
            t = new Thread(DoWork); // Calling DoWork in separate thread
            t.Start(); // starting thread
        }

        /*
        * This method sets up the TCP Client based on the configurations made
        */
        private void setupTCBtn_Click(object sender, EventArgs e)
        {
            receiverTitle = "SERVER"; // For client, the sender is "SERVER";
            type = "TCP"; // type is "TCP"
            client = new TcpClient(tcServerIPFld.Text, int.Parse(tcServerPortFld.Text)); // Setting up TCPClient
            ns = client.GetStream(); // getting network stream of the TCPClient
            String s = "Connected\n";
            byte[] byteTime = Encoding.ASCII.GetBytes(s);
            ns.Write(byteTime, 0, byteTime.Length);
            t = new Thread(DoWork); // Calling DoWork in separate thread
            t.Start(); // starting thread
        }

        /*
         * This method is used to receive the packet from sender, get the bytes from it, convert to string and output it to message box
         */ 
        private void DoWork()
        {
            try
            {
                if (listener != null)
                {
                    client = listener.AcceptTcpClient();
                    ns = client.GetStream();
                }

                byte[] bytes = new byte[2048];
                while (true)
                {
                    int bytesRead = ns.Read(bytes, 0, bytes.Length);
                    this.SetText(Encoding.ASCII.GetString(bytes, 0, bytesRead));
                }
            }
            catch (Exception e)
            {

            }
        }

        /*
         * This method is used to set the text to message box using appendToDisplay method;
         */ 
        private void SetText(string text)
        {
            if (this.displayBox.InvokeRequired)
            {
                // For inter-thread communication
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                appendToDisplay(receiverTitle + "    ", Color.Red);
                appendToDisplay(text + "\n", Color.Black);
            }
        }

        /*
         * On clicking send button, this method gets executed
         * Gets the sending message, writes to the message box, gets byte of the message, and transmits to the socket
         */ 
        private void sendBtn_Click(object sender, EventArgs e)
        {
            String s = sendMsgFld.Text + "\n";
            byte[] byteTime = Encoding.ASCII.GetBytes(s);
            appendToDisplay("YOU    ", Color.Blue);
            appendToDisplay(s + "\n", Color.Black);

            // If type is TCP
            if (type != null && type.Equals("TCP")) ns.Write(byteTime, 0, byteTime.Length);
            else
            {
                //If type is UDP

                Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPAddress transmitIPAddress;
                int transmitPort;
                //Setting sending IP and port according to the connection type UDP Server or  Client
                try
                {
                    if (receiverTitle != null && receiverTitle.Equals("SERVER"))
                    {
                        transmitIPAddress = IPAddress.Parse(ucServerIPFld.Text);
                        transmitPort = int.Parse(ucServerPortFld.Text);

                    }
                    else
                    {
                        transmitIPAddress = IPAddress.Parse(usClientIPFld.Text);
                        transmitPort = int.Parse(usClientPortFld.Text);
                    }

                    IPEndPoint receiverEP = new IPEndPoint(transmitIPAddress, transmitPort);
                    sendSocket.SendTo(byteTime, receiverEP);
                }
                catch(Exception ea) {
                }
            }
        }
        
        // 
        /*
         * This method is used to write output to the messagebox with different text in different color (Patel, 2010)
         */ 
        private void appendToDisplay(String text, Color c)
        {
            displayBox.SelectionStart = displayBox.TextLength;
            displayBox.SelectionLength = 0;

            displayBox.SelectionColor = c;
            displayBox.AppendText(text);
            displayBox.SelectionColor = displayBox.ForeColor;
        }

        /*
         * To setup UDP Server connection
         */ 
        private void setupUSBtn_Click(object sender, EventArgs e)
        {
            udpInit();
            receiverTitle = "CLIENT";
        }

        /*
        * To setup UDP Client connection
        */
        private void setupUCBtn_Click(object sender, EventArgs e)
        {
            udpInit();
            receiverTitle = "SERVER";
        }

        /*
         * UDP Initialization
         */ 
        private void udpInit()
        {
            type = "UDP";
            t = new Thread(UDPWork); //Calling UDPWork method in different thread
            t.Start(); //starting thread
        }

        /*
        * This method is used to receive the packet from sender, get the bytes from it, convert to string and output it to message box
        */
        private void UDPWork()
        {
            int listenPort;
            if (receiverTitle.Equals("SERVER")) listenPort = int.Parse(ucpFld.Text);
            else listenPort = int.Parse(uspFld.Text);

            UdpClient receiveSocket = new UdpClient(listenPort);
            IPEndPoint clientEP = new IPEndPoint(IPAddress.Any, listenPort);
            while (true)
            {
                byte[] bytes = receiveSocket.Receive(ref clientEP);
                String text = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                this.SetText(text);
            }
        }

    }
}

//Package of the project
package connections;

//Importing necessary libraries;
import javax.swing.text.*;
import java.net.*;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import graphicals.*;
import java.io.*;

/**
 * 
 * @author Mandeep Koirala
 * This class file has a setup for tcp server, client and udp server, client
 *
 */
public class Connection{
  //Setting up necessary variables and objects for the project
  private PrintWriter out = null;
  private JavaNet mainBlock;
  private int typeSC, typeTU;
  private ButtonHandler btnHandler = new ButtonHandler();
  
  //Variables for UDP Connection
  private InetAddress transmitUDP_IP;
  private int transmitUDP_PORT;
  private DatagramSocket socket;
 
  //Setting up emotions for the messages (JapaneseEmoticons, 2018)
  private String[][] emoji = { {":)","(｡◕‿◕｡)"}, {":/", "٩(╬ʘ益ʘ╬)۶"}, {":o", "☉_☉"}, {":*", " ♥ (*ε*) "}, {":tired", "(●´⌓`●)"},
  {":'(", "(-̩-̩__-̩-̩)"}, {":unsure", "\\_(ツ)_/¯"}, {":no","(ó.ò)"}, {":thinkhard", "♒((⇀‸↼))♒"}, {":love", "♥‿♥"},
  {":whaleface", "人◕ ‿‿ ◕人"}, {":bear", "ʕ•ᴥ•ʔ"}, {":happycat", "(=^ェ^=)"}, {":(", "﴾ -︵-﴿ "}, {":D", "[[laughs]]"}, 
  {":doubt", "(¬_¬)"}, {":hug", "(づ ◕‿◕ )づ"}, {";)", "(^_~) [[wink]]"}, {":sorry", "人"}, {":zz", "[[sleepy]]"},
  {":friends", "ヽ(⌒o⌒)人(⌒-⌒ )ﾉ"}, {":gun", "デ═一"}, {":magic", ":*:･ﾟ’★,｡･:*:"}, {":music", "♫•*¨*•.¸¸♪"},
  {":face", "( ͡° ͜ʖ ͡°)"}, {":goggle", "(⌐■_■)"}, {":drowning", "︵‿︵‿ヽ(°□°)ノ︵‿︵‿"}, {":rain", "｀、ヽ｀☂ヽ｀、"}
  };
  
  /*
   * Constructor for the class
   * Checks if the connection request is TCP or UDP and SERVER or CLIENT, and calls the respective setups accordingly
   */
  public Connection(int typeTU, int typeSC, JavaNet gui, JTextField portField, JTextField ipField, int listenUDPPort){
	  mainBlock = gui;
	  this.typeTU = typeTU;
	  this.typeSC = typeSC;
	  try {
		if (ipField != null) transmitUDP_IP = InetAddress.getByName(ipField.getText());
	  } catch (UnknownHostException e1) {
		e1.printStackTrace();
	  }
	  transmitUDP_PORT = Integer.parseInt(portField.getText());
	  gui.getSendButton().addActionListener(btnHandler);
	
	  //Creating a separate thread to run the setup code to prevent any freezing
	  Thread th = new Thread(new Runnable() {
		@Override
		public void run() {
			try {
				if (typeSC == JavaNet.SERVER_TYPE){
					// If connection is TCP Server, call tcpServer() method for setup
					if (typeTU == JavaNet.TCP) tcpServer(portField.getText());
					else{
						// If connection is UDP Server, call udp() method for setup
						udp(listenUDPPort, "CLIENT");				
					};
				}
				else{
					// If connection is TCP Client, call tcpClient() method for setup
					if (typeTU == JavaNet.TCP) tcpClient(portField.getText(), ipField.getText());
					else{
						// If connection is UDP Client, call udp() method for setup
						udp(listenUDPPort, "SERVER");
					}
				}
				
			} catch (IOException e) {
				JOptionPane.showMessageDialog(gui, "Connection Disconnected");
			}
		}
	});
	th.start(); // start a thread
  }

  /*
   * ButtonHandler class: Action Listener for send button
   */
  private class ButtonHandler implements ActionListener{
    public void actionPerformed(ActionEvent event){
      //Gets the sending text and output in message box
      String sendTextOutput = mainBlock.getMsg().getText();
      writeToChat("YOU", sendTextOutput, Color.blue);
      mainBlock.getMsg().setText("");
      
      // If connection is TCP, send the message through output stream
      if (typeTU == JavaNet.TCP) out.println(sendTextOutput);
      else{
    	  //If connection is UDP, convert message to bytes
    	  // then create a datagram socket & packet and send the packet through the socket
    	  try{
    		  DatagramSocket socket = new DatagramSocket();
    		  byte[] sendOutputByte = sendTextOutput.getBytes();
              DatagramPacket packet = new DatagramPacket (sendOutputByte, sendOutputByte.length, transmitUDP_IP, transmitUDP_PORT);
              socket.send(packet);
              socket.close(); // close socket
    	  }catch(Exception e){
    		  JOptionPane.showMessageDialog(mainBlock, "Error somwhere sending packet");
    	  }
      }
    }
  }

  /*
   * Appending text to message box using different color for different texts (java2s, 2018)
   */
  private void appendToPane(JTextPane tp, String msg, Color c){
    StyleContext sc = StyleContext.getDefaultStyleContext();
    AttributeSet aset = sc.addAttribute(SimpleAttributeSet.EMPTY, StyleConstants.Foreground, c);

    aset = sc.addAttribute(aset, StyleConstants.FontFamily, "Lucida Console");
    aset = sc.addAttribute(aset, StyleConstants.Alignment, StyleConstants.ALIGN_JUSTIFIED);

    int len = tp.getDocument().getLength();
    tp.setCaretPosition(len);
    tp.setCharacterAttributes(aset, false);
    tp.replaceSelection(msg);
  }

  /*
   * Creates a tcp server connection based on the configurations made
   */
  private void tcpServer(String port) throws IOException{
	// Creates a server socket
	ServerSocket serverSocket = new ServerSocket(Integer.parseInt(port));
	// Creates a socket to store receiving data
	Socket clientSocket = serverSocket.accept();
	
	// Sets out to a print writer for writing message to socket
    out = new PrintWriter(clientSocket.getOutputStream(), true);
    // Setting a buffered reader and reading data from the socket
    BufferedReader in = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
    
    String inputMessageLine;
    //Getting string from message data and writing it to message box
    while ((inputMessageLine = in.readLine ()) != null){
    	writeToChat("CLIENT", inputMessageLine, Color.red);
    }
    //closing sockets and packets
    out.close();
    in.close();
    clientSocket.close();
    serverSocket.close();
  }
    
  /*
   * Creates a tcp client connection based on the configurations made
   */
  private void tcpClient(String port, String ip) throws IOException{
    //Create a client socket
	Socket socket = new Socket (ip, Integer.parseInt(port));
    //Create a buffered reader to read input data
    BufferedReader in = new BufferedReader (new InputStreamReader (socket.getInputStream()));
    
    out = new PrintWriter(socket.getOutputStream (), true);
    
    String inputMessageLine;
    // Gets string from message data and writing it to message box
    while ((inputMessageLine = in.readLine ()) != null){
      writeToChat("SERVER", inputMessageLine, Color.red);
    }
    out.close();
    in.close();
    socket.close();
  } 
  /*
   * Creates a UDP connection based on the configurations made
   */
  private void udp(int listenPort, String name) throws IOException{
	  //Creates a listen socket
	  socket = new DatagramSocket(listenPort);
	  DatagramPacket packet; // creates a listen packet
      
	  /*
	   * Generate bytes from the received message and write it to the message box
	   */
      while (true){
          byte[] receiveByte = new byte[2048];
    	  packet = new DatagramPacket (receiveByte, receiveByte.length);
    	  socket.receive (packet); // receive packet
    	  String msg = new String(packet.getData());
    	  receiveByte = null;
    	  System.gc();
    	  writeToChat(name, msg, Color.red);
      }
  }
  
  /*
   * This method is used to write message to the message box by appending the text
   */
  private void writeToChat(String name, String text, Color userColor){
    text = text.trim();
	String[] word = text.split(" ");
    boolean written = false;
    appendToPane(mainBlock.getArea(), name + "   ", userColor);
    // Checking emojis in the text and make conversion to emoji accordingly
    for (String msg : word){
    	for (int i=0; i < emoji.length;i++){
    		if (msg.equals(emoji[i][0])){
    			written = true;
    			msg = msg.replace(emoji[i][0], emoji[i][1]);
    			appendToPane(mainBlock.getArea(), msg + " ", new Color(0, 175, 146));
    			break;
    		}else{
    			written = false;
    		}
    	}
    	if (!written) appendToPane(mainBlock.getArea(), msg + " ", Color.darkGray);
    }
    appendToPane(mainBlock.getArea(), "\n\n", Color.darkGray);
	word = null;
	System.gc();
  }
}

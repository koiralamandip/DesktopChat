//package of the file
package graphicals;

//importing necessary libraries
import java.awt.*;
import javax.swing.*;
import connections.*;
import java.net.*;
import java.util.Enumeration;

/**
 * 
 * @author Mandeep Koirala
 * @description This class file creates a Jframe for the project
 * 
 */

public class JavaNet extends JFrame{
	//Setting title for the project
	private String title = "Communication System: ";
	
	
	// Setting up necessary JPanels, JButtons, JTextPanes and JTexFields for the display
	private JPanel panelSettings, panelChat;
	private JButton sendBtn;
	private JTextPane chatArea;
	private JTextField sendMsg;
	
	// Creating an object of Connection class
	public Connection conn;
	
	// Setting up different constants
	public static final int SERVER_TYPE = 0;
	public static final int CLIENT_TYPE = 1;
	public static final int TCP = 0;
	public static final int UDP = 1;
	
	/*
	 * Constructor for the class
	 * Setup size, title and other attributes for the JFrame
	 */
	public JavaNet(){
		setTitle(title);
		setSize(800,600);
		setLocationRelativeTo(null);
		setDefaultCloseOperation(EXIT_ON_CLOSE);
		setResizable(false);
		setAlwaysOnTop(true);
		setLayout(new FlowLayout(FlowLayout.LEFT, 0,0));
		setComponents();
		setVisible(true);
	}
	
	
	/*
	 * This method creates and sets the components inside the the JFrame 
	 * The components are divided into left Settings and right ChatBox
	 * 
	 */
	private void setComponents(){
		panelSettings = new JPanel();
		panelSettings.setPreferredSize(new Dimension(304, 570));
		panelSettings.setLayout(new GridLayout(1, 1));
		add(panelSettings);
		
		panelChat = new JPanel();
		panelChat.setPreferredSize(new Dimension(490, 570));
		panelChat.setBorder(BorderFactory.createCompoundBorder(BorderFactory.createEtchedBorder(),BorderFactory.createEmptyBorder(5,5,5,5)));
		panelChat.setLayout(new BorderLayout());
		add(panelChat);
		
		setSettings(); // call this function setSettings();
		setChatBox(); // call this function setChatBox();
	}
	
	/*
	 * This method creates and sets components for settings options
	 */
	private void setSettings(){
		//Create a JTabbedPane with tabs for TCP Server, TCP CLient, UDP Server and UDP Client to show options accordingly
		JTabbedPane tuPane = new JTabbedPane(JTabbedPane.TOP, JTabbedPane.SCROLL_TAB_LAYOUT);
		//Setting font for JTabbedPane
		tuPane.setFont(new Font("Arial", 0, 10));
		
		//Adding tabs
		tuPane.add("TCP Server", setSettingSC(SERVER_TYPE, TCP));
		tuPane.addTab("TCP Client", setSettingSC(CLIENT_TYPE, TCP));
		tuPane.add("UDP Server", setSettingSC(SERVER_TYPE, UDP));
		tuPane.addTab("UDP Client", setSettingSC(CLIENT_TYPE, UDP));
		
		//Adding JtabbedPane to settings panel
		panelSettings.add(tuPane);
	}
	
	/*
	 * This method is used to display the interfaces and their associated IP addresses of the device (Oracle, 1195)
	*/
	public void getInterfaces(JPanel csPanel){
		try {
			//Getting all interfaces
			Enumeration<NetworkInterface> eNet = NetworkInterface.getNetworkInterfaces();
	    	while(eNet.hasMoreElements()){
	    		//Surfing through interfaces and getting IP addresses
	    		NetworkInterface netI = (NetworkInterface) eNet.nextElement();
	    		Enumeration<InetAddress> ei = netI.getInetAddresses();
	    		while (ei.hasMoreElements()){
	    			InetAddress ip = (InetAddress) ei.nextElement();
		    		if (ip.getClass().getSimpleName().equals("Inet4Address")){
		    			//If it is valid IP then display it to the user
		    			JLabel lblInterface= new JLabel(netI.getDisplayName());
		    			lblInterface.setFont(new Font("Arial", 0, 12));
		    			JLabel lblIP = new JLabel("IP address : " + ip.getHostAddress());
		    			csPanel.add(lblInterface);
		    			csPanel.add(lblIP);
		    		 }
	    		 }
	    	 }                
	     }catch (Exception e) {
	    	 e.printStackTrace();
	     }
	}

	/*
	 * This method is used to validate the port field
	 * Returns false if any error
	 */
	private boolean checkValidity(JTextField port){
		boolean ok = false;
		
		//If port Field is empty
		if (port.getText().equals("")){
			
		}
		// If port Field has no numbered data
		else if (!port.getText().matches("^[0-9]*$")){
			return false;
		}
		// If port number is greater than 65535 and less than 0
		else if ((Integer.parseInt(port.getText()) < 0 && Integer.parseInt(port.getText()) > 65535)){
			return false;
		}
		else{
			ok = true;
		}
		
		return ok;
	}
	
	/*
	 * This method is used to validate the port field and ip field
	 * Returns false if any error
	 */
	private boolean checkValidity(JTextField port, JTextField ip){
		boolean ok = false;
		// If fields are empty
		if (port.getText().equals("") || ip.getText().equals("")){
			return false; 
		}
		// If port data is not a number
		else if (!port.getText().matches("^[0-9]*$")){
			return false;
		}
		// If port number is < 0 and > 65535
		else if (Integer.parseInt(port.getText()) < 0 && Integer.parseInt(port.getText()) > 65535){
			return false;
		}
		// If ip address doesn't match the following pattern (mkyong, 2009)
		else if (!ip.getText().matches("^([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\." +
				"([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\." +
				"([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\." +
				"([01]?\\d\\d?|2[0-4]\\d|25[0-5])$")){
			return false;
		}
		else{
			ok = true;
		}
		
		return ok;
	}
	
	/*
	 * This method is used to create options inside each JTabbedPanes
	 * It shows necessary configuration inputs in respective tabs
	 */
	private JPanel setSettingSC(int typeSC, int typeTU){
		JPanel csPanel = new JPanel();
		csPanel.setLayout(new GridLayout(20, 1));
		csPanel.setBorder(BorderFactory.createEmptyBorder(5,5,5,5));
		
		//Setting up configuration elements
		JLabel portLabel = new JLabel();
		JTextField portField = new JTextField();
		JLabel ipLabel = new JLabel();
		JTextField ipField = new JTextField();
		JButton setupBtn = new JButton();
		// If the connection type is SERVER
		if (typeSC == SERVER_TYPE){
			// If it is TCP Server
			if (typeTU == TCP){
				//setup only TCP Server configurations
				portLabel.setText("Listen Port");
				setupBtn.setText("Setup TCP Server");
				setupBtn.addActionListener(e -> {
					// On clicking setup, if all validity is passes, create a TCP Server connection
					if (checkValidity(portField)){
						conn = new Connection(TCP, SERVER_TYPE, this, portField, null, 0);
						setTitle(title + "TCP Server");
					}else{
						JOptionPane.showMessageDialog(this, "Configuration error at some point!\nCannot establish TCP Server", "Erorr", 0);
					}
				});
			}else{
				// If it is UDP Server, setup only UDP Server configurations
				int listenPort = createReceiveUDPPort(); // create a random udp listen port
				setupBtn.setText("Setup UDP Server");
				setupBtn.addActionListener(e -> {
					// On clicking setup, if all validity is passes, create a UDP Server connection
					if (checkValidity(portField, ipField)){
						conn = new Connection(UDP, SERVER_TYPE, this, portField, ipField, listenPort);
						setTitle(title + "UDP Server");

					}else{
						JOptionPane.showMessageDialog(this, "Configuration error at some point!\nCannot establish UDP Server", "Erorr", 0);
					}
				});
				ipLabel.setText("Client IP");
				portLabel.setText("Transmit Port");
				csPanel.add(new JLabel("Listen Port:  " + String.valueOf(listenPort)));
				csPanel.add(ipLabel);
				csPanel.add(ipField);
			}
			
			//Add configurations to panel
			csPanel.add(portLabel);
			csPanel.add(portField);
			csPanel.add(new JLabel());
			csPanel.add(setupBtn);
			getInterfaces(csPanel); // call getInterfaces() method;
		}else{
			//If the connection type is CLient
			portLabel.setText("Transmit Port");
			ipLabel.setText("Server IP");
			
			//If it is TCP Client
			if (typeTU == TCP){
				setupBtn.setText("Setup TCP Client");
				setupBtn.addActionListener(e -> {
					// On clicking setup, if all validity is passes, create a TCP Client connection
					if (checkValidity(portField, ipField)){
						conn = new Connection(TCP, CLIENT_TYPE, this, portField, ipField, 0);
						setTitle(title + "TCP Client");
					}else{
						JOptionPane.showMessageDialog(this, "Configuration error at some point!\nCannot establish TCP Client", "Erorr", 0);
					}
				});
			}else{
				// If it is UDP Client
				int listenPort = createReceiveUDPPort(); // create a random udp listen port
				setupBtn.setText("Setup UDP Client");
				setupBtn.addActionListener(e -> {
					// On clicking setup, if all validity is passes, create a UDP Client connection
					if (checkValidity(portField, ipField)){
						conn = new Connection(UDP, CLIENT_TYPE, this, portField, ipField, listenPort);
						setTitle(title + "UDP Client");
					}else{
						JOptionPane.showMessageDialog(this, "Configuration error at some point!\nCannot establish UDP Client", "Erorr", 0);
					}
				});
				csPanel.add(new JLabel("Listen Port:  " + String.valueOf(listenPort)));
			}
			//Add configurations to panel
			csPanel.add(ipLabel);
			csPanel.add(ipField);
			csPanel.add(portLabel);
			csPanel.add(portField);
			csPanel.add(new JLabel());
			csPanel.add(setupBtn);
			getInterfaces(csPanel);
			
		}
		return csPanel;
	}
	
	// Generate a random UDP listen port for both client and server and return the number;
	private int createReceiveUDPPort(){
		int randomPort = (int) Math.round(Math.random() * 65535);
		return randomPort;
	}
	
	/*
	 * This method is used to create and set the components for the chatbox area
	 */
	private void setChatBox(){
		//create a textpane to show the messages
		chatArea = new JTextPane();
		
		JScrollPane chatPane = new JScrollPane(chatArea, JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED, JScrollPane.HORIZONTAL_SCROLLBAR_NEVER);
		
		JPanel msgSender = new JPanel();
		msgSender.setLayout(new BorderLayout());
		
		sendBtn = new JButton("Send");
		sendMsg = new JTextField();
		
		msgSender.add(sendMsg, BorderLayout.CENTER);
		msgSender.add(sendBtn, BorderLayout.EAST);
		
		panelChat.add(chatPane, BorderLayout.CENTER);
		panelChat.add(msgSender, BorderLayout.SOUTH);
	}
	
	//Getter for send button
	public JButton getSendButton(){
		return sendBtn;
	}
	
	//getter for chat area
	public JTextPane getArea(){
		return chatArea;
	}
	
	//getter for send message field
	public JTextField getMsg(){
		return sendMsg;
	}
	
	// Starting point
	public static void main(String[] args) {
		new JavaNet();
	}
}

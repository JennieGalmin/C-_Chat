
using System.Net;
using System.Net.Sockets;

public class Server{

public static void StartServer(){
    IPAddress ipAdress = new IPAddress(new byte[] {127, 0, 0, 1});
    IPEndPoint ipEndpoint = new IPEndPoint(ipAdress, 25500);

    Socket serverSocket = new Socket(
        ipAdress.AddressFamily,
        SocketType.Stream, 
        ProtocolType.Tcp
        );

    serverSocket.Bind(ipEndpoint);
    serverSocket.Listen();

    while(true){
        Socket client = serverSocket.Accept();
        Console.WriteLine($"username has logged in");
        // skriv in den som har loggat in!

        byte [] incoming = new byte [5000];
        int read = client.Receive(incoming);
        string request = System.Text.Encoding.UTF8.GetString(incoming, 0, read);

        Console.WriteLine($"Request: {request}");

    }
}
}
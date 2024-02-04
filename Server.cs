
using System.Net;
using System.Net.Sockets;
using MongoDB.Driver;

public class Server{
    private static List<Socket> clients = new List<Socket>();
    public static void StartServer(){
    IPAddress ipAddress = new IPAddress(new byte[] {127, 0, 0, 1});
    IPEndPoint ipEndpoint = new IPEndPoint(ipAddress, 25500);

    Socket serverSocket = new Socket(
        ipAddress.AddressFamily,
        SocketType.Stream, 
        ProtocolType.Tcp
        );
    // skapar en socket och kopplar till en viss ip address
    serverSocket.Bind(ipEndpoint);
    serverSocket.Listen();
    // så att den vet vilken ip address den ska lyssna till
    while(true){ //while loop för att kunna acceptera alla klienter
        Socket client = serverSocket.Accept();
        //för att kunna acceptera klienterna
        clients.Add(client);
       
        foreach(Socket c in clients){
            if( c != client){
                byte[] loginMessage = System.Text.Encoding.UTF8.GetBytes($"{username} har loggat in");
                c.Send(loginMessage);
            }
        // en loop för att gå igenom listan av klienter, om c inte är client kommer en meddelande ruta dyka upp 
        // för som andra som är inloggade
        // Behöver få in uername ist för client
        }

        byte [] incoming = new byte [5000];
        int read = client.Receive(incoming);
        string request = System.Text.Encoding.UTF8.GetString(incoming, 0, read);

        Console.WriteLine($"Request: {request}");

        string html = "<html><head></head><body><h1>Welcome to chat</h1></body></html>";
        string response = $"HTTP/1.1 200 OK\nConnection: close\nContent-type: text/html\n\n{html}";

        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(response);
        client.Send(buffer);
        client.Close();
    }
}
}
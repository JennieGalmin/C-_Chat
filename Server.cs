
using System.Net;
using System.Net.Sockets;
using MongoDB.Driver;


public class Server{
    private static List<Socket> clients = new List<Socket>();
    public static void StartServer(){

    IPAddress ipAddress = new IPAddress(new byte[] {127, 0, 0, 1});
    IPEndPoint ipEndpoint = new IPEndPoint(ipAddress, 25500);
    // skriver vilken ipAddress och Enpoint jag har valt

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
        Console.WriteLine("A Client has connected");

        clients.Add(client);
        // för att lägga till klienterna
       
        byte[] buffer = new byte [5000];
        // hämtar in bytes från klient
        int read = client.Receive(buffer);
        // sparar det i en variabel
        string credentials = System.Text.Encoding.UTF8.GetString(buffer, 0, read);
        // gör om svaret till en string (från bytes)
        string[] parts = credentials.Split(':');
        // sparar svaret i en array och splitar svaret
        string username = parts[0];
        // vill nå det första objektet i parts arrayen
        string response = $"Välkommen {username}";
        
        byte[] responseBuffer = System.Text.Encoding.UTF8.GetBytes(response);
        client.Send(responseBuffer);
        // skickar meddelandet till klienten
        client.Close();
        }
       
    }

}

using System.Net;
using System.Net.Sockets;
using MongoDB.Driver;


public class Server{
    private static List<Socket> clients = new List<Socket>();
    public static void StartServer(IMongoCollection<User> collection){

    var userCollection = collection; 
    Login login = new Login(userCollection);

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
        // för att lägga till kienterna
       
        byte [] incoming = new byte [5000];
        int read = client.Receive(incoming);
        string message = System.Text.Encoding.UTF8.GetString(incoming, 0, read);
        // gör så att bytes som kommer in från client blir till string format

        if( message != null){
            Console.WriteLine($"Request: {message}");
            string response = $"{login.GetUsername()} ";
                    // svaret i en string
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(response);   
            client.Send(buffer);  
            client.Close();   
        }
        
        }
       
    }

}
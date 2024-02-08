using System.Net;
using System.Net.Sockets;
using MongoDB.Driver;

public class Server{
    private static List<Socket> clients = new List<Socket>();
    public void StartServer(){

    UserRepository userRepository = new UserRepository();
    IMongoCollection<User> mongoCollection = userRepository.GetUserCollection();
    Login login = new Login(mongoCollection);
    
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

        Thread authThread = new Thread(()=>{
            login.AuthenticateClient(client);
        });
        authThread.Start();
        // Borde kunna logga in som klient nu..
       
    
        // startar en tråd som lyssnar på meddelanden från andra användare. 
        Thread receiveThread = new Thread((object usernameObj) => {
            string username = (string)usernameObj;
            while(true){
                byte[] messageBuffer = new byte[5000];
                int messageRead = client.Receive(messageBuffer);
                string message = System.Text.Encoding.UTF8.GetString(messageBuffer, 0, messageRead);

                byte[] sendMessageBuffer = System.Text.Encoding.UTF8.GetBytes($"{username}:{message}");
                foreach(Socket otherClients in clients){
                if(otherClients != client){
                string notification = $"{username} har loggat in!";
                byte[] notificationBuffer = System.Text.Encoding.UTF8.GetBytes(notification);
                otherClients.Send(notificationBuffer);
                otherClients.Send(sendMessageBuffer);
            }// foreach loop för att skicka meddelande till alla andra användare som är inloggade att en viss
            // user har loggat in
            }
            }
        });
        receiveThread.Start();
        //client.Close();
         } 
         }
       
    }


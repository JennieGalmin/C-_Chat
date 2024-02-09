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

    while(true){ //while loop för att kunna acceptera alla klienter (utan att programmet avslutas)

        if (serverSocket.Poll(0, SelectMode.SelectRead))
       { // en poll för att inte blocka koden
        Socket client = serverSocket.Accept();
        //för att kunna acceptera klienterna
        Console.WriteLine("A Client has connected");

        clients.Add(client);
        // för att lägga till klienterna
        Thread clientThread = new Thread(() =>
        HandleClient(client)
        // skrapar en tråd för inloggning
        );
        clientThread.Start();
            }
        }
       
        } 
        private void HandleClient(Socket client){
            UserRegistration userRegistration = new UserRegistration();

            while(true){
                if(client.Poll(0, SelectMode.SelectRead)){
                    byte[] buffer = new byte[1024];
                    int bytesRead = client.Receive(buffer);
                    string requestData = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
               
                string[] parts = requestData.Split(':');
                if(parts.Length != 2){
                Console.WriteLine("Du måste skriva in både användarnamn och lösenord");
                return;
                }
                string username = parts[0];
                string password = parts[1];
               
               Thread registerThread = new Thread(() =>
               {
                userRegistration.Register(client, username, password);
               
              
            
                string response = "Användare är nu registrerad";
                byte[] responseBuffer = System.Text.Encoding.UTF8.GetBytes(response);
                client.Send(responseBuffer);
                });
                
                registerThread.Start();
               } }
            }
        }
        
        
        
        
        
        
        
        
              
     
         

    


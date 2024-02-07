
using MongoDB.Driver;
using System.Net.Sockets;

public class Login{

    private readonly IMongoCollection<User> userCollection;
    public Login(IMongoCollection<User> userCollection){
        this.userCollection = userCollection;
    UserRepository userRepository = new UserRepository();
    userCollection = userRepository.GetUserCollection();
   
    
    }
    public bool AuthUser(string username, string password) {
        var usernameFilter = Builders<User>.Filter.Eq(u => u.Username, username);
        var passwordFilter = Builders<User>.Filter.Eq(u => u.Password, password);
        var combinedFilter = usernameFilter & passwordFilter;
        var user =  userCollection.Find(combinedFilter).FirstOrDefault();

        return user != null;
    }

     public void AuthenticateClient(Socket client){
   
   
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
        string password = parts[1];


        Login login = new Login(userCollection);

        bool isAuthUser = login.AuthUser(username, password);
        string response = $"Välkommen {username}";
        byte[] responseBuffer = System.Text.Encoding.UTF8.GetBytes(response);
        client.Send(responseBuffer);
        // skickar meddelandet till klienten
     }
     }

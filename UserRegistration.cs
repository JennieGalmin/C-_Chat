using MongoDB.Driver;
using System.Net.Sockets;
using System.Text;


public class UserRegistration{
    public void Register(Socket client){

    byte[] registerBuffer = new byte[1024];
    int bytesRead = client.Receive(registerBuffer);
    string requestData = Encoding.UTF8.GetString(registerBuffer, 0, bytesRead);

    string[] parts = requestData.Split(':');
    if(parts.Length != 2){
        Console.WriteLine("Du måste skriva in både användarnamn och lösenord");
        return;
    }
    string username = parts[0];
    string password = parts[1];

    UserRepository userRepository = new UserRepository();
    User AddNewUser = new User{Username = username, Password = password};
    userRepository.AddUser(AddNewUser);

    Console.WriteLine("Användaren har lagts till i databasen");
    }
}
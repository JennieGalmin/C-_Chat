using System.Net.Sockets;
using System.Text;



public class UserRegistration{
    public void Register(Socket client, string username, string password){

    byte[] registerBuffer = new byte[1024];
    int bytesRead = client.Receive(registerBuffer);
    string requestData = Encoding.UTF8.GetString(registerBuffer, 0, bytesRead);

    string[] parts = requestData.Split(':');
    if(parts.Length != 2){
        Console.WriteLine("Du måste skriva in både användarnamn och lösenord");
        return;
    }
  
    UserRepository userRepository = new UserRepository();
    User AddNewUser = new User{Username = username, Password = password};
    userRepository.AddUser(AddNewUser);

    string response = "Användare har registrerats";
    byte[] responseBuffer = Encoding.UTF8.GetBytes(response);
    client.Send(responseBuffer);
    }
}
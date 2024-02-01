public class UserRegistration{
    public static void Register(){
        Console.WriteLine("Skriv in nytt användarnamn");
        string? username = Console.ReadLine();

        Console.WriteLine("Skriv in nyy lösenord");
        string? password = Console.ReadLine();

        User newUser = new User
        {
            Username = username,
            Password = password
        };
        
        // userList.Add(newUser);

        Console.WriteLine("Ny användare är nu skapad");
    }
}
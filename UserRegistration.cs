public class UserRegistration{
    public static void Register(){
        Console.WriteLine("Skriv in nytt användarnamn");
        string? username = Console.ReadLine();

        Console.WriteLine("Skriv in nyy lösenord");
        string? password = Console.ReadLine();

        User newUser = new User
        // skapar en ny User som ska sparas i en lista i databasen
        {
            Username = username,
            Password = password
        };
        
        UserRepository.AddUser(newUser);

        Console.WriteLine("Ny användare är nu skapad");
    }
}
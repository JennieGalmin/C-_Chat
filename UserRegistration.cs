public class UserRegistration{
    public static void Register(){
        Console.WriteLine("Registrera användarnamn");
        string? username = Console.ReadLine();

        Console.WriteLine("Registrera lösenord");
        string? password = Console.ReadLine();

        User newUser = new User
        {
            Username = username,
            Password = password
        };
        UserRepository userRepository = new UserRepository();

        userRepository.AddUser(newUser);

        Console.WriteLine("Ny användare är nu skapad");
    }
}
using MongoDB.Driver;
using MongoDB.Driver.Core.Authentication;
using System;
using System.Collections.Generic;
using MongoDB.Bson;

public class UserRegistration{
    public static void Register(){
        Console.WriteLine("Välj användarnamn");
        string? username = Console.ReadLine();

        Console.WriteLine("Välj lösenord");
        string? password = Console.ReadLine();

        User newUser = new User
        // skapar en ny User som ska sparas i en lista i databasen
        {
            Username = username,
            Password = password
        };
        UserRepository repository = new UserRepository();
        // instans av UserRepository för att kunna lägga till newUser i den metoden
        repository.AddUser(newUser);
        // lägger till en ny användare i repositoryt. 
        Console.WriteLine("Ny användare är nu skapad");

        UserRepository userRepository = new UserRepository();
        IMongoCollection<User> mongoCollection = userRepository.GetUserCollection();
        MainMenu.Menu(mongoCollection);
        
    }
}
using MongoDB.Driver;
using MongoDB.Driver.Core.Authentication;
using System;
using System.Collections.Generic;
using MongoDB.Bson;


public class MainMenu{
    
    public static void Menu(IMongoCollection<User> userCollection){
        Console.WriteLine("Välkommen till C#_chat");

        Console.WriteLine("Vad vill du göra?");
        Console.WriteLine("1. Logga in");
        Console.WriteLine("2. Registrera användare");
        Console.WriteLine("3. Avsluta");

        string? choice = Console.ReadLine();

        if(choice == null){
            Console.WriteLine("Skriv in ditt val");
            return;
        }
        // if sats för om valet skulle vara blankt
        // fungerar ej!.
        
        switch(choice){

            case "1":
            Console.WriteLine("Du valde att logga in");
            Login login = new Login(userCollection);

            Console.WriteLine("Ange användarnamn");
            string? username = Console.ReadLine();

            Console.WriteLine("Ange ditt lösenord");
            string? password = Console.ReadLine();

            
            // ska in en if sats här för att antingen fortsätta applikationen eller 
            // felmeddelande om inlogg misslyckas
            break;

            case "2":
            Console.WriteLine("Du valde att registrera användare");
            UserRegistration.Register(); 
                   
            break;

            case "3":
            Console.WriteLine("Du valde att avsluta, hejdå!");
            Environment.Exit(0);
            break;
        }
        // Switch statement för att välja vad som ska hända för varje val

        
       
    }
}
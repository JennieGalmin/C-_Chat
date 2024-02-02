using System;
using MongoDB.Driver;
public class Login{
    private readonly IMongoCollection<User> userCollection;
    public Login(IMongoCollection<User> userCollection){
        this.userCollection = userCollection;
    }
    
    public bool AuthUser(string username, string password) {
        var usernameFilter = Builders<User>.Filter.Eq(u => u.Username, username);
        var passwordFilter = Builders<User>.Filter.Eq(u => u.Password, password);
        var combinedFilter = usernameFilter & passwordFilter;
        var user =  userCollection.Find(combinedFilter).FirstOrDefault();

        // när jag loggar in med en användare får jag formatexaptionfel
        

        if(user != null && password != null){
            Console.WriteLine($"Välkommen {username}");
            return true;
        } else {
            Console.WriteLine("Ogiltlig inloggning, försök igen");
            return false;
        }
    }
     
    }

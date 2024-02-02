

using MongoDB.Bson;

public class User : IUser
{
    public ObjectId Id {get; set;} 
    public string Username {get; set;} = string.Empty;
    public string Password {get; set;} = string.Empty;
}

// En klass för att hämta Interfacet IUser, för att kunna 
// använda det i klasser
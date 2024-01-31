using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public interface IUser
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]

    
    string Username {get; set;}
    string Password {get; set;}
}

//Interface för användare för att kunna ha en flexibel kod.


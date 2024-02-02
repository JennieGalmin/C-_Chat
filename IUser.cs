
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public interface IUser
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
   
    ObjectId Id  {get; set;}
    string Username {get; set;}
    string Password {get; set;}
}

//Interface för användare för att kunna ha en flexibel kod.


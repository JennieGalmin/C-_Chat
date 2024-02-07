using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

public class UserRepository{

    private readonly IMongoCollection<User> userCollection;
    private IMongoDatabase database;
    private MongoClient mongoClient;

    public UserRepository()
    {
        this.mongoClient = new MongoClient("mongodb://localhost:27017");
        this.database = this.mongoClient.GetDatabase("mongo");
        this.userCollection = this.database.GetCollection<User>("Users");
        // Kopplar till databasen
    }

    public IMongoCollection<User> GetUserCollection()
    {
        return userCollection;
    }
        public  void AddUser(User user)
    {
        userCollection.InsertOne(user);
    }

    }
    
    
    // Här läggs användarna till i databasen

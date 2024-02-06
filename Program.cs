﻿using System.Reflection.Metadata;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Gruppuppgift;

class Program
{
    static void Main(string[] args)
    {
        UserRepository userRepository = new UserRepository();
        IMongoCollection<User> mongoCollection = userRepository.GetUserCollection();
        //MainMenu.Menu(mongoCollection);

        Server.StartServer();
    }
}

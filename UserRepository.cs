using System;
using System.Collections.Generic;

public class UserRepository{

    private static List<User> userList = new List<User>();
    // Skapar en lista som heter userList dit användarna sparas
    public static void AddUser(User user)
    {
        userList.Add(user);
    }
    // Här läggs användarna till i listan
}
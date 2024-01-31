public class User : IUser
{

    public string Username {get; set;} = string.Empty;
    public string Password {get; set;} = string.Empty;
}

// En klass för att hämta Interfacet IUser, för att unna använda det i Login klassen.
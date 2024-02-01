
public class Login{
    public static void Start(){

        IUser user = new User();
    // Skapa en ny anävändare

            string? userName = null;
            string? passWord = null;
            bool isLoggedIn = false;

            // Deklarerar användare och lösenord

            while(!isLoggedIn){
            // En While loop så länge man inte är inloggad kommer dessa meddelanden upp
                Console.WriteLine("Skriv in ditt användarnamn:");
                userName = Console.ReadLine();
               
               Console.WriteLine("Skriv in ditt lösenord:");
                passWord = Console.ReadLine();

               if(!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(passWord)){
            // Om användare och lösenord inte är tomma tillsätts värdet som skrevs och
            // programmet hälsar användaren välkommen
                    user.Username = userName;
                    user.Password = passWord;
                    
                    Console.WriteLine($"Välkommen {user.Username}");
                    isLoggedIn = true;
                    break;
                    
               } else {
                Console.WriteLine("Du måste skriva något!");
               }

               
            }

    }
}
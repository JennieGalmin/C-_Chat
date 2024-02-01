public class MainMeny{
    public static void Meny(){
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
            Login.Start();
            break;

            case "2":
            Console.WriteLine("Du valde att registrera användare");
            UserRegistration.Register(); 
            Meny();         
            break;

            case "3":
            Console.WriteLine("Du valde att ansluta, hejdå!");
            Environment.Exit(0);
            break;
        }
        // Switch statement för att välja vad som ska hända för varje val

        
       
    }
}
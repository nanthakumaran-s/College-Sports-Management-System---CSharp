using System.Security.Cryptography.X509Certificates;

public class Player
{
    public void AddPlayer(SQLQueries queries)
    {
        Console.Write("Name of the Player: ");
        string name = Console.ReadLine()!;
        Console.Write("Age of the Player: ");
        int age = int.Parse(Console.ReadLine()!);
        queries.ViewSports();
        Console.Write("ID of the sport the player is associated: ");
        int id = int.Parse(Console.ReadLine()!);
        bool response = queries.AddPlayer(name, age, id);
        if (response)
        {
            Console.WriteLine("Player Added");
        }
        return;
    }

    public void ViewPlayers(SQLQueries queries)
    {
        queries.ViewPlayers();
        return;
    }

    public void RemovePlayer(SQLQueries queries)
    {
        ViewPlayers(queries);
        Console.Write("ID of the player that you need to remove: ");
        int id = int.Parse(Console.ReadLine()!);
        bool response = queries.RemovePlayer(id);
        if (response)
        {
            Console.WriteLine("Player Removed");
        }
        return;
    }
} 
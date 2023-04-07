public class Tournament
{
    public void AddTournament(SQLQueries queries)
    {
        Console.Write("Name of the Tournament: ");
        string name = Console.ReadLine()!;
        Console.WriteLine(
            "What is the tournament type\n" +
            "1. Intra College\n" +
            "2. University"
        );
        int type = int.Parse(Console.ReadLine()!);
        queries.ViewSports();
        Console.WriteLine("What are the sports associated with this tournament? Enter IDs separate them with space");
        List<string> sports = Console.ReadLine()!.Split(" ").ToList();
        bool response = queries.AddTournament(name, type == 1 ? "Intra College" : "University", sports);
        if (response)
        {
            Console.WriteLine("Tournament Added");
        }
        return;
    }

    public void ViewTournament(SQLQueries queries)
    {
        queries.ViewTournament();
        return;
    }

    public void RemoveTournament(SQLQueries queries)
    {
        ViewTournament(queries);
        Console.Write("ID of the Tournament that you need to remove: ");
        int id = int.Parse(Console.ReadLine()!);
        bool response = queries.RemoveTournament(id);
        if (response)
        {
            Console.WriteLine("Tournament Removed");
        }
        return;
    }

    public void RegisterTournament(SQLQueries queries)
    {
        queries.ViewTournament();
        Console.Write("ID of the Tournament that you need to register players for: ");
        int id = int.Parse(Console.ReadLine()!);
        queries.ViewPlayers();
        Console.WriteLine("Who are all the players associated with this tournament? Enter IDs separate them with space");
        List<string> players = Console.ReadLine()!.Split(" ").ToList();
        bool response = queries.RegisterTournament(id, players);
        if (response)
        {
            Console.WriteLine("Players Registered");
        }
        return;
    }
}
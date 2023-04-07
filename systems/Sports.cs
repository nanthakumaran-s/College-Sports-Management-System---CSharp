public class Sports
{
    public void AddSport(SQLQueries queries)
    {
        Console.Write("What is the name of the sport: ");
        string sportName = Console.ReadLine()!;
        Console.WriteLine(
            "What is the sport type\n" +
            "1. Solo\n" +
            "2. Group"
        );
        int sportType = int.Parse(Console.ReadLine()!);
        bool response = queries.AddSport(sportName, sportType == 1 ? "Solo" : "Group");
        if (response)
        {
            Console.WriteLine("Sport Added");
        }
        return;
    }

    public void ViewSports(SQLQueries queries)
    {
        queries.ViewSports();
        return;
    }

    public void RemoveSport(SQLQueries queries)
    {
        ViewSports(queries);
        Console.Write("ID of the sport that you need to remove: ");
        int id = int.Parse(Console.ReadLine()!);
        bool response = queries.RemoveSport(id);
        if (response)
        {
            Console.WriteLine("Sport Removed");
        }
        return;
    }
}
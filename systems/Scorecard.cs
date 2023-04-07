public class Scorecard
{
    public void AddScoreCard(SQLQueries queries) {
        queries.ViewTournament();
        Console.Write("For which tournament you need the scorecard, mention the ID: ");
        int tournamentID = int.Parse(Console.ReadLine()!);
        queries.ViewPlayers();
        Console.WriteLine("The match is between whom, mention the IDs separated by a space");
        List<string> playerIDs = Console.ReadLine()!.Split(" ").ToList();
        bool response = queries.AddScoreCard(tournamentID, playerIDs);
        if (response)
        {
            Console.WriteLine("Score card added");
        }
        return;
    }

    public void ViewScorecard(SQLQueries queries)
    {
        queries.ViewScoreCard();
        return;
    }

    public void RemoveScorecard(SQLQueries queries)
    {
        ViewScorecard(queries);
        Console.Write("ID of the scorecard that you need to remove: ");
        int id = int.Parse(Console.ReadLine()!);
        bool response = queries.RemoveScorecard(id);
        if (response)
        {
            Console.WriteLine("Scorecard Removed");
        }
        return;
    }

    public void UpdateScorecard(SQLQueries queries)
    {
        ViewScorecard(queries);
        Console.WriteLine("ID of the scorecard that you need to update");
        int id = int.Parse(Console.ReadLine()!);
        Console.Write("Score 1: ");
        int score1 = int.Parse(Console.ReadLine()!);
        Console.Write("Score 2: ");
        int score2 = int.Parse(Console.ReadLine()!);
        bool response = queries.UpdateScorecard(score1, score2, id);
        if (response) {
            Console.WriteLine("Updated the scorecard");
        }
    }
}
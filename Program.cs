namespace SportsManagement
{
    public class Program
    {
        public static SQLQueries queries = null;
        public static void Main(string[] args)
        {
            queries = new SQLQueries();
            Console.WriteLine("Hello Director!!!");
            while (true)
            {
                Console.WriteLine("Choose an Option");
                Console.WriteLine(
                    "1. Sports\n" +
                    "2. Players\n" +
                    "3. Tournaments\n" +
                    "4. Scorecard\n" +
                    "5. Exit");
                Console.WriteLine();
                int userInput = int.Parse(Console.ReadLine()!);
                if (userInput == 5)
                {
                    break;
                }

                switch (userInput)
                {
                    case 1:
                        SportsSystem();
                        break;
                    case 2:
                        PlayersSystem();
                        break;
                    case 3:
                        TournamentsSystem();
                        break;
                    case 4:
                        ScorecardSystem();
                        break;
                    default:
                        break;
                }
            }
        }

        public static void SportsSystem()
        {
            Console.WriteLine("Sports System Started");
            Sports sportSystem = new Sports();
            while (true)
            {
                Console.WriteLine("Choose an Option");
                Console.WriteLine(
                    "1. Add Sport\n" +
                    "2. View Sports\n" +
                    "3. Remove Sport\n" +
                    "4. Exit");
                Console.WriteLine();
                int userInput = int.Parse(Console.ReadLine()!);
                if (userInput == 4)
                {
                    break;
                }
                
                switch (userInput)
                {
                    case 1:
                        sportSystem.AddSport(queries);
                        break;
                    case 2:
                        sportSystem.ViewSports(queries);
                        break;
                    case 3:
                        sportSystem.RemoveSport(queries);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Sports System Ended");
            Console.WriteLine();
        }

        public static void PlayersSystem()
        {
            Console.WriteLine("Players System Started");
            Player playerSystem = new Player();
            while (true)
            {
                Console.WriteLine("Choose an Option");
                Console.WriteLine(
                    "1. Register Player\n" +
                    "2. Remove Player\n" +
                    "3. View Players\n" +
                    "4. Exit");
                Console.WriteLine();
                int userInput = int.Parse(Console.ReadLine()!);
                if (userInput == 4)
                {
                    break;
                }
                switch (userInput)
                {
                    case 1:
                        playerSystem.AddPlayer(queries);
                        break;
                    case 2:
                        playerSystem.RemovePlayer(queries);
                        break;
                    case 3:
                        playerSystem.ViewPlayers(queries);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Players System Ended");
            Console.WriteLine();
        }

        public static void TournamentsSystem()
        {
            Console.WriteLine("Tournaments System Started");
            Tournament tournament = new Tournament();
            while (true)
            {
                Console.WriteLine("Choose an Option");
                Console.WriteLine(
                    "1. Add Tournament\n" +
                    "2. View Tournaments\n" +
                    "3. Remove Tournaments\n" +
                    "4. Register Player\n" +
                    "5. Make Payment\n" +
                    "6. Exit");
                Console.WriteLine();
                int userInput = int.Parse(Console.ReadLine()!);
                if (userInput == 6)
                {
                    break;
                }
                switch (userInput)
                {
                    case 1:
                        tournament.AddTournament(queries);
                        break;
                    case 2:
                        tournament.ViewTournament(queries);
                        break;
                    case 3:
                        tournament.RemoveTournament(queries);
                        break;
                    case 4: 
                        tournament.RegisterTournament(queries);
                        break;
                    case 5:
                        tournament.Pay(queries);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Tournaments System Ended");
            Console.WriteLine();
        }

        public static void ScorecardSystem()
        {
            Console.WriteLine("Scorecard System Started");
            Scorecard scorecard = new Scorecard();
            while (true)
            {
                Console.WriteLine("Choose an Option");
                Console.WriteLine(
                    "1. Add Scorecard\n" +
                    "2. Edit Scorecard\n" +
                    "3. View Scorecards\n" +
                    "4. Remove Scorecard\n" +
                    "5. Exit");
                Console.WriteLine();
                int userInput = int.Parse(Console.ReadLine()!);
                if (userInput == 5)
                {
                    break;
                }
                switch (userInput)
                {
                    case 1:
                        scorecard.AddScoreCard(queries);
                        break;
                    case 2:
                        scorecard.UpdateScorecard(queries);
                        break;
                    case 3:
                        scorecard.ViewScorecard(queries);
                        break;
                    case 4:
                        scorecard.RemoveScorecard(queries);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Scorecard System Ended");
            Console.WriteLine();
        }
    }
}
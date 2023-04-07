using Azure;
using Microsoft.Data.SqlClient;
using System.Reflection.PortableExecutable;
using static System.Formats.Asn1.AsnWriter;

public class SQLQueries
{
    SqlConnection client = null;
    string connString = "Data Source=localhost;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False; Initial Catalog = collegeSportsManagementSystem;";

    public SQLQueries()
    {
        client = new SqlConnection(connString);
        client.Open();
        Console.WriteLine("Connected");
    }

    ~SQLQueries()
    {
        client.Close();
        Console.WriteLine("Closed");
    }

    // Sports Queries
    public bool AddSport(string sportName, string typeOfSport)
    {
        try
        {
            SqlCommand cmd = client.CreateCommand();
            cmd.CommandText = "INSERT INTO dbo.Sport VALUES ('" + sportName+ "', '" + typeOfSport + "');";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            return true;
        } catch (Exception e)
        {
            Console.WriteLine("Some Error Occured While Adding Sport. " + e.ToString());
            return false;
        }
    }

    public void ViewSports()
    {
        try
        {
            SqlCommand cmd = client.CreateCommand();
            cmd.CommandText = "SELECT * FROM Sport;";
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i] + " ");
                }
                Console.WriteLine();
            }
            reader.Close();
            Console.WriteLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Some Error Occured While Viewing Sports. " + e.ToString());
        }
    }

    public bool RemoveSport(int id)
    {
        try
        {
            SqlCommand cmd = client.CreateCommand();
            cmd.CommandText = "DELETE FROM dbo.Sport WHERE id = " + id  + " ;";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Some Error Occured While Removing Sport. " + e.ToString());
            return false;
        }
    }

    // Player Queries
    public bool AddPlayer(string name, int age, int id)
    {
        try
        {
            SqlCommand cmd = client.CreateCommand();
            cmd.CommandText = $"INSERT INTO dbo.Player VALUES ('{name}', {age}, {id});";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Some Error Occured While Adding Player. " + e.ToString());
            return false;
        }
    }

    public void ViewPlayers()
    {
        try
        {
            SqlCommand cmd = client.CreateCommand();
            cmd.CommandText = "SELECT * FROM Player p INNER JOIN Sport s ON s.id = p.sport;";
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i] + " ");
                }
                Console.WriteLine();
            }
            reader.Close();
            Console.WriteLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Some Error Occured While Viewing Players. " + e.ToString());
        }
    }

    public bool RemovePlayer(int id)
    {
        try
        {
            SqlCommand cmd = client.CreateCommand();
            cmd.CommandText = "DELETE FROM dbo.Player WHERE id = " + id + " ;";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Some Error Occured While Removing Player. " + e.ToString());
            return false;
        }
    }

    // Tournament Queries
    public bool AddTournament(string name, string type, List<string> sports)
    {
        try
        {
            SqlCommand cmd = client.CreateCommand();
            cmd.CommandText = $"INSERT INTO dbo.Tournament VALUES ('{name}', '{type}');";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            cmd.CommandText = $"SELECT * FROM dbo.Tournament WHERE name = '{name}'";
            reader = cmd.ExecuteReader();
            int tournamentID = -1;
            while(reader.Read())
            {
                tournamentID = (int) reader[0];
            }
            reader.Close();
            for (int i = 0; i < sports.Count; i++)
            {
                cmd.CommandText = $"INSERT INTO dbo.MapTournamentWithSport VALUES ({tournamentID}, {int.Parse(sports[i])})";
                reader = cmd.ExecuteReader();
                reader.Close();
            }
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Some Error Occured While Adding Tournament. " + e.ToString());
            return false;
        }
    }

    public void ViewTournament()
    {
        try
        {
            SqlCommand cmd = client.CreateCommand();
            cmd.CommandText = "SELECT * FROM dbo.Tournament;";
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i] + " ");
                }
                Console.WriteLine();
            }
            reader.Close();
            Console.WriteLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Some Error Occured While Viewing Tournament. " + e.ToString());
        }
    }

    public bool RemoveTournament(int id)
    {
        try
        {
            SqlCommand cmd = client.CreateCommand();
            cmd.CommandText = "DELETE FROM dbo.Tournament WHERE id = " + id + " ;";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Some Error Occured While Removing Tournament. " + e.ToString());
            return false;
        }
    }

    public bool RegisterTournament(int id, List<string> players)
    {
        SqlCommand cmd = client.CreateCommand();
        SqlDataReader reader;
        for (int i = 0; i < players.Count; i++)
        {
            cmd.CommandText = $"INSERT INTO dbo.MapTournamentWithPlayer VALUES ({id}, {int.Parse(players[i])})";
            reader = cmd.ExecuteReader();
            reader.Close();
        }
        return true;
    }

    // Scorecard Queries
    public bool AddScoreCard(int tournamentID, List<string> players)
    {
        try
        {
            SqlCommand cmd = client.CreateCommand();
            cmd.CommandText = $"INSERT INTO dbo.Scorecard VALUES (0, 0, {int.Parse(players[0])}, {int.Parse(players[1])})";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            cmd.CommandText = $"SELECT * FROM dbo.Scorecard WHERE player1ID = '{int.Parse(players[0])}' AND player2ID = {int.Parse(players[1])}";
            reader = cmd.ExecuteReader();
            int scoreCardID = -1;
            while (reader.Read())
            {
                scoreCardID = (int)reader[0];
            }
            reader.Close();
            cmd.CommandText = $"INSERT INTO dbo.MapTournamentWithScorecard VALUES ({scoreCardID}, {tournamentID})";
            reader = cmd.ExecuteReader();
            reader.Close();
            return true;

        } catch (Exception e) { 
            Console.WriteLine("Some Error Occured While Adding Scorecard. " + e.ToString()); 
            return false; 
        }
    }

    public void ViewScoreCard()
    {
        try
        {
            SqlCommand cmd = client.CreateCommand();
            cmd.CommandText = "SELECT * FROM dbo.Scorecard;";
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i] + " ");
                }
                Console.WriteLine();
            }
            reader.Close();
            Console.WriteLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Some Error Occured While Viewing Score card. " + e.ToString());
        }
    }

    public bool RemoveScorecard(int id)
    {
        try
        {
            SqlCommand cmd = client.CreateCommand();
            cmd.CommandText = "DELETE FROM dbo.Scorecard WHERE id = " + id + " ;";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Some Error Occured While Removing Scorecard. " + e.ToString());
            return false;
        }
    }

    public bool UpdateScorecard(int score1, int score2, int id)
    {
        try
        {
            SqlCommand cmd = client.CreateCommand();
            cmd.CommandText = $"UPDATE Scorecard SET scoreA = {score1}, scoreB = {score2} WHERE id = {id};";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Some Error Occured While Updating Scorecard. " + e.ToString());
            return false;
        }
    }

    // Payment
    public bool Payment(int tournamentId, int playerID)
    {
        try
        {
            SqlCommand cmd = client.CreateCommand();
            cmd.CommandText = $"UPDATE MapTournamentWithPlayer SET paymentStatus = 'Paid' WHERE tournamentID = {tournamentId} AND playerID = {playerID};";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Some Error Occured While Payment. " + e.ToString());
            return false;
        }
    } 
}

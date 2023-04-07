using Azure;
using Microsoft.Data.SqlClient;
using System.Reflection.PortableExecutable;

public class SQLQueries
{
    SqlConnection client = null;
    public void Connect()
    {
        string connString = "Data Source=localhost;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False; Initial Catalog = collegeSportsManagementSystem;";
        try
        {
            client = new SqlConnection(connString);
            client.Open();
            Console.WriteLine("Connected");
        } catch (Exception e)
        {
            Console.WriteLine("Some Error Occured While Connecting to the Database. The error is: " + e.ToString());
        }
    }

    public void Close()
    {
        try
        {
            client.Close();
            Console.WriteLine("Closed");
        } catch (Exception e)
        {
            Console.WriteLine("Some Error Occured While Connecting to the Database. The error is: " + e.ToString());
        }
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
}

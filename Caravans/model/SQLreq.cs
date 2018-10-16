using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Caravans.model
{
    class SQLreq
    {
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CaravansDB.mdf;Integrated Security=True";

        internal void Status()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("\n-- Opened --\n");

                Console.WriteLine("Connection properties:");
                Console.WriteLine("\tConnection String: {0}", connection.ConnectionString);
                Console.WriteLine("\tDatabase: {0}", connection.Database);
                Console.WriteLine("\tServer: {0}", connection.DataSource);
                Console.WriteLine("\tServer Version: {0}", connection.ServerVersion);
                Console.WriteLine("\tState: {0}", connection.State);
                Console.WriteLine("\tWorkstation ld: {0}", connection.WorkstationId);

            }
            Console.WriteLine("\n-- Closed --\n");
        }

        
        //Czytanie dadych z tabeli do Modelu
        internal void ReadLocsToMod(List<TableLoc> Location)
        {
            string Comm = "SELECT * FROM Locs";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Comm, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read()) //Read by lines
                    {
                        object id = reader.GetValue(0).ToString();
                        object Name = reader.GetValue(1).ToString();

                        Location.Add(new TableLoc(id.ToString(), Name.ToString()));
                    }
                }
            }
        }
        internal void ReadArticleToMod(List<TableArticle> Article)
        {
            string Comm = "SELECT * FROM Article";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Comm, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read()) //Read by lines
                    {
                        object id = reader.GetValue(0).ToString();
                        object Name = reader.GetValue(1).ToString();
                        object Price = reader.GetValue(2).ToString();
                        object Prod = reader.GetValue(3).ToString();
                        object Req = reader.GetValue(4).ToString();

                        Article.Add(new TableArticle(id.ToString(), Name.ToString(), Convert.ToInt32(Price), Convert.ToInt32(Prod), Convert.ToInt32(Req)));
                    }
                }
            }
        }
        internal void ReadStateToMod(List<TableState> State)
        {
            string Comm = "SELECT * FROM State";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Comm, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read()) //Read by lines
                    {
                        object id = reader.GetValue(0).ToString();
                        object Name = reader.GetValue(1).ToString();
                        object Description = reader.GetValue(2).ToString();

                        State.Add(new TableState(id.ToString(), Name.ToString(), Description.ToString()));
                    }
                }
            }
        }
        internal void ReadRoadsToMod(List<TableRoad> Road)
        {
            string sqlSelect = "SELECT * FROM Roads";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlSelect, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read()) //Read by lines
                    {
                        object id = reader.GetValue(0);
                        object idLoc1 = reader.GetValue(1);
                        object idLoc2 = reader.GetValue(2);
                        object Length = reader.GetValue(3);
                        object Name = reader.GetValue(4);

                        Road.Add(new TableRoad(id.ToString(), idLoc1.ToString(), idLoc2.ToString(), Convert.ToInt32(Length), Convert.ToInt32(Name)));
                    }
                }
            }
        }
        internal void ReadTownToMod(List<TableTown> Town)
        {
            string sqlSelect = "SELECT * FROM Town";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlSelect, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read()) //Read by lines
                    {
                        object id = reader.GetValue(0);
                        object Name = reader.GetValue(1);
                        object Population = reader.GetValue(2);
                        object IdLoc = reader.GetValue(3);
                        object Military = reader.GetValue(4);
                        object Prosperity = reader.GetValue(5);
                        object Food = reader.GetValue(6);

                        Town.Add(new TableTown(id.ToString(), Name.ToString(), Convert.ToInt32(Population), IdLoc.ToString(), Convert.ToInt32(Military), Convert.ToInt32(Prosperity), Convert.ToInt32(Food)));
                    }
                }
            }
        }
        internal void ReadCaravanToMod(List<TableCaravan> Caravan)
        {
            string sqlSelect = "SELECT * FROM Caravan";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlSelect, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read()) //Read by lines
                    {
                        object id = reader.GetValue(0);
                        object IdLoc = reader.GetValue(1);
                        object Wagons = reader.GetValue(2);
                        object Guard = reader.GetValue(3);
                        object Duration = reader.GetValue(4);
                        object Minions = reader.GetValue(5);

                        Caravan.Add(new TableCaravan(id.ToString(), IdLoc.ToString(), Convert.ToInt32(Wagons), Convert.ToInt32(Guard), Convert.ToInt32(Duration), Convert.ToInt32(Minions)));
                    }
                }
            }
        }
        internal void ReadTownStateToMod(List<TableTownState> TownState)
        {
            string sqlSelect = "SELECT * FROM Town_State";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlSelect, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read()) //Read by lines
                    {
                        object id = reader.GetValue(0);
                        object IdState = reader.GetValue(1);
                        object Duration = reader.GetValue(2);

                        TownState.Add(new TableTownState(id.ToString(), IdState.ToString(), Convert.ToInt32(Duration)));
                    }
                }
            }
        }
        internal void ReadArtInCaravanToMod(List<TableArtInCaravan> ArtInCaravan)
        {
            string sqlSelect = "SELECT * FROM Art_in_Caravan";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlSelect, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read()) //Read by lines
                    {
                        object id = reader.GetValue(0);
                        object IdArticle = reader.GetValue(1);
                        object Number = reader.GetValue(2);

                        ArtInCaravan.Add(new TableArtInCaravan(id.ToString(), IdArticle.ToString(), Convert.ToInt32(Number)));
                    }
                }
            }
        }
        internal void ReadArtInTownToMod(List<TableArtInTown> ArtInTown)
        {
            string sqlSelect = "SELECT * FROM Art_in_Town";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlSelect, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read()) //Read by lines
                    {
                        object id = reader.GetValue(0);
                        object IdArticle = reader.GetValue(1);
                        object Number = reader.GetValue(2);
                        object Requisition = reader.GetValue(3);
                        object Production = reader.GetValue(4);

                        ArtInTown.Add(new TableArtInTown(id.ToString(), IdArticle.ToString(), Convert.ToInt32(Number), Convert.ToInt32(Requisition), Convert.ToInt32(Production)));
                    }
                }
            }
        }
        internal void ReadResourcesToMod(out int Gold, out int Turn)
        {
            Gold = 0;
            Turn = 0;
            string sqlSelect = "SELECT * FROM Resources";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlSelect, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read()) //Read by lines
                    {
                        object id = reader.GetValue(0);
                        object GoldDB = reader.GetValue(1);
                        object TurnDB = reader.GetValue(2);

                        Gold = Convert.ToInt32(GoldDB);
                        Turn = Convert.ToInt32(TurnDB);
                    }
                }
            }
        }


        //Truncate tables

        internal void TruncateTownState()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (SqlException se)
            {
                return;
            }

            SqlCommand delete = new SqlCommand("TRUNCATE table Town_State", conn);
            try
            {
                delete.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                return;
            }
        }
        internal void TruncateCaravan()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (SqlException se)
            {
                return;
            }

            SqlCommand AlterDrop = new SqlCommand("ALTER TABLE Art_in_Caravan DROP CONSTRAINT FK_Art_in_Caravan_ToCaravan;", conn);
            try
            {
                AlterDrop.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                return;
            }

            //truncate Caravan
            SqlCommand Truncate = new SqlCommand("TRUNCATE table Caravan;", conn);
            try
            {
                Truncate.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                return;
            }

            SqlCommand AlterAdd = new SqlCommand("ALTER TABLE Art_in_Caravan WITH NOCHECK ADD CONSTRAINT FK_Art_in_Caravan_ToCaravan FOREIGN KEY (IdCaravan) REFERENCES Caravan (IdCaravan);", conn);
            try
            {
                AlterAdd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                return;
            }
        }
        internal void TruncateArtInCaravan()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (SqlException se)
            {
                return;
            }

            //truncate Art_in_Caravan
            SqlCommand Truncate = new SqlCommand("TRUNCATE table Art_in_Caravan;", conn);
            try
            {
                Truncate.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                Console.WriteLine("Error while TRUNCATE Art_in_Caravan: {0}", se.Message);
                return;
            }
        }

        //Update tables

        internal void UpdateTown(TableTown Town)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (SqlException se)
            {
                return;
            }
            SqlCommand cmd = new SqlCommand("Update Town" + " Set Name = @Name, Population = @Population, IdLoc = @IdLoc, Military = @Military, Prosperity = @Prosperity, Food = @Food where IdTown = @IdTown", conn);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@Name";
            param.Value = Town.GetName();
            param.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Population";
            param.Value = Town.GetPopulation();
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@IdLoc";
            param.Value = Town.GetIdLoc();
            param.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Military";
            param.Value = Town.GetMilitary();
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Prosperity";
            param.Value = Town.GetProsperity();
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Food";
            param.Value = Town.GetFood();
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@IdTown";
            param.Value = Town.GetId();
            param.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(param);
            
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                return;
            }
            conn.Close();
            conn.Dispose();
        }
        internal void UpdateCaravan(TableCaravan Caravan)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (SqlException se)
            {
                return;
            }

            SqlCommand cmd = new SqlCommand("Insert into Caravan" + "(IdCaravan, IdLoc, Wagons, Guard, Duration, Minions) Values (@IdCaravan, @IdLoc, @Wagons, @Guard, @Duration, @Minions)", conn);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@IdCaravan";
            param.Value = Caravan.GetId();
            param.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@IdLoc";
            param.Value = Caravan.GetIdLoc();
            param.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Wagons";
            param.Value = Caravan.GetWagons();
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Guard";
            param.Value = Caravan.GetGuard();
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Duration";
            param.Value = Caravan.GetDuration();
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Minions";
            param.Value = Caravan.GetMinions();
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);
            
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                return;
            }
            conn.Close();
            conn.Dispose();
        }
        internal void UpdateTownState(TableTownState TownState)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (SqlException se)
            {
                return;
            }

            SqlCommand cmd = new SqlCommand("Insert into Town_State" + "(IdTown,IdState,Duration) Values (@IdTown, @IdState, @Duration)", conn);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@IdTown";
            param.Value = TownState.GetId();
            param.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@IdState";
            param.Value = TownState.GetIdState();
            param.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Duration";
            param.Value = TownState.GetDuration();
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);
            
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                return;
            }
            conn.Close();
            conn.Dispose();
        }
        internal void UpdateArtInTown(TableArtInTown ArtInTown)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (SqlException se)
            {
                return;
            }
            SqlCommand cmd = new SqlCommand("Update Art_in_Town" + " Set Number = @Number, Requisition = @Requisition, Production = @Prod where IdArticle = @IdArticle AND IdTown = @IdTown", conn);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@Number";
            param.Value = ArtInTown.GetNumber();
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Requisition";
            param.Value = ArtInTown.GetRequisition();
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Prod";
            param.Value = ArtInTown.GetProduction();
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@IdArticle";
            param.Value = ArtInTown.GetIdArticle();
            param.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@IdTown";
            param.Value = ArtInTown.GetId();
            param.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(param);
            
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {               
                return;
            }
            conn.Close();
            conn.Dispose();
        }
        internal void UpdateArtInCaravan(TableArtInCaravan ArtInCaravan)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (SqlException se)
            {
                return;
            }

            SqlCommand cmd = new SqlCommand("Insert into Art_in_Caravan" + "(IdCaravan, IdArticle, Number) Values (@Id, @IdArt, @Num)", conn);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@Id";
            param.Value = ArtInCaravan.GetId();
            param.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@IdArt";
            param.Value = ArtInCaravan.GetIdArticle();
            param.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Num";
            param.Value = ArtInCaravan.GetNumber();
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);
            
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                return;
            }
            conn.Close();
            conn.Dispose();
        }
        internal void UpdateArticle(TableArticle Article)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (SqlException se)
            {
                return;
            }
            SqlCommand cmd = new SqlCommand("Update Article" + " Set Name = @Name, Price = @Price, Prod = @Prod, Requisition = @Requisition where IdArticle = @ID", conn);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@Name";
            param.Value = Article.GetName();
            param.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Price";
            param.Value = Article.GetPrice();
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Prod";
            param.Value = Article.GetProduction();
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Requisition";
            param.Value = Article.GetRequisition();
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@ID";
            param.Value = Article.GetId();
            param.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(param);
            
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {                
                return;
            }
            conn.Close();
            conn.Dispose();
        }
        internal void UpdateResources(int Gold, int Turn)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (SqlException se)
            {
                return;
            }
            SqlCommand cmd = new SqlCommand("Update Resources" + " Set Gold = @Gold, Turn = @Turn WHERE IdResources = @IdResources", conn);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@IdResources";
            param.Value = "RES01";
            param.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Gold";
            param.Value = Gold;
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Turn";
            param.Value = Turn;
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                return;
            }
            conn.Close();
            conn.Dispose();
        }

        //Czytanie dadych z tabeli, oraz druk do konsoli

        internal void SelectCaravan()
        {
            string sqlSelect = "SELECT * FROM Caravan";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlSelect, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read()) //Read by lines
                    {
                        object id = reader.GetValue(0);
                        object IdLoc = reader.GetValue(1);
                        object Wagons = reader.GetValue(2);
                        object Guard = reader.GetValue(3);
                        object Duration = reader.GetValue(4);
                        object Minions = reader.GetValue(5);

                        Console.WriteLine("{0} {1} {2} {3} {4} {5}", id, IdLoc, Wagons, Guard, Duration, Minions);
                    }
                }
            }
        }
        internal void SelectArtInCaravan()
        {
            string sqlSelect = "SELECT * FROM Art_in_Caravan";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlSelect, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read()) //Read by lines
                    {
                        object id = reader.GetValue(0);
                        object IdArticle = reader.GetValue(1);
                        object Number = reader.GetValue(2);

                        Console.WriteLine("{0} {1} {2}", id.ToString(), IdArticle.ToString(), Number.ToString());
                    }
                }
            }
        }
        internal void SelectTownState()
        {
            string sqlSelect = "SELECT * FROM Town_State";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlSelect, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read()) //Read by lines
                    {
                        object id = reader.GetValue(0);
                        object IdState = reader.GetValue(1);
                        object Duration = reader.GetValue(2);

                        Console.WriteLine("{0} {1} {2}", id.ToString(), IdState.ToString(), Duration.ToString());
                    }
                }
            }
        }
        internal void SelectLocs()
        {
            string Comm = "SELECT * FROM Locs";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Comm, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read()) //Read by lines
                    {
                        object id = reader.GetValue(0).ToString();
                        object Name = reader.GetValue(1).ToString();

                        Console.WriteLine("{0} {1}", id.ToString(), Name.ToString());
                    }
                }
            }
        }
    }
}

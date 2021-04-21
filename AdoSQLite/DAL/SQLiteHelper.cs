using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoSQLite.DAL
{
    class SQLiteHelper
    {
        internal static List<Users> GetUsers()
        {
            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=SQLite.sqlite;Version=3;"))
                {
                    connection.Open();

                    using (var cmd = new SQLiteCommand(@"SELECT id,
                                                                user_name,
                                                                name,
                                                                date_created
                                                           FROM Users;", connection))
                    {
                        using (var rdr = cmd.ExecuteReader())
                        {
                            List<Users> users = new List<Users>();
                            while (rdr.Read())
                            {
                                users.Add(new Users
                                {
                                    Id = rdr.GetInt32(0),
                                    UserName = rdr.GetString(1),
                                    Name = rdr.GetString(2),
                                    Date = rdr.GetDateTime(3)
                                });
                            }

                            return users;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}

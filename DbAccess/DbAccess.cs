using Dapper;
using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess
{
    public class DataAccess
    {
        public static string GetConnectionString(string name = "Default")
        {
            return ConfigurationManager.ConnectionStrings[name]?.ConnectionString;
        }

        public static List<PersonModel> GetPeople()
        {
            using (IDbConnection connection = new SQLiteConnection(GetConnectionString()))
            {
                string sql = @"select p.*,c.* from Person p
                            left join Car c 
                            on p.CarId = c.Id";
                var ret = connection.Query<PersonModel, CarModel, PersonModel>(sql, (person, car) => { person.Car = car; return person; });
                return ret.ToList<PersonModel>();
            }
        }
    }
}

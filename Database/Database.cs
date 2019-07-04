
using IDK.Database.Models;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider;
using LinqToDB.DataProvider.MySql;

namespace IDK.Database
{
    public class Database : DataConnection
    {
        public Database(IDataProvider provider, string connectionString) : base(provider, connectionString)
        {
        }
    }
}

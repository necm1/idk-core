namespace IDK {
    using System;
    using System.Data;
    using System.IO;
    using log4net;
    using LinqToDB.DataProvider.MySql;
    using IDK.Network;
    using IDK.Util;
    using IDK.Game;
    using System.Threading.Tasks;
    using DotNetty.Transport.Channels;

    public class Emulator {
        private static readonly ILog log = LogManager.GetLogger(typeof(Emulator));

        public static string REVISION = "PRODUCTION-201901041207-836491431";
        private static Config _config;
        private static Database.Database _database;
        private static Server _listener;
        private static GameEnvironment _gameEnvironment;

        public static void Initialize() {
            Console.Title = "IDK Emulator";

            Console.WriteLine(@" _____ _____  _  __");
            Console.WriteLine(@"|_   _|  __ \| |/ /");
            Console.WriteLine(@"  | | | |  | | ' /  Privater Habbo Emulator");
            Console.WriteLine(@"  | | | |  | |  <   Geschrieben von kanax");
            Console.WriteLine(@" _| |_| |__| | . \  Revision: PRODUCTION");
            Console.WriteLine(@"|_____|_____/|_|\_\" + "\n");

            try {
                _config = new Config(Directory.GetCurrentDirectory() + "/Config/config.ini");

                _listener = new Server();
                _listener.Listen().Wait();

                _database =  new Database.Database(new MySqlDataProvider(), $"Server={Config().GetValue("idk.mysql.host")};Port={Config().GetValue("idk.mysql.port")};Database={Config().GetValue("idk.mysql.database")};Uid={Config().GetValue("idk.mysql.user")};Pwd={Config().GetValue("idk.mysql.password")};");
                if(_database.Connection.State == ConnectionState.Open) log.Info("Verbindung zur Datenbank wurde hergestellt!");
                
                _gameEnvironment = new GameEnvironment();
            } catch(Exception e) {
                log.Error(e.ToString());
            }
        }

        public static Config Config() {
            return _config;
        }

        public static GameEnvironment GameEnvironment() {
            return _gameEnvironment;
        }

        public static Database.Database Database() {
            return _database;
        }
    }
}
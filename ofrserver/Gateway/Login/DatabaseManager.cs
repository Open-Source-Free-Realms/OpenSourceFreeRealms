using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using MySql.Data.MySqlClient;
using SOE.Core;

namespace Gateway.Login
{
    public static class DatabaseManager
    {
        private static ILog _log;
        public static SOEServer _server;
        private static MySqlConnection _db;
        private static MySqlCommand command;


        public static void Start(SOEServer soeServer = null)
        {
            _server = soeServer ?? Gateway.Server;

            _log = _server.Logger.GetLogger("DatabaseManager");

            string address = "127.0.0.1";
            ushort port = 3306;
            string userId = "Deputy0295";
            string password = "E35@djc3CF98sE$k";
            _db = new MySqlConnection($"server={address};port={port};userid={userId};password={password};database=openfreerealms");
            _db.Open();

            command = new MySqlCommand();
            command.Connection = _db;

            _log.Info("Service constructed");
        }

        public static bool AttemptLogin(ulong guid, string ticket)
        {
            command.CommandText = $"SELECT * FROM `session_tickets` WHERE {guid}";
            MySqlDataReader reader = command.ExecuteReader();

            bool success = false;
            while (reader.Read())
            {
                ulong dbGuid = (ulong)reader.GetInt64(0);
                string dbTicket = reader.GetString(1);
                ulong expires = (ulong)reader.GetInt64(2);
                if (dbGuid == guid && dbTicket == ticket)
                {
                    success = true;
                    break;
                }
            }

            reader.Close();

            return success;
        }
    }
}

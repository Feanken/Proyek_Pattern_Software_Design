using Proyek_Pattern_Software_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyek_Pattern_Software_Design.Connection
{
	public class DatabaseConnection
	{
		private Database1Entities entities;
        private static DatabaseConnection instance = null;
        private DatabaseConnection()
		{
			entities = new Database1Entities();
        }
		public static DatabaseConnection getInstance()
        {
            if (instance == null)
            {
                instance = new DatabaseConnection();
            }
            return instance;
        }
        public Database1Entities getDB()
        {
            return entities;
        }
    }
}
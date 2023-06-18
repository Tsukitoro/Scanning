using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AttackDetection.Models
{
    public class AppForm : Form
    {
        private SqlConnection connection;
        internal void ConnectDB()
        {
            var starUpPath = Application.StartupPath;
            var dbPath = starUpPath.Substring(0, starUpPath.Length - 10);

            connection = new SqlConnection(
                @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                $@"AttachDbFilename={dbPath}\Database1.mdf;" +
                "Integrated Security = True;"
            );
            connection.Open();
        }

        internal void CloseDb()
        {
            connection.Close();
        }

        internal SqlCommand CreateCommand(string sql, Dictionary<string, dynamic> parms)
        {
            var cmd = new SqlCommand(sql, connection);

            foreach ( var prm in parms )
            {
                cmd.Parameters.AddWithValue($"@{prm.Key}", prm.Value);
            }

            return cmd;
        }
    }
}

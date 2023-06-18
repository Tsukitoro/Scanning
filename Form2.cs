using AttackDetection.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AttackDetection
{
    public partial class Form2 : AppForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var main = new Form1();
            main.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectDB();

                SqlCommand selectCommand = CreateCommand(
                    "select 1 from [Users] where Login=@login and Password=@password",
                    new Dictionary<string, dynamic>
                    {
                        { "login", textBox1.Text },
                        { "password", textBox2.Text }
                    }
                );

                var exist = selectCommand.ExecuteScalar() != null;

                CloseDb();

                if ( exist )
                {
                    MessageBox.Show("Пользователь уже существует!");
                } else
                {
                    ConnectDB();

                    SqlCommand insertCmd = CreateCommand(
                        "insert into [Users] (Login, Password) values (@login, @password)",
                        new Dictionary<string, dynamic>
                        {
                            { "login", textBox1.Text },
                            { "password", textBox2.Text }
                        }
                    );

                    insertCmd.ExecuteNonQuery();

                    CloseDb();

                    var main = new Form1();
                    main.Show();

                    this.Hide();
                }
            } catch
            {

            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(sender, e);
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(sender, e);
            }
        }
    }
}

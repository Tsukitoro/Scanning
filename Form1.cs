using AttackDetection.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AttackDetection
{
    public partial class Form1 : AppForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var main = new Form2();
            main.Show();

            this.Hide();
        }

        private void login_Click(object sender, EventArgs e)
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

            if (exist)
            {
                var main = new Form4();
                main.Show();

                this.Hide();
            } else
            {
                MessageBox.Show("Пользователь не найден!");
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login_Click(sender, e);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login_Click(sender, e);
            }
        }
    }
}

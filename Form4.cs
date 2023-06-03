using AttackDetection.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AttackDetection
{
    public partial class Form4 : Form
    {
        ScanningService service;
        public Form4()
        {
            InitializeComponent();
            service = new ScanningService();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            service.StartScan(this);
        }

        internal void Update_Result(List<List<string>> result)
        {
            for (int i = 0; i < result.Count; i++)
            {
                var info = result[i];
                var row = new[]
                {
                    $"{i}",
                    "",
                    info.ElementAt(0),
                    info.ElementAt(1),
                };

                dataGridView1.Rows.Add(row);
            }

            dataGridView1.Update();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            service.ChangeUrl(((TextBox)sender).Text);
        }
    }
}

using AttackDetection.Models;
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
        List<ScanningResult> results = new List<ScanningResult>();

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
            tabPage4.Focus();

            var info = results.ElementAt(e.RowIndex);

            tabPage4.Controls.Clear();
            tabPage4.Controls.Add(new TextBox() { Text = info.Descr, Width = 900, Height = 450 });

            tabPage4.Refresh();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            service.StartScan(this);
        }

        internal void Update_Result(List<ScanningResult> result)
        {
            results = result;
            dataGridView1.Rows.Clear();
            for (int i = 0; i < result.Count; i++)
            {
                var info = result[i];
                var row = new[]
                {
                    $"{i}",
                    info.StatusCode.ToString(),
                    info.Link,
                    info.Date.ToShortTimeString(),
                    info.ShortDescr,
                    info.SecurityLevel.ToString()
                };

                dataGridView1.Rows.Add(row);
            }

            dataGridView1.Update();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            service.ChangeUrl(((TextBox)sender).Text);
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}

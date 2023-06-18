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
                    info.Date.ToShortTimeString() + " " + info.Date.ToShortDateString(),
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

        private void выйтиИзПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void сохранитьОтчетToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void сохранитьОтчетToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 frm = new AboutBox1();
            frm.Show();
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}

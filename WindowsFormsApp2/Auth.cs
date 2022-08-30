using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Pages;

namespace WindowsFormsApp2
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();

            comboBox1.DataSource = new List<string>()
            {

                "postgres",
                "admin",
                "employee"

            };
        
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Main.userid = comboBox1.SelectedItem.ToString();

            this.Hide();
            
            Main main = new Main();
            main.ShowDialog();

            try { this.Show(); }
            catch (ObjectDisposedException) { };

        }

    }

}

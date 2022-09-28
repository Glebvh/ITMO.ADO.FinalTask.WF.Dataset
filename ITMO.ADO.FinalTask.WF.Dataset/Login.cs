using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ITMO.ADO.FinalTask.WF.Dataset
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=WFdb;Data Source=.");
            SqlCommand cmd = new SqlCommand($"Select Login, Pass from tUsers where Login = '{textBox_login.Text}' and Pass = '{textBox_pass.Text}'", conn);
            DataTable dt = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                DB dB = new DB();
                this.Hide();
                dB.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Ошибка подключения");
        }
    }
}

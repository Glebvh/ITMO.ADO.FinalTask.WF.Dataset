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
    public partial class DB : Form
    {
        public DB()
        {
            InitializeComponent();
        }
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlConnection conn = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=WFdb;Data Source=.");
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        private void DB_Load(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand($"Select * from tContent", conn))
            {
                adapter.SelectCommand = cmd;
                dataGridView1.DataSource = dt;
                adapter.Fill(dt);
            }
            SqlCommandBuilder commands = new SqlCommandBuilder(adapter);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {       
            adapter.Update(dt);
        }

        
    }
}

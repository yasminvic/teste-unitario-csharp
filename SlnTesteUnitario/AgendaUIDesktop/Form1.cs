using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaUIDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtContatoNovo.Text;
            var id = Guid.NewGuid();

            string strConnection = @"Data Source=localhost\sqlexpress; Initial Catalog=agenda-contatos-testes-unitarios; Integrated Security=True;";
            SqlConnection con = new SqlConnection(strConnection);
            con.Open();

            string sqlInsert = $"insert into Contatos values ('{id}', '{nome}')";
            string sqlSelect = $"select Nome from Contatos where Id = '{id}'";

            SqlCommand cmd = new SqlCommand(sqlInsert, con);

            cmd.ExecuteNonQuery();  

            cmd = new SqlCommand(sqlSelect, con);

            txtContatoSalvo.Text = cmd.ExecuteScalar().ToString();


            con.Close();
        }
    }
}

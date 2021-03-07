using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Agenda.UI.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var nome = txtContatoNovo.Text;

            var idContato = Guid.NewGuid().ToString();

            var stringConn = @"Data Source=localhost;Initial Catalog=Agenda;Integrated Security=True";
            var insertContato = string.Format("insert into Contato (id, nome) values ('{0}','{1}')", idContato, nome);
            var selectContato = string.Format("select nome from Contato where id = '{0}'", idContato);

            using (SqlConnection conn = new SqlConnection(stringConn))
            {
                conn.Open();

                var command = new SqlCommand(insertContato, conn);
                command.ExecuteNonQuery();

                var command2 = new SqlCommand(selectContato, conn);
                txtContatoSalvo.Text = command2.ExecuteScalar().ToString();

                conn.Close();
            }
        }
    }
}

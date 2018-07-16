using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace AdoNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\p106\source\repos\AdoNet\AdoNet\Db\Sample.mdf;Integrated Security=True";
            var connect = new SqlConnection(connectionString);
            connect.Open();
            var name = textBox1.Text;
            var surname = textBox2.Text;
            var insertQuery = "INSERT INTO UserData(Ad,Soyad) VALUES('" + name + "','" + surname + "')";
            var command = new SqlCommand(insertQuery, connect);
            command.ExecuteNonQuery();
            connect.Close();
        }
    }
}

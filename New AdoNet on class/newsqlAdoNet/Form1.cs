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

namespace newsqlAdoNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var connectString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\P106\source\repos\newsqlAdoNet\newsqlAdoNet\Data\Database1.mdf;Integrated Security=True";
            var comnnect = new SqlConnection(connectString);
            comnnect.Open();
            var techerName = textBox1.Text;
            var insertteacher = "insert into Teachers values('" + techerName + "')";
            var command = new SqlCommand(insertteacher, comnnect);
            command.ExecuteNonQuery();
            var select = "select Name from Teachers";
            var di = new SqlDataAdapter(select,comnnect);
            var ds = new DataSet();
            di.Fill(ds);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                
                comboBox1.Items.Add(item["Name"]);
            }
            comnnect.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var connectString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\P106\source\repos\newsqlAdoNet\newsqlAdoNet\Data\Database1.mdf;Integrated Security=True";
            var comnnect = new SqlConnection(connectString);
            comnnect.Open();
            var className = textBox2.Text;
            var classteacher = comboBox1.SelectedItem;
            var studentCount = textBox3.Text;
            var insertteacher = "insert into Clsses values('" + className + "',(select Id from Teachers where Name='"+classteacher+"'),"+studentCount+")";
            var command = new SqlCommand(insertteacher, comnnect);
            command.ExecuteNonQuery();
            comnnect.Close();
        }
    }
}

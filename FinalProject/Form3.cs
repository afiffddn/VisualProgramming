using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace FinalProject
{
    public partial class Form3 : Form

    {
        public static string name;
        public Form3()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["zz"].ConnectionString;
            string INSERT = "SELECT * FROM tblTerrorist WHERE TerroristUname = @uname AND Password =@pswrd";
            SqlConnection cnct = new SqlConnection(cs);
            try
            {
                cnct.Open();
                SqlCommand cmd = new SqlCommand(INSERT, cnct);
                cmd.Parameters.AddWithValue("@uname", textBox1.Text);
                cmd.Parameters.AddWithValue("@pswrd", textBox2.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    name = textBox1.Text;
                    MessageBox.Show("Login Succesful");
                    Form1 f1 = new Form1();
                    f1.Show();
                }

                else
                {
                    MessageBox.Show("Login Unsuccesful");
                }
                cnct.Close();

                
                 
                
            }
            catch(SqlException sqlx)
            {

                MessageBox.Show(sqlx.Message);
            }
        }
    }
}

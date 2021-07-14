using System;
using System.Data.Sql;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace FinalProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["zz"].ConnectionString;
            string table = "INSERT INTO tblTerrorist (TerroristUname,Email,Password,Confirmpasswrd,Total,Pistol,Knife,Bomb,QuantityPistol,QuantityKnife,QuantityBomb) VALUES (@username,@email,@password,@confirmpasswrd,@Total,@pistol,@knife,@bomb,@quantitypistol,@quantityknife,@quantitybomb)";
            SqlConnection data = new SqlConnection(cs);

            try
            {
                data.Open();
                SqlCommand cmd = new SqlCommand(table,data);
                if (textBox3.Text == textBox4.Text)
                {
                    cmd.Parameters.AddWithValue("@username", textBox1.Text);
                    cmd.Parameters.AddWithValue("@email", textBox2.Text);
                    cmd.Parameters.AddWithValue("@password", textBox3.Text);
                    cmd.Parameters.AddWithValue("@confirmpasswrd", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Total", Convert.ToDouble(0.00));
                    cmd.Parameters.AddWithValue("@Pistol", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Knife", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Bomb", textBox3.Text);
                    cmd.Parameters.AddWithValue("@QuantityPistol", Convert.ToInt32(0));
                    cmd.Parameters.AddWithValue("@QuantityKnife", Convert.ToInt32(0));
                    cmd.Parameters.AddWithValue("@QuantityBomb", Convert.ToInt32(0));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sucessfully registered");
                    Form3 f3 = new Form3();
                    f3.Show();
                }

                else
                {
                    MessageBox.Show("Please enter your password correctly");
                }
                data.Close();

            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }

        }
    }
}

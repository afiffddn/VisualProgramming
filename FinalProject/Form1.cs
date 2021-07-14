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
    public partial class Form1 : Form
    {
        Dictionary<String, Bitmap> pic1 = new Dictionary<String, Bitmap>();
        Dictionary<String,String> pistol = new Dictionary<String, String>();
        Dictionary<String, double> price = new Dictionary<String, double>();
        String p;

        Dictionary<String, Bitmap> pic2 = new Dictionary<String, Bitmap>();
        Dictionary<String, String> bomb = new Dictionary<String, String>();
        Dictionary<String, double> price2 = new Dictionary<String, double>();
        String b;

        Dictionary<String, Bitmap> pic3 = new Dictionary<String, Bitmap>();
        Dictionary<String, String> knife = new Dictionary<String, String>();
        Dictionary<String, double> price3 = new Dictionary<String, double>();
        String k;

        double quantity;
        double Total;
        double quantity2;
        double Total2;
        double quantity3;
        double Total3;
        double tot1, tot2, tot3;
        double TotalAll;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pic1.Add("pistol1", Properties.Resources.glock_22);
            pic1.Add("pistol2", Properties.Resources.ruger);

            pistol.Add("Glock 22", "pistol1");
            pistol.Add("Ruger SP101", "pistol2");

            price.Add("pistol1", 250.00);
            price.Add("pistol2", 220.00);

            pic2.Add("bomb1", Properties.Resources.pbomb);
            pic2.Add("bomb2", Properties.Resources.c4);

            bomb.Add("pipe bomb", "bomb1");
            bomb.Add("c4", "bomb2");

            price2.Add("bomb1", 320.00);
            price2.Add("bomb2", 400.00);

            pic3.Add("knife1", Properties.Resources.karambit2);
            pic3.Add("knife2", Properties.Resources.butterfly);

            knife.Add("karambit", "knife1");
            knife.Add("butterfly", "knife2");

            price3.Add("knife1", 95.00);
            price3.Add("knife2", 120.00);

            label7.Text = Form3.name.ToString();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            
            string cb1 = comboBox1.SelectedItem.ToString();
             p = pistol[cb1];

            pictureBox1.Image = new Bitmap(pic1[p]);
            Total = Convert.ToDouble(price[p]);
            pistolprice.Text = "$" + Total.ToString("n2");

          
        }

        private void comboBox3_DropDownClosed(object sender, EventArgs e)
        {
            
            string cb3 = comboBox3.SelectedItem.ToString();
            k = knife[cb3];

            pictureBox3.Image = new Bitmap(pic3[k]);
            Total3 = Convert.ToDouble(price3[k]);
            knifeprice.Text = "$" + Total.ToString("n2");
        }

        private void comboBox2_DropDownClosed_1(object sender, EventArgs e)
        {
            
            string cb2 = comboBox2.SelectedItem.ToString();
            b = bomb[cb2];

            pictureBox2.Image = new Bitmap(pic2[b]);
            Total2 = Convert.ToDouble(price2[b]);
            bombprice.Text = "$" + Total2.ToString("n2");
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            String pis = listBox1.SelectedItem.ToString();
            quantity = Convert.ToDouble(pis);
             tot1 = Total * quantity;
            pistolprice.Text = "$" + tot1.ToString("n2");
        }

        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {
            String bom = listBox2.SelectedItem.ToString();
            quantity2 = Convert.ToDouble(bom);
             tot2 = Total2 * quantity2;
            bombprice.Text = "$" + tot2.ToString("n2");
        }

        private void listBox3_MouseClick(object sender, MouseEventArgs e)
        {
            String knf = listBox3.SelectedItem.ToString();
            quantity3 = Convert.ToDouble(knf);
             tot3 = Total3 * quantity3;
            knifeprice.Text = "$" + tot3.ToString("n2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strthis = Form3.name;

            string cs = ConfigurationManager.ConnectionStrings["zz"].ConnectionString;
            string table = "UPDATE tblTerrorist  SET Pistol = @pistol,Knife =@knife,Bomb =@bomb,QuantityPistol =@quantitypistol,QuantityKnife =@quantityknife,QuantityBomb =@quantitybomb,Total=@total WHERE TerroristUname =@uname";
            SqlConnection data = new SqlConnection(cs);

            try
            {

                data.Open();
                
                SqlCommand cmd = new SqlCommand(table, data);





                TotalAll = tot1 + tot2 + tot3;
                    cmd.Parameters.AddWithValue("@pistol", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@knife", comboBox2.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@bomb", comboBox3.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@quantitypistol", Convert.ToInt32( listBox1.SelectedItem.ToString()));
                    cmd.Parameters.AddWithValue("@quantityknife", Convert.ToInt32( listBox3.SelectedItem.ToString()));
                    cmd.Parameters.AddWithValue("@quantitybomb", Convert.ToInt32( listBox2.SelectedItem.ToString()));
                    cmd.Parameters.AddWithValue("@uname", Form3.name.ToString());
                    cmd.Parameters.AddWithValue("@total", Convert.ToDouble(TotalAll));
                  
                cmd.ExecuteNonQuery();
                label7.Text = Form3.name.ToString();
                
                DataTable dt = new DataTable();
                dt.Columns.Add("Weapon list");
                dt.Columns.Add("Quantity");
                dt.Rows.Add(new object[] { Convert.ToString( comboBox1.SelectedItem.ToString()), Convert.ToInt32 (listBox1.SelectedItem.ToString()) });
                dt.Rows.Add(new object[] { Convert.ToString( comboBox2.SelectedItem.ToString()), Convert.ToInt32(listBox2.SelectedItem.ToString()) });
                dt.Rows.Add(new object[] { Convert.ToString( comboBox3.SelectedItem.ToString()), Convert.ToInt32(listBox3.SelectedItem.ToString()) });
               

                Form4 f4 = new Form4();
                f4.dataGridView1.DataSource = dt;





                
                f4.label4.Text = "$"+TotalAll.ToString("n2");


                MessageBox.Show("Please proceed for the payment, Thank You!");
                

                f4.Show();

                data.Close();

            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

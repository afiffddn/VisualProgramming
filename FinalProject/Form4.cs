using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_MouseClick(object sender, MouseEventArgs e)
        {
            if (radioButton2.Checked = true)
            {
                textBox2.Enabled = false;
                textBox1.Enabled = false;
                comboBox1.Enabled = false;
            }
        }

        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {

            if (radioButton1.Checked = true)
            {
                textBox2.Enabled = true;
                textBox1.Enabled = true;
                comboBox1.Enabled = true;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your transaction has been succesful");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                if (e.KeyChar != (char)8)
                {
                    MessageBox.Show("WRONG KEY PRESSED!", ("Textbox Validation"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.KeyChar = (char)0;
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 'a' || e.KeyChar > 'z')
            {
                if (e.KeyChar != (char)8)
                {
                    MessageBox.Show("WRONG KEY PRESSED!", ("Textbox Validation"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.KeyChar = (char)0;
                }
            }
        }
    }
}

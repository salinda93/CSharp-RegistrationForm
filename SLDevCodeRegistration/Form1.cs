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

namespace SLDevCodeRegistration
{
    public partial class Form1 : Form
    {
        String connectionString = @"Data Source=DESKTOP-S4C3E56\SALINDASQL;Initial Catalog=UserRegistrationDB;Integrated Security=True;";


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (textBoxUN.Text == "" || textBox2Pass.Text == "")
                MessageBox.Show("Please Fill the Mandotory Fields...!");
            else if (textBox2Pass.Text != textBox3ComPass.Text)
                MessageBox.Show("Incorrect Password.....!");

            else
            { 

            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("UserAdd", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@FirstName", textBoxFN.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@LastName", textBoxLN.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Contact", textBoxContact.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Address", textBoxAddress.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Username", textBoxUN.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Password", textBox2Pass.Text.Trim());

                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("Registration is Successful....!");
                Clear();
            }
            }
        }

        void Clear()
        {
            textBoxFN.Text = textBoxLN.Text = textBoxContact.Text = textBoxAddress.Text = textBoxUN.Text = textBox2Pass.Text = "";
        }
    }
}


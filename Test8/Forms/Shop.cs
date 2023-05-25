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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Test8.Forms
{
    public partial class Shop : Form
    {
        public Shop()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS02;Initial Catalog=Test;Integrated Security=True");
        SqlCommand cmd;
        public static int sum;

        private void button2_Click(object sender, EventArgs e)
        {
            int MumuPrice = 500;
            sum = sum + MumuPrice;
            label6.Text = sum.ToString();
            listBox1.Items.Add(groupBox1.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int VarPrice = 600;
            sum = sum + VarPrice;
            label6.Text = sum.ToString();
            listBox1.Items.Add(groupBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int BookPrice = 750;
            sum = sum + BookPrice;
            label6.Text = sum.ToString();
            listBox1.Items.Add(groupBox3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int JurPrice = 235;
            sum = sum + JurPrice;
            label6.Text = sum.ToString();
            listBox1.Items.Add(groupBox4.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            sum = 0;
            label6.Text = sum.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[заказы]\r\n           ([ID]\r\n           ,[Код заказа]\r\n           ,[Дата создания]\r\n           ,[Время заказа]\r\n           ,[Код клиента]\r\n           ,[Услуги]\r\n           ,[Статус]\r\n           ,[Дата закрытия]\r\n           ,[Время проката])\r\n     VALUES (777, 'Гость', @3, @4, 777, @6, 'Новый', @8, 'Гость')", con);
            
            cmd.Parameters.AddWithValue("@3", DateTime.Now);
            cmd.Parameters.AddWithValue("@4", DateTime.Now);
            cmd.Parameters.AddWithValue("@6", listBox1.Items[0].ToString());
            cmd.Parameters.AddWithValue("@8", DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Ваш заказ сформирован");
            listBox1.Items.Clear();
            sum = 0;
            label6.Text = sum.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Avtorize av = new Avtorize();
            av.Show();
        }
    }
}

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

namespace Test8.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS02;Initial Catalog=Test;Integrated Security=True");
        SqlCommand cmd;

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDataSet.ФЛ". При необходимости она может быть перемещена или удалена.
            this.фЛTableAdapter.Fill(this.testDataSet.ФЛ);
            lblName.Text = WC.FIO;

        }

        

        private void btnIns_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[ФЛ]\r\n           ([ФИО]\r\n           ,[Код клиента]\r\n           ,[Паспортные данные]\r\n           ,[Дата рождения]\r\n           ,[Адрес]\r\n           ,[e-mail]\r\n           ,[password])\r\n     VALUES (@1, @2, @3, @4, @5, @6, @7)", con);
                cmd.Parameters.AddWithValue("@1", textBox1.Text);
                cmd.Parameters.AddWithValue("@2", textBox2.Text);
                cmd.Parameters.AddWithValue("@3", textBox3.Text);
                cmd.Parameters.AddWithValue("@4", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@5", textBox5.Text);
                cmd.Parameters.AddWithValue("@6", textBox6.Text);
                cmd.Parameters.AddWithValue("@7", textBox7.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Данные добавились");
            }
            else
            {
                MessageBox.Show("Заполните поля!");
            }
        }

        private void btnRefr_Click(object sender, EventArgs e)
        {
            this.фЛTableAdapter.Fill(this.testDataSet.ФЛ);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[ФЛ] SET [ФИО] = @1,[Код клиента] = @2,[Паспортные данные] = @3,[Дата рождения] = @4,[Адрес] = @5,[e-mail] = @6,[password] = @7 WHERE [ФИО] = @1", con);
                cmd.Parameters.AddWithValue("@1", textBox1.Text);
                cmd.Parameters.AddWithValue("@2", textBox2.Text);
                cmd.Parameters.AddWithValue("@3", textBox3.Text);
                cmd.Parameters.AddWithValue("@4", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@5", textBox5.Text);
                cmd.Parameters.AddWithValue("@6", textBox6.Text);
                cmd.Parameters.AddWithValue("@7", textBox7.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Данные отредактированны");
            }
            else
            {
                MessageBox.Show("Заполните поля!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[ФЛ]\r\n      WHERE [ФИО] = @1", con);
                cmd.Parameters.AddWithValue("@1", textBox1.Text);
                cmd.Parameters.AddWithValue("@2", textBox2.Text);
                cmd.Parameters.AddWithValue("@3", textBox3.Text);
                cmd.Parameters.AddWithValue("@4", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@5", textBox5.Text);
                cmd.Parameters.AddWithValue("@6", textBox6.Text);
                cmd.Parameters.AddWithValue("@7", textBox7.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Данные удалены");
            }
            else
            {
                MessageBox.Show("Заполните поля!");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu me = new Menu();
            me.Show();
        }
    }
}

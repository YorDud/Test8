using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test8.Forms
{
    public partial class Avtorize : Form
    {
        public Avtorize()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS02;Initial Catalog=Test;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        int time;
        private readonly Stopwatch stopwatch = new Stopwatch();

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Hide();
            Shop sh = new Shop();
            sh.Show();
        }

        private void Timer()
        {
            time = 20;
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtLog.Text != "" && txtPass.Text != "")
            {
                
                SqlCommand cmd = new SqlCommand("SELECT [Должность]\r\n      ,[ФИО ] FROM [Test].[dbo].[сотрудники] WHERE [Логин ] = @LOG AND [Пароль] = @PASS", con);
                cmd.Parameters.AddWithValue("@LOG", txtLog.Text);
                cmd.Parameters.AddWithValue("@PASS", txtPass.Text);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        WC.ROLE = dr.GetValue(0).ToString();
                        WC.FIO = dr.GetValue(1).ToString();
                        if (WC.ROLE == "Продавец")
                        {
                            timer1.Stop();
                            MessageBox.Show("Здравствуйте " + WC.FIO);
                            this.Hide();
                            Shop sh = new Shop();
                            sh.Show();
                        }
                        else if (WC.ROLE == "Администратор")
                        {
                            timer1.Stop();
                            MessageBox.Show("Здравствуйте " + WC.FIO);
                            this.Hide();
                            Menu mn = new Menu();
                            mn.Show();
                        }
                        else if (WC.ROLE == "Старший смены")
                        {
                            timer1.Stop();
                            MessageBox.Show("Здравствуйте " + WC.FIO);
                            this.Hide();
                            Menu mn = new Menu();
                            mn.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неверные логин или пароль!");
                }
            }
            else
            {
                MessageBox.Show("Заполните Логин и Пароль");
            }
        }

        private void Avtorize_Load(object sender, EventArgs e)
        {
            con.Open();
            Timer();
            stopwatch.Start();
            timer1_Tick(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = stopwatch.Elapsed.ToString("mm\\:ss");
            --time;
            if (time == 0)
            {
                timer1.Stop();
                MessageBox.Show("Время на авторизацию истекло");
                Application.Exit();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            txtPass.PasswordChar = (char)0;
        }
    }
}

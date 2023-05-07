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

namespace Kaday_Personel_Takip
{
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-TGTO3J4\\MSSQLSERVER02;Initial Catalog=PerDb;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }
        void Kayit()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Tbl_Personel (Perid,PerAd,PerSoyad,PerTc,PerTel,PerKan,Meslek,Alan,Maaş)" +
                "values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", conn);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", textBox3.Text);
            cmd.Parameters.AddWithValue("@p4", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@p5", maskedTextBox2.Text);
            cmd.Parameters.AddWithValue("@p6", comboBox1.Text);
            cmd.Parameters.AddWithValue("@p7", textBox7.Text);
            cmd.Parameters.AddWithValue("@p8", textBox8.Text);
            cmd.Parameters.AddWithValue("@p9", textBox9.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Personel",conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kayit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele();
        }
    }
}

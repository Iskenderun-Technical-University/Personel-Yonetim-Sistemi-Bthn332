using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kaday_Personel_Takip
{
    public partial class Form2 : Form
    {
        SqlConnection bağlanti = new SqlConnection("Data Source=DESKTOP-TGTO3J4\\MSSQLSERVER02;Initial Catalog=PerDb;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
            Listele();
        }
        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Personel",bağlanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bağlanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel(Perid,PerAd,PerSoyad,PerTc,PerTel,PerKan,Meslek,Alan,Maaş) " +
                "values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)",bağlanti);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", textBox3.Text);
            komut.Parameters.AddWithValue("@p4", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p5", maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@p6", comboBox1.Text);
            komut.Parameters.AddWithValue("@p7", textBox7.Text);
            komut.Parameters.AddWithValue("@p8", textBox8.Text);
            komut.Parameters.AddWithValue("@p9", textBox9.Text);
            komut.ExecuteNonQuery();
            bağlanti.Close();
            MessageBox.Show("Personel Eklendi");
        }
        }
    }
}

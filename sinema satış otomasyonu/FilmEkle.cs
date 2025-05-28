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

namespace sinema_satış_otomasyonu
{
    public partial class FilmEkle : Form
    {
        public  FilmEkle()

        {
            InitializeComponent();
        }
        sinemaTableAdapters.Film_BilgileriTableAdapter film = new sinemaTableAdapters.Film_BilgileriTableAdapter();
        private object txtFilmAdi;
        private object txtYönetmen;
        private object txtSüre;
        private object txtYapımYılı;

        public object FilmAdi { get; private set; }
        public object Yönetmen { get; private set; }
        public object FilmTürü { get; private set; }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                // Bağlantı oluştur
                SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=sinema bileti;Persist Security Info=True;User ID=sa;Password=1;");
                baglanti.Open();

                // INSERT sorgusu
                SqlCommand komut = new SqlCommand("INSERT INTO Film_Bilgileri (FilmAdi, Yönetmen, FilmTürü, FilmSüresi, Tarih, YapımYılı) VALUES (@FilmAdi, @Yönetmen, @FilmTürü, @FilmSüresi, @Tarih, @YapımYılı)", baglanti);

                // Parametreleri ata
                komut.Parameters.AddWithValue("@FilmAdi", textBox1.Text);
                komut.Parameters.AddWithValue("@Yönetmen", textBox2.Text);
                komut.Parameters.AddWithValue("@FilmTürü", comboBox1.Text);
                komut.Parameters.AddWithValue("@FilmSüresi", textBox3.Text);
                komut.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value);
                komut.Parameters.AddWithValue("@YapımYılı", textBox4.Text);

                // Sorguyu çalıştır
                komut.ExecuteNonQuery();

                // Mesaj
                MessageBox.Show("Film başarıyla eklendi!", "Bilgi");

                // Temizle (istersen)
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                        item.Text = "";
                }
                comboBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }





        }
    }
}

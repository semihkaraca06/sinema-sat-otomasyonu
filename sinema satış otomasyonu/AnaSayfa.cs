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

namespace sinema_satış_otomasyonu
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }
        SqlConnetion baglanti = new SqlConnetion("Data Source=.\\sqlexpress;Initial Catalog=\"sinema bileti\";Persist Security Info=True;User ID=sa;Password=1;Trust Server Certificate=True");
        private void label13_Click(object sender, EventArgs e)
        {

        }
        int sayac = 0;

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            sayac = 1;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
                    btn.Size = new Size(30, 30);
                    btn.Location = new Point(j * 30 + 30, i * 30 + 30);
                    btn.Name = sayac.ToString();
                    btn.Text = sayac.ToString();
                    sayac++;
                    this.panel1.Controls.Add(btn);
                }







            }







            comboBox1.Items.Clear();

            // Bağlantı cümlesi
            SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=sinema bileti;Persist Security Info=True;User ID=sa;Password=1;");

            // Bağlantıyı aç
            baglanti.Open();

            // Film adlarını çek
            SqlCommand komut = new SqlCommand("SELECT FilmAdi FROM Film_Bilgileri", baglanti);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                // ComboBox’a ekle
                comboBox1.Items.Add(dr["FilmAdi"].ToString());
            }

            // Bağlantıyı kapat
            baglanti.Close();




            try
            {
                baglanti.Open();

                // SalonAdi'ları çekip comboBox2'ye doldur
                SqlCommand salonKomut = new SqlCommand("SELECT SalonAdi FROM Salon_Bilgileri", baglanti);
                SqlDataReader salonDr = salonKomut.ExecuteReader();
                while (salonDr.Read())
                {
                    comboBox2.Items.Add(salonDr["SalonAdi"].ToString());
                }
                salonDr.Close();

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }






        }

        private void button1_Click(object sender, EventArgs e)
        {

            SalonEkleYeni form = new SalonEkleYeni();
            form.ShowDialog();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            FilmEkle ekle = new FilmEkle();
            ekle.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Seans_Ekle seansEkleForm = new Seans_Ekle();
            seansEkleForm.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SeansListele1 form = new SeansListele1();
            form.ShowDialog();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Bağlantı
                SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=sinema bileti;Persist Security Info=True;User ID=sa;Password=1;");
                baglanti.Open();

                // SQL komutu: Satis_Bilgileri'ne ekleme
                SqlCommand komut = new SqlCommand("INSERT INTO Satis_Bilgileri (FilmAdi, SalonAdi, FilmTarih, KoltukNo, Ad, Soyadd, Ücret) VALUES (@FilmAdi, @SalonAdi, @FilmTarih, @KoltukNo, @Ad, @Soyadd, @Ücret)", baglanti);

                // Parametreler: ComboBox ve TextBox'lardan al
                komut.Parameters.AddWithValue("@FilmAdi", comboBox1.Text);
                komut.Parameters.AddWithValue("@SalonAdi", comboBox2.Text);
                komut.Parameters.AddWithValue("@FilmTarih", comboBox3.Text);
                komut.Parameters.AddWithValue("@KoltukNo", textBox1.Text);
                komut.Parameters.AddWithValue("@Ad", textBox2.Text);
                komut.Parameters.AddWithValue("@Soyadd", textBox3.Text);
                komut.Parameters.AddWithValue("@Ücret", comboBox5.Text);

                // Çalıştır
                komut.ExecuteNonQuery();

                MessageBox.Show("Satış başarıyla kaydedildi!", "Bilgi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }







        }

        private void button5_Click(object sender, EventArgs e)
        {

            Application.Exit();



        }
    }
}

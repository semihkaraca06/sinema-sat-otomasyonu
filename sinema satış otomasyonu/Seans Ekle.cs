using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace sinema_satış_otomasyonu
{


    public partial class Seans_Ekle : Form
    {
        public Seans_Ekle()
        {
            InitializeComponent();
        }
        string seans = "";

        private void RadioButtonSeciliyse()
        {
            if (radioButton1.Checked)
                seans = radioButton1.Text;
            else if (radioButton2.Checked)
                seans = radioButton2.Text;
            else if (radioButton3.Checked)
                seans = radioButton3.Text;
            else if (radioButton4.Checked)
                seans = radioButton4.Text;
            else if (radioButton5.Checked)
                seans = radioButton5.Text;
            else if (radioButton6.Checked)
                seans = radioButton6.Text;
            else if (radioButton7.Checked)
                seans = radioButton7.Text;
            else if (radioButton8.Checked)
                seans = radioButton8.Text;
            else if (radioButton9.Checked)
                seans = radioButton9.Text;
            else if (radioButton10.Checked)
                seans = radioButton10.Text;
            else if (radioButton11.Checked)
                seans = radioButton11.Text;
            else if (radioButton12.Checked)
                seans = radioButton12.Text;
        }





        private void button1_Click(object sender, EventArgs e)
        {

            string filmAdi = comboBox1.Text;
            string salonAdi = comboBox2.Text;
            string tarih = dateTimePicker1.Value.ToString("yyyy-MM-dd"); // Tarihi formatlı al
            string seans = "";

            // GroupBox içindeki seçili RadioButton'u bul
            foreach (Control control in groupBox1.Controls)
            {
                if (control is System.Windows.Forms.RadioButton rb && rb.Checked)
                {
                    seans = rb.Text;
                    break;
                }
            }

            // Seans boş değilse ekleme yap
            if (!string.IsNullOrEmpty(seans))
            {
                try
                {
                    // Veritabanı ekleme işlemi
                    sinemaTableAdapters.Seans_BilgileriTableAdapter filmseansi = new sinemaTableAdapters.Seans_BilgileriTableAdapter();
                    filmseansi.SeansEkleme(filmAdi, salonAdi, seans, tarih);

                    MessageBox.Show("Seans ekleme işlemi başarıyla yapıldı.", "Bilgi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message, "Hata");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir seans seçiniz.", "Uyarı");
            }

        }

        sinemaTableAdapters.Seans_BilgileriTableAdapter filmseansi = new sinemaTableAdapters.Seans_BilgileriTableAdapter();
        SqlConnetion baglanti = new SqlConnetion("Data Source=.\\sqlexpress;Initial Catalog=\"sinema bileti\";Persist Security Info=True;User ID=sa;Password=1;Trust Server Certificate=True");
        private void Seans_Ekle_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=sinema bileti;Persist Security Info=True;User ID=sa;Password=1;");
                baglanti.Open();

                SqlCommand komut = new SqlCommand("SELECT FilmAdi FROM Film_Bilgileri", baglanti);
                SqlDataReader dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["FilmAdi"].ToString());
                }

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }



            try
            {
                SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=sinema bileti;Persist Security Info=True;User ID=sa;Password=1;");
                baglanti.Open();

                // FilmAdi'ları çekip comboBox1'e doldur
                SqlCommand filmKomut = new SqlCommand("SELECT FilmAdi FROM Film_Bilgileri", baglanti);
                SqlDataReader filmDr = filmKomut.ExecuteReader();
                while (filmDr.Read())
                {
                    comboBox1.Items.Add(filmDr["FilmAdi"].ToString());
                }
                filmDr.Close();

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

        private void filmvesalongoster(ComboBox combo, string sql, string sql2)

        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {





        }
    }
}
      
    


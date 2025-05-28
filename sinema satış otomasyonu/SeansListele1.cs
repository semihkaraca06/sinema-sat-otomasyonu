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
    public partial class SeansListele1 : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=sinema bileti;Persist Security Info=True;User ID=sa;Password=1;");

        public SeansListele1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Bağlantıyı aç

            try
            {
                baglanti.Open();

                // SQL komutu
                string sql = "SELECT * FROM Seans_Bilgileri";

                SqlCommand komut = new SqlCommand(sql, baglanti);

                // Verileri çek
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();

                da.Fill(dt);

                // dataGridView’e ata
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                // Bağlantıyı kapat
                baglanti.Close();
            }




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

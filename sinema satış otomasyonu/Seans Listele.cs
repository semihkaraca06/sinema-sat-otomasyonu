using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sinema_satış_otomasyonu
{
    public partial class Seans_Listele : Form
    {

        SqlConnetion baglanti = new SqlConnetion("Data Source=.\\sqlexpress;Initial Catalog=\"sinema bileti\";Persist Security Info=True;User ID=sa;Password=1;Trust Server Certificate=True");
        public Seans_Listele()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            var adapter = new sinemaDataSetTableAdapters.Seans_BilgileriTableAdapter();
            var data = adapter.GetData(); // Seans_Bilgileri tablosundaki tüm verileri al

            // DataGridView'e ata
            dataGridView1.DataSource = data;
        }


    }
}

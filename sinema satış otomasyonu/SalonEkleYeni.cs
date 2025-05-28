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
    public partial class SalonEkleYeni : Form
    {
        public SalonEkleYeni()
        {
            InitializeComponent();
        }
        sinemaTableAdapters.Salon_BilgileriTableAdapter salon = new sinemaTableAdapters.Salon_BilgileriTableAdapter();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                salon.SalonEkleme(textBox1.Text);
                MessageBox.Show("Salon Eklendi", "Kayıt");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Aynı salonu daha önce eklediniz!","Uyarı");
            }
            textBox1.Text = "";

        }
    }
}

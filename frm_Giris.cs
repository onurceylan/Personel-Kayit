using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_Kayit
{
    public partial class frm_Giris : Form
    {
        public frm_Giris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=ONURPC\\MSSQLSERVER01;Initial Catalog=PersonelVeriTabani;Integrated Security=True;");

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Yonetici where KullaniciAd=@p1 and Sifre = @p2", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmAnaForm frm = new FrmAnaForm();
                frm.Show(); // ana forma git
                this.Hide(); // giriş formunu sakla
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı ya da Şifre");
            }

            baglanti.Close();

        }
    }
}


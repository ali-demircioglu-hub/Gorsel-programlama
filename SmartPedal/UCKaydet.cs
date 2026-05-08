using Jacobi.Vst.Interop.Host;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SmartPedal
{
    public partial class UCKaydet : UserControl
    {
      
        public UCKaydet()
        {
            InitializeComponent();
        }
        public static string EklentiAdi { get; set; }
     
        private void btnKaydet_Click(object sender, EventArgs e)
        {


            // 1. Güvenlik Kontrolleri
            if (string.IsNullOrWhiteSpace(txtKayitAdi.Text))
            {
                MessageBox.Show("Lütfen kaydetmek için bir Preset (Ton) adı girin!");
                return;
            }

            if (OrtakHafiza.AktifPlugin == null)
            {
                MessageBox.Show("Ekranda ayarları kaydedilecek açık bir pedal/amfi yok!");
                return;
            }

            try
            {
                // 2. VST'den Ayarları (Chunk) Çekme 
                byte[] pedalAyarlari = OrtakHafiza.AktifPlugin.PluginCommandStub.GetChunk(true);

                string presetAdi = txtKayitAdi.Text;
                string eklentiAdi = EklentiAdi;

                // 3. SQL Server Bağlantı Cümlesi (ConnectionString)
                // Eğer SSMS'e girerken Server Name kısmında '.\SQLEXPRESS' yazıyorsa Data Source=.\SQLEXPRESS yap.
                string connectionString = "Data Source='ALI\\SQLEXPRESS';Initial Catalog=SmartPedal;Integrated Security=True;";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 4. Verileri Veritabanına Kaydetme (INSERT)
                    string kayitSorgusu = "INSERT INTO Tonlar (TonAdi, Eklenti, Ayarlar) VALUES (@ad, @eklenti, @ayar)";

                    using (SqlCommand cmd = new SqlCommand(kayitSorgusu, conn))
                    {
                        // Parametreleri ekliyoruz 
                        cmd.Parameters.AddWithValue("@ad", presetAdi);
                        cmd.Parameters.AddWithValue("@eklenti", eklentiAdi);
                        cmd.Parameters.AddWithValue("@ayar", pedalAyarlari); // Byte verisi VARBINARY'ye gidiyor

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Ton başarıyla SQL Server'a kaydedildi!", "Veritabanı İşlemi Başarılı");
                txtKayitAdi.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Server Hatası: " + ex.Message);
            }
        }

        
    }
    }


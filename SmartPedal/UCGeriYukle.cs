using Jacobi.Vst.Interop.Host;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPedal
{
    public partial class UCGeriYukle : UserControl
    {
        public Panel AnaSahne;
        public string _klasorYolu = @"C:\Users\demir\OneDrive\Desktop\dll formatındaki amfiler";
        public string eklentiAdi = "";
        public static string TamDosyaYolu = "";
        public UCGeriYukle()

        {
            InitializeComponent();

        }

        public void btnTonYukle_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen yüklemek istediğiniz tonu listeden seçin!");
                return;
            }

            // ListBox'ta bir şey seçili değilse uyar
            // if (listBox1.SelectedItem == null)
            // {
            //     MessageBox.Show("Lütfen yüklemek için listeden bir ton seçin!");
            //     return;
            // }

            // if (_pluginContext == null)
            // {
            //    MessageBox.Show("Lütfen önce tonu yükleyeceğiniz eklentiyi (pedal/amfi) açın!");
            //    return;
            // }

            // ListBox'ta seçili olan metni alıyoruz

            // SqlDataReader reader = cmd.ExecuteReader();

            else
            {
                AnaSahne.Controls.Clear();
                string tamDosyaYolu = Path.Combine(_klasorYolu, eklentiAdi + ".dll");
                try
                {
                    // 2. Eğer ekranda zaten açık olan eski bir plugin varsa, çökmeyi önlemek için onu kapatıyoruz
                    if (OrtakHafiza.AktifPlugin != null)
                    {
                        OrtakHafiza.AktifPlugin.PluginCommandStub.EditorClose();
                        OrtakHafiza.AktifPlugin.Dispose();
                    }

                    // 3. İŞTE EKSİK OLAN HAYATİ KISIM: Yeni plugini hafızaya al ve çalıştır!
                    OrtakHafiza.AktifPlugin = VstPluginContext.Create(tamDosyaYolu, new DummyHost());
                    OrtakHafiza.AktifPlugin.PluginCommandStub.Open();
                    OrtakHafiza.AktifPlugin.PluginCommandStub.MainsChanged(true);

                    // 4. Şimdi arayüzü çizebiliriz
                    AnaSahne.Controls.Clear();

                    System.Drawing.Rectangle rect = new System.Drawing.Rectangle();
                    // Artık _pluginContext 'null' olmadığı için bu satır hata vermeyecek:
                    OrtakHafiza.AktifPlugin.PluginCommandStub.EditorGetRect(out rect);

                    AnaSahne.Width = rect.Width;
                    AnaSahne.Height = rect.Height;

                    // 5. Plugini Form1'den gelen AnaSahne'nin içine gömüyoruz
                    OrtakHafiza.AktifPlugin.PluginCommandStub.EditorOpen(AnaSahne.Handle);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eklenti yüklenirken hata oluştu: " + ex.Message, "Hata");
                }


                try
                {
                    string connectionString = "Data Source='ALI\\SQLEXPRESS';Initial Catalog=SmartPedal;Integrated Security=True;";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string sorgu = "SELECT Eklenti, Ayarlar FROM Tonlar WHERE TonAdi = @ad";
                        using (SqlCommand cmd = new SqlCommand(sorgu, conn))
                        {
                            string secilenTon = listBox1.SelectedItem.ToString();
                            cmd.Parameters.AddWithValue("@ad", secilenTon);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {

                                    byte[] yuklenecekAyarlar = (byte[])reader["Ayarlar"];

                                    string dbEklentiAdi = reader["Eklenti"].ToString();
                                    string aktifEklentiAdi = OrtakHafiza.AktifPlugin.PluginCommandStub.GetEffectName();
                                    // if (aktifEklentiAdi != dbEklentiAdi)
                                    // {
                                    //    MessageBox.Show($"Bu ton '{dbEklentiAdi}' için kaydedilmiş. Şu an ekranda '{aktifEklentiAdi}' açık.", "Uyumsuz Eklenti");
                                    //     return;
                                    // }

                                    // Chunk verisini pedala gönder
                                    OrtakHafiza.AktifPlugin.PluginCommandStub.SetChunk(yuklenecekAyarlar, true);
                                    MessageBox.Show("Ton başarıyla yüklendi!");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }

            }
        }


        private void UCGeriYukle_Load(object sender, EventArgs e)
        {


            listBox1.Items.Clear(); // ComboBox yerine ListBox adını yazıyoruz
            string connectionString = "Data Source='ALI\\SQLEXPRESS';Initial Catalog=SmartPedal;Integrated Security=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sorgu = "SELECT TonAdi AS TonBilgisi FROM Tonlar";
                    using (SqlCommand cmd = new SqlCommand(sorgu, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listBox1.Items.Add(reader["TonBilgisi"].ToString()); // Veriler ListBox'a ekleniyor
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tonlar listelenirken hata: " + ex.Message);
            }
        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1. Eğer listede hiçbir şey seçili değilse boşuna kod çalıştırma
            if (listBox1.SelectedItem == null) return;

            // 2. Seçili tonun adını ListBox'tan al
            string secilenTon = listBox1.SelectedItem.ToString();

            // (Bağlantı cümleni kendi bilgisayarına göre, örneğin 'ALI\\SQLEXPRESS' olarak ayarlamayı unutma)
            string connectionString = @"Data Source=ALI\SQLEXPRESS;Initial Catalog=SmartPedal;Integrated Security=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 3. Veritabanına soruyoruz: "TonAdi bu olan kaydın Eklenti'si nedir?"
                    string sorgu = "SELECT Eklenti FROM Tonlar WHERE  TonAdi = @ad";

                    using (SqlCommand cmd = new SqlCommand(sorgu, conn))
                    {
                        cmd.Parameters.AddWithValue("@ad", secilenTon);

                        // 4. ExecuteScalar: Sadece tek bir değer (string) döneceği için bunu kullanıyoruz
                        object sonuc = cmd.ExecuteScalar();

                        if (sonuc != null)
                        {
                            // İŞTE EKLENTİ ADI ELİNDE!
                            eklentiAdi = sonuc.ToString();

                            // Artık bu ismi istediğin gibi kullanabilirsin. 
                            // Örnek 1: Ekranda bir Label'a yazdırabilirsin:
                            // lblEklentiBilgisi.Text = "Gerekli Eklenti: " + eklentiAdi;

                            // Örnek 2: Kullanıcıya mesaj kutusuyla gösterebilirsin:
                             MessageBox.Show("Seçtiğiniz bu ton şu eklentiye ait: " + eklentiAdi, "Eklenti Bilgisi");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eklenti adı çekilirken hata oluştu: " + ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz tonu listeden seçin!");
                return;
            }
            else
            {
                try
                {
                    string connectionString = @"Data Source=ALI\SQLEXPRESS;Initial Catalog=SmartPedal;Integrated Security=True;";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sorgu = "DELETE FROM Tonlar WHERE TonAdi = @ad";
                        using (SqlCommand cmd = new SqlCommand(sorgu, conn))
                        {
                            cmd.Parameters.AddWithValue("@ad", listBox1.SelectedItem.ToString());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    listBox1.Items.Remove(listBox1.SelectedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ton silinirken hata oluştu: " + ex.Message);
                    return;
                }

            }
        }

    }
}

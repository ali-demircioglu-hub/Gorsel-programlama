using Jacobi.Vst.Interop.Host;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPedal
{
    public partial class UCYukle : UserControl
    {
      
        
        public Panel AnaSahne { get; set; }   
        private string _klasorYolu = @"C:\Users\demir\OneDrive\Desktop\dll formatındaki amfiler";
        public UCYukle()
        {
            InitializeComponent();
          
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
          


        }

        private void btnload2_Click(object sender, EventArgs e)
        {  string secilenEklentiAdi = comboBox1.SelectedItem.ToString();
            string tamDosyaYolu = Path.Combine(_klasorYolu, secilenEklentiAdi + ".dll");
           // AnaSahne.Controls.Clear();
            UCGeriYukle.TamDosyaYolu= tamDosyaYolu;
            UCKaydet.EklentiAdi= secilenEklentiAdi;
            try
            {
                // 2. Eğer ekranda zaten açık olan eski bir plugin varsa, çökmeyi önlemek için onu kapatıyoruz
                if (OrtakHafiza.AktifPlugin != null)
                {
                    OrtakHafiza.AktifPlugin.PluginCommandStub.EditorClose();
                    OrtakHafiza.AktifPlugin.Dispose();
                    AnaSahne.Controls.Clear();
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
        }

        private void UCYukle_Load(object sender, EventArgs e)
        { try {
        
            string[] eklentiler = Directory.GetFiles(_klasorYolu, "*.dll");
        foreach (string eklentiYolu in eklentiler)
    {
        // Sadece dosyanın adını (uzantısız) alıp ComboBox'a ekleriz
        string eklentiAdi = Path.GetFileNameWithoutExtension(eklentiYolu);
        comboBox1.Items.Add(eklentiAdi);
    }


}
            catch (Exception ex)
            {
    MessageBox.Show("Klasör bulunamadı: " + ex.Message);
} comboBox1.SelectedIndex = 0;

        }
    }
}

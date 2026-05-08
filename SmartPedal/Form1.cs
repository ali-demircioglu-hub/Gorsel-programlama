using Jacobi.Vst.Core.Host;
using Jacobi.Vst.Interop.Host;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPedal
{
    
    public partial class Form1 : Form
    {    public UCYukle uc1;
         public UCKaydet uc2;
         public UCGeriYukle uc3;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        

        private void btnload_Click(object sender, EventArgs e)
        { 
            panel3.Controls.Clear();
            UCYukle uc1 = new UCYukle();
            uc1.AnaSahne = panel1;
    
            uc1.Dock = DockStyle.Fill;
            panel3.Controls.Add(uc1);
        }

        private void btnkayit_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            UCKaydet  uc1 = new UCKaydet(); 
            uc1.Dock = DockStyle.Fill;
            panel3.Controls.Add(uc1);
        }

        private void btnfeedback_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            UCGeriYukle uc1 = new UCGeriYukle();
            uc1.AnaSahne = panel1;
            
            uc1.Dock = DockStyle.Fill;
            panel3.Controls.Add(uc1);
            
        }

    }
    public class DummyHost : IVstHostCommandStub
    {
        public IVstPluginContext PluginContext { get; set; }

        // --- IVstHostCommands10 Eksikleri ---
        public int GetVersion() { return 1; }
        public int GetCurrentPluginID() { return 0; }
        public void ProcessIdle() { }
        public void SetParameterAutomated(int index, float value) { }
        public int GetInputLatency() { return 0; }

        // --- IVstHostCommands20 Eksikleri ---
        public int GetOutputLatency() { return 0; }
        public Jacobi.Vst.Core.VstHostLanguage GetLanguage() { return Jacobi.Vst.Core.VstHostLanguage.English; }

        // --- Diğer Temel Komutlar ---
        public string GetDirectory() { return null; }
        public bool UpdateDisplay() { return false; }
        public bool IoChanged() { return false; }
        public bool SizeWindow(int width, int height) { return false; }
        public bool OpenFileSelector(Jacobi.Vst.Core.VstFileSelect fileSelect) { return false; }
        public bool CloseFileSelector(Jacobi.Vst.Core.VstFileSelect fileSelect) { return false; }
        public bool BeginEdit(int index) { return false; }
        public bool EndEdit(int index) { return false; }
        public Jacobi.Vst.Core.VstAutomationStates GetAutomationState() { return Jacobi.Vst.Core.VstAutomationStates.Unsupported; }
        public int GetBlockSize() { return 1024; }
        public int GetEngineVersion() { return 2; }
        public Jacobi.Vst.Core.VstProcessLevels GetProcessLevel() { return Jacobi.Vst.Core.VstProcessLevels.Unknown; }
        public string GetProductString() { return "SmartChain Host"; }
        public float GetSampleRate() { return 44100f; }
        public Jacobi.Vst.Core.VstTimeInfo GetTimeInfo(Jacobi.Vst.Core.VstTimeInfoFlags filterFlags) { return null; }
        public string GetVendorString() { return "Ali"; }
        public int GetVendorVersion() { return 1; }
        public Jacobi.Vst.Core.VstCanDoResult CanDo(string cando) { return Jacobi.Vst.Core.VstCanDoResult.Unknown; }
        public bool ProcessEvents(Jacobi.Vst.Core.VstEvent[] events) { return false; }
    }
    public static class OrtakHafiza
    {
        public static VstPluginContext AktifPlugin { get; set; }
        public static string AktifEklentiAdi { get; set; }
    }
}

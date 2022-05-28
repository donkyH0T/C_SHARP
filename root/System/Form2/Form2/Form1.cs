using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form2
{
    public partial class Form1 : Form
    {
        private DateTime Checkdate = new DateTime();
        private Process[] processlist = Process.GetProcesses();
        private string FilePathDir = (Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf(@"root\") + 4));
        FileStream fs,fss;
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            fs = new FileStream(Path.Combine(FilePathDir, @"System\FileManager\Process.txt"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 16, true);
            fss = new FileStream(Path.Combine(FilePathDir, @"System\FileManager\ChangeDir.txt"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 16, true);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
                
        }
        private void CheckProc()
        {
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);
            while (fs.Read(b, 0, b.Length) > 0)
            {
                richTextBox1.AppendText(temp.GetString(b));   
            }
        }
        private void CheckRenameDir()
        {
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);
            while (fss.Read(b, 0, b.Length) > 0)
            {
                richTextBox2.AppendText(temp.GetString(b));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckProc();
            CheckRenameDir();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

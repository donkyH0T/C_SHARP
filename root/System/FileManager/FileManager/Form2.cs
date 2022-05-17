using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FileManager
{
    public partial class Form2 : Form
    {
        private Process[] processlist = Process.GetProcesses();
        private string FilePathDir = (Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf(@"root\") + 4));
        public Form2()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                try
                {
                    comboBox1.Items.Add(theprocess.ProcessName);
                }
                catch (Exception)
                {

                }
           }
            timer1.Interval = 10000;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process []procname = Process.GetProcessesByName(comboBox1.Text);
            foreach(Process process in procname)
            {
               PerformanceCounter ramCounter = new PerformanceCounter("Process", "Working Set", process.ProcessName);
                double ram = ramCounter.NextValue();
                textBox1.Text = "Process: " + process.ProcessName + "  ID: " + process.Id + "  Ram: " + ram;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamReader streamReader = new StreamReader(Path.Combine(FilePathDir, @"System\FileManager\logi.txt")))
            {
                
                textBox2.Text = streamReader.ReadToEnd();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
    }
}

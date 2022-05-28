using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FileManager
{
    public partial class Form3 : Form
    {

        public string last = "";
        public string action;
        public string tmp;
        private string FilePathDir = (Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf(@"Users") + 5));
        public string disktop = Path.Combine((Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf(@"Users") + 5)), Environment.UserName);
        public string SX;
        public Process process;

        public Form3()
        {
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            richTextBox1.AppendText(disktop + ">");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void requestsWindows()
        {

            action = action.Substring(action.LastIndexOf(">") + 1, action.Length - action.LastIndexOf(">") - 1);

            int index = action.LastIndexOf(" ");
            if (index > 0)
            {
                tmp = action.Substring(index, action.Length - index);
                action = action.Substring(0, index);

            }
            //System.Console.WriteLine(action);

            DirectoryInfo directoryInfo;

            richTextBox1.Text = "";
            switch (action)
            {

                case "powershell.exe":
                    Process.Start(Path.Combine(FilePathDir, Environment.UserName));
                    richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    break;
                case "dir": //отображение каталогов
                    directoryInfo = new DirectoryInfo(Path.Combine(FilePathDir, Environment.UserName));
                    FileInfo[] files = directoryInfo.GetFiles();
                    DirectoryInfo[] dirs = directoryInfo.GetDirectories();
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        richTextBox1.AppendText("  <DIR>\t" + dirs[i].Name + "\n");
                    }
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (files[i].Length < 20)
                            richTextBox1.AppendText("        \t" + files[i].Name + "\n");
                    }

                    richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    break;
                case "ping.exe": //пингануть сайт--сделать
                    process = Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd",
                        Arguments = "/c chcp 65001 && " + "ping.exe" + " " + tmp,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    });
                    richTextBox1.AppendText("\n" + process.StandardOutput.ReadToEnd());
                    richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    break;
                case "notepad.exe"://открыть блокнот
                    Process.Start("notepad.exe");
                    richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    break;
                case "explorer.exe":
                    Process.Start(Path.Combine(FilePathDir, Environment.UserName));
                    richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    break;
                case "cd":
                    if (Directory.Exists(tmp))
                    {
                        disktop = tmp;
                        richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                        tmp = null;
                    }
                    else
                    {
                        richTextBox1.AppendText("Нет такого!!\n");
                        richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    }
                    break;
                case "cd..":
                    disktop = disktop.Substring(0, disktop.LastIndexOf(@"\"));
                    richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    break;
                case "mkdir": //создание каталог
                    string pathString = (disktop.LastIndexOf(">") == disktop.Length - 1) ? disktop : Path.Combine(disktop, tmp);
                    Directory.CreateDirectory(pathString);
                    richTextBox1.Text = "был создан каталог " + tmp + "!\n";
                    richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    break;
                case "rmdir":// удаление
                    string deleteString = Path.Combine(disktop, tmp);
                    if (Directory.Exists(deleteString))
                    {
                        Directory.Delete(deleteString, false);
                        richTextBox1.Text = " каталог " + tmp + " удалён\n";
                    }
                    else
                    {
                        richTextBox1.AppendText("Ощибка\n");
                    }
                    richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    break;
                case "getmac":
                    process = Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd",
                        Arguments = "/c chcp 65001 && " + "getmac",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    });
                    richTextBox1.AppendText("\n" + process.StandardOutput.ReadToEnd());
                    richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    break;
                case "tracert":
                    process = Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd",
                        Arguments = "/c chcp 65001 && " + "tracert" + " " + tmp,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    });
                    richTextBox1.AppendText("\n" + process.StandardOutput.ReadToEnd());
                    richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    break;

                default:
                    richTextBox1.AppendText("Такой команды нет\n");
                    richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    break;
            }

        }
        private void requestsLinux()
        {
            action = action.Substring(action.LastIndexOf(">") + 1, action.Length - action.LastIndexOf(">") - 1);

            int index = action.LastIndexOf(" ");
            if (index > 0)
            {
                tmp = action.Substring(index, action.Length - index);
                action = action.Substring(0, index);

            }
            DirectoryInfo directoryInfo;
            richTextBox1.Text = "";
            switch (action)
            {
                case "cd":
                    if (Directory.Exists(tmp))
                    {
                        disktop = tmp;
                        richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                        tmp = null;
                    }
                    else
                    {
                        richTextBox1.AppendText("Нет такого!!\n");
                        richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    }
                    break;
                case "cd..":
                    disktop = disktop.Substring(0, disktop.LastIndexOf(@"\"));
                    richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    break;

                case "ls":
                    directoryInfo = new DirectoryInfo(Path.Combine(FilePathDir, Environment.UserName));
                    FileInfo[] files = directoryInfo.GetFiles();
                    DirectoryInfo[] dirs = directoryInfo.GetDirectories();
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        richTextBox1.AppendText("  <DIR>\t" + dirs[i].Name + "\n");
                    }
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (files[i].Length < 20)
                            richTextBox1.AppendText("        \t" + files[i].Name + "\n");
                    }

                    richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    break;
                case "mkdir":
                    string pathString = (disktop.LastIndexOf(":") == disktop.Length - 1) ? disktop : Path.Combine(disktop, tmp);
                    Directory.CreateDirectory(pathString);
                    richTextBox1.Text = "был создан каталог " + tmp + "!\n";
                    richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    break;
                case "ping":
                    process = Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd",
                        Arguments = "/c chcp 65001 && " + "ping.exe" + " " + tmp,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    });
                    richTextBox1.AppendText("\n" + process.StandardOutput.ReadToEnd());
                    richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    break;
                case "rmdir":
                    string deleteString = Path.Combine(disktop, tmp);
                    if (Directory.Exists(deleteString))
                    {
                        Directory.Delete(deleteString, false);
                        richTextBox1.Text = " каталог " + tmp + " удалён\n";
                    }
                    else
                    {
                        richTextBox1.AppendText("Ощибка\n");
                    }
                    richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    break;
                case "tracepath":
                    process = Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd",
                        Arguments = "/c chcp 65001 && " + "tracert" + " " + tmp,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    });
                    richTextBox1.AppendText("\n" + process.StandardOutput.ReadToEnd());
                    richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    break;
                case "pwd":
                    richTextBox1.Text = "полный путь вашей дириктории: " + Path.Combine(disktop, tmp);
                    richTextBox1.AppendText("\n" + disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    break;
                case "size":
                    DirectoryInfo directory = new DirectoryInfo(disktop);
                    richTextBox1.Text = "Каталог " + disktop + " содержит следующие файлы:";
                    foreach (FileInfo f in directory.GetFiles())
                    {
                        richTextBox1.Text += "\n" + "Размер " + f.Name + " составляет " + f.Length + " байт.";
                    }
                    richTextBox1.AppendText("\n" + disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    break;
                case "ifconfig":
                    process = Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd",
                        Arguments = "/c chcp 65001 && " + "ipconfig",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    });
                    richTextBox1.AppendText("\n" + process.StandardOutput.ReadToEnd());
                    richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    break;
                default:
                    richTextBox1.AppendText(disktop + ((disktop.LastIndexOf(">") == disktop.Length - 1) ? " " : ">"));
                    break;
            }
        }

        private void richTextBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            {
                e.SuppressKeyPress = true;
            }

            string[] line = richTextBox1.Lines;
            int len = richTextBox1.Lines.Length - 1;
            if (e.KeyCode == Keys.Enter)
            {
                action = line[len];
                e.SuppressKeyPress = true;
                if(SX=="Windows")
                    requestsWindows();
                if (SX == "Linux")
                    requestsLinux();
            }
            if (e.KeyCode == Keys.Back)
            {

                if (disktop + ">" == line[len])
                    e.SuppressKeyPress = true;

            }
        }
    }
}

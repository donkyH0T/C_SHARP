using System;  
using System.ComponentModel; 
using System.Diagnostics; 
using System.Drawing; 
using System.IO;  
using System.Management;
using System.Text;
using System.Threading;
using System.Windows.Forms; 

namespace FileManager
{
    public partial class Form1 : Form
    {
        private string FilePath= (Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf(@"root\") + 4));
        private string FilePathDir= (Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf(@"root\") + 4));
        private bool isFile = false;
        private string currentlySelectedItemName = "";
        private string itempath;
        private string CopyItem;
        private DateTime date = new DateTime();
        private Button button1;
        private string but="";
        private Process form2;
        private TextBox text;
        private Form form;
        private static FileStream fs,fss;
        private Process[] processes;
        EventWatcherOptions eventOptions;
        string query = "SELECT * FROM" +
               " __InstanceCreationEvent WITHIN 1 " +
               "WHERE TargetInstance isa \"Win32_Process\"";
        ManagementEventWatcher watcher;
        public Form1()
        {
            watcher =
                new ManagementEventWatcher("root\\CIMV2", query, eventOptions);
            watcher.EventArrived += new EventArrivedEventHandler(ProcessStartEvent);
            watcher.Start();
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            eventOptions = new
                EventWatcherOptions
            {
                Timeout = System.TimeSpan.MaxValue
            };
            InitializeComponent();
            saveFileDialog1.Filter = "Text File(*.txt)|*.txt";
            date = DateTime.Now;
            timer1.Enabled = true;
            fs= new FileStream(Path.Combine(FilePathDir, @"System\FileManager\Process.txt"), FileMode.Create, FileAccess.Write, FileShare.ReadWrite, 16, true);
            fss = new FileStream(Path.Combine(FilePathDir, @"System\FileManager\ChangeDir.txt"), FileMode.Create, FileAccess.Write, FileShare.ReadWrite, 16, true);
            Thread th = new Thread(new ThreadStart(CheckProc));
            th.Start();
            
        }

        private static void ProcessStartEvent(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject b = e.NewEvent;
              string tmp = (((ManagementBaseObject)b["TargetInstance"])["Name"]).ToString();
            tmp = tmp.Substring(0, tmp.LastIndexOf("."));
            Process[] er = Process.GetProcessesByName(tmp);
            foreach(var process in er)
            {
                using (PerformanceCounter ramCounter = new PerformanceCounter("Process", "Working Set", process.ProcessName))
                {
                    try
                    {
                        if (process.Id == 0 || process.Id == 4) continue;
                        if (process.ProcessName == "ScriptedSandbox64" || process.ProcessName == "conhost" || process.ProcessName == "WmiPrvSE" || process.ProcessName == "conhost" || process.ProcessName == "svchost") continue;
                        double ram = ramCounter.NextValue();
                        string tpp = "Process: " + process.ProcessName + "  ID: " + process.Id + "  Ram: " + ram + "\n";
                        AddText(fs, tpp);
                    }
                    catch (Exception) { }
                }
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File_Path_textbox.Text.Contains(FilePathDir))
            {
                LoadButtonAction();
            }
            else
            {
                File_Path_textbox.Text = FilePathDir;
            }
        }
        public void LoadButtonAction()
        {
            if (File_Path_textbox.Text.Contains(FilePathDir))
            {
                removebackslash();
                FilePath = File_Path_textbox.Text;
                LoadFileAndDir();
                isFile = false;
            }
            else
            {
                File_Path_textbox.Text = FilePathDir;
            }
        }
        public void LoadFileAndDir()
        {
            DirectoryInfo filelist;
            string tempFilePath = "";
            FileAttributes fileAttr;
            try
            {
                if (isFile)
                {
                    tempFilePath = FilePath + "/" + currentlySelectedItemName;
                    FileInfo fileDetails = new FileInfo(tempFilePath);
                    File_name_label.Text = fileDetails.Name;
                    File_type_label.Text = fileDetails.Extension;
                    fileAttr = File.GetAttributes(tempFilePath);
                    Process.Start(tempFilePath);
                }
                else
                {
                    fileAttr = File.GetAttributes(FilePath);
                    
                    
                }
                if ((fileAttr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    listView1.Items.Clear();
                    filelist = new DirectoryInfo(FilePath);
                    FileInfo[] files = filelist.GetFiles(); //get all file
                    DirectoryInfo[] dirs = filelist.GetDirectories(); //get all dir
                    listView1.Clear();
                    string fileExtension = "";
                    for (int i = 0; i < files.Length; i++)
                    {
                        fileExtension = files[i].Extension.ToUpper();
                        switch (fileExtension)
                        {
                            case ".PNG":
                                listView1.Items.Add(files[i].Name, 2);
                                break;
                            case ".TXT":
                                listView1.Items.Add(files[i].Name, 1);
                                break;
                            default:
                                listView1.Items.Add(files[i].Name, 0);
                                break;
                        }   
                    }
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        listView1.Items.Add(dirs[i].Name,3);
                    }
                }
                else
                {
                    File_name_label.Text = this.currentlySelectedItemName;
                }
            }
            catch (Exception)
            {

            }
        }
        public void removebackslash()
        {
            string path = File_Path_textbox.Text;
            if (path.LastIndexOf("/") == path.Length - 1)
            {
                File_Path_textbox.Text = path.Substring(0, path.Length - 1);
            }
        }
        public void goback()
        {
            try{
                removebackslash();
                string path = File_Path_textbox.Text;
                path = path.Substring(0, path.LastIndexOf("/"));
                isFile = false;
                if (path == FilePathDir)
                {
                    path = FilePathDir;
                    File_Path_textbox.Text = path;
                    removebackslash();
                    return;
                }
                    File_Path_textbox.Text = path;
                    removebackslash();   
            }
            catch
            {
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            File_Path_textbox.Text = FilePath;
            LoadFileAndDir();
            using (StreamWriter Writer = new StreamWriter(Path.Combine(FilePathDir, @"System\FileManager\logi.txt")))
            {

                Writer.Write("");
            }
       
            processes = new Process[50];
            listView1.AllowDrop = true;
            //CheckProc();
        }
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
          
            currentlySelectedItemName = e.Item.Text;
            itempath = (FilePath + "/" + currentlySelectedItemName);
            FileAttributes fileAttr = File.GetAttributes(FilePath + "/" + currentlySelectedItemName);
            if ((fileAttr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                isFile = false;
                File_Path_textbox.Text = FilePath + "/" + currentlySelectedItemName;

            }
            else
            {
                isFile = true;
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LoadButtonAction();
        }

        private void Back_button_Click(object sender, EventArgs e)
        {
            goback();
            LoadButtonAction();
        }

        private void взглянутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* Form2 form2 = new Form2();
            form2.Show();*/
            Form f;
            f = new Form();
            f.Size = new System.Drawing.Size(550, 550);
            f.Show();
            f.Activate();
            ListView q = new ListView();
            ImageList imageList = new ImageList();
            imageList.Images.Add(Image.FromFile(Path.Combine(FilePathDir, @"System\FileManager\пустая.png")));
            q.LargeImageList = imageList;
            q.Size = new System.Drawing.Size(500, 500);
            f.Controls.Add(q);
            Process[] proc = Process.GetProcesses();
            foreach (Process nam in proc)
            {
                try
                {
                    if (nam.StartTime > date)
                        q.Items.Add(nam.ProcessName, 0);
                }
                catch (Exception)
                {

                }
            }
        }
        private void windowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            form3.SX = "Windows";
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Язык программирования->C#\nКуренков Вячеслав Андреевич\nИВТ-03", "Операционные системы и оболочки");
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Process[] proc = Process.GetProcesses();
            RichTextBox richText = new RichTextBox();
            foreach (Process nam in proc)
            {
                try
                {
                    if (nam.StartTime > date)
                    {
                        richText.AppendText(nam.ProcessName);
                        try
                        {
                            richText.AppendText("  " + nam.StartTime + "\n");
                        }
                        catch (Exception)
                        {
                            richText.AppendText("\n");
                        }
                    }
                }
                catch (Exception)
                {

                }

            }
            
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return ;
            }
            
            string FileName = saveFileDialog1.FileName;
            File.WriteAllText(FileName, richText.Text);
            MessageBox.Show("Файл сохранён!");
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process[] proc = Process.GetProcesses();
            RichTextBox richText = new RichTextBox();
            foreach (Process nam in proc)
            {
                try
                {
                    if (nam.StartTime > date)
                    {
                        richText.AppendText(nam.ProcessName);
                        try
                        {
                            richText.AppendText("  " + nam.StartTime + "\n");
                        }
                        catch (Exception)
                        {
                            richText.AppendText("\n");
                        }
                    }
                }
                catch (Exception)
                {

                }
               

            }
            
            string FileName = Path.Combine(FilePathDir, @"System\FileManager\Baza.txt");
            File.WriteAllText(FileName, richText.Text);
            MessageBox.Show("Файл сохранён!");
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Click.Show(MousePosition, ToolStripDropDownDirection.Right);
            }
        }
        private void deleteclick()
        {
            if (itempath == null)
            {
                return;
            }
            if (itempath.EndsWith("System"))
            {
                MessageBox.Show("НЕЛЬЗЯ");
                return;
            }
            if (itempath.EndsWith("Корзина"))
            {
                string[] files = System.IO.Directory.GetFiles(itempath);
                string[] kat = System.IO.Directory.GetDirectories(itempath);
                foreach (string s in files)
                {
                    File.Delete(s);
                }
                foreach (string s in kat)
                {
                    Directory.Delete(s, true);
                }
                return;
            }

            listView1.Items.RemoveByKey(itempath);

            if (Directory.Exists(itempath))
            {
                string a = Path.Combine(FilePathDir, "Корзина") + @"\" + itempath.Substring(itempath.LastIndexOf(@"/") + 1, itempath.Length - itempath.LastIndexOf(@"/") - 1);
                try { Directory.Move(itempath, a); }
                catch (Exception)
                {
                    try
                    {
                        Directory.Delete(itempath, true);
                    }
                    catch (Exception) { }

                }
            }
            if (File.Exists(itempath))
            {
                string a = Path.Combine(FilePathDir, "Корзина") + @"\" + itempath.Substring(itempath.LastIndexOf(@"/") + 1, itempath.Length - itempath.LastIndexOf(@"/") - 1);
                try { File.Move(itempath, a); }
                catch (Exception)
                {
                    try
                    {
                        File.Delete(itempath);
                    }
                    catch (Exception) { }
                }
            }
            Logirovanie(itempath, itempath, "удалён");
            goback();
            isFile = false;
            LoadButtonAction();
            itempath = null;
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            deleteclick();
        }
        private void listView1_ItemActivate(object sender, EventArgs e)
        {
        }

        private void listView1_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
        }

        private void listView1_Enter(object sender, EventArgs e)
        {
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyItem = itempath;
        }
        private void enter()
        {
            if (CopyItem == null)
            {
                return;
            }
            string fileName = CopyItem.Substring(CopyItem.LastIndexOf(@"/") + 1, CopyItem.Length - CopyItem.LastIndexOf(@"/") - 1);
            string targetPath = itempath;
            if (CopyItem == "System")
            {
                MessageBox.Show("Нельзя копировать системную папку");
                return;
            }
            if (System.IO.Directory.Exists(CopyItem))
            {
                string[] files = System.IO.Directory.GetFiles(CopyItem);
                string pathdir = "";
                if (Directory.Exists(Path.Combine(itempath, fileName)))
                {
                    MessageBox.Show("Такая папка существует");
                }
                else
                {
                    pathdir = Path.Combine(itempath, fileName);
                    Directory.CreateDirectory(pathdir);
                }
                foreach (string s in files)
                {
                    System.IO.File.Copy(s, Path.Combine(pathdir, Path.GetFileName(s)), true);
                }
                CopyItem = null;
                LoadButtonAction();
                return;
            }

            string destFile = System.IO.Path.Combine(targetPath, fileName);
            System.IO.File.Copy(CopyItem, destFile, true);
            CopyItem = null;
            LoadButtonAction();
        }
        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enter();
        }
        private void создатьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void папкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logirovanie(FilePath+@"/папка", itempath, "создан");
            Directory.CreateDirectory(Path.Combine(FilePath,"папка"));
            
            LoadButtonAction();
            
        }
        private void notepadtxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logirovanie(FilePath+@"/Блокнот.txt", itempath, "создан");
            File.CreateText(Path.Combine(FilePath, "Блокнот.txt"));
            
            LoadButtonAction();   
        }
        public void Logirovanie(string pathToFile, string pathNextFile,string file)
        {
            StreamWriter streamWriter = new StreamWriter(Path.Combine(FilePathDir, @"System\FileManager\logi.txt"), true);
            string text="";
            if(file== "переименован")
            {
                text = "Файл: " + pathToFile.Substring(pathToFile.LastIndexOf("/") + 1, pathToFile.Length - pathToFile.LastIndexOf(@"/") - 1) + " " + file + " " + pathNextFile.Substring(pathNextFile.LastIndexOf(@"\") + 1, pathNextFile.Length - pathNextFile.LastIndexOf(@"\") - 1) + " Дата: " + DateTime.Now + " " + SystemInformation.UserName + " " + Environment.MachineName;
            }
            if(file== "перенесён")
            {
                text = "Файл: " + pathToFile.Substring(pathToFile.LastIndexOf("/") + 1, pathToFile.Length - pathToFile.LastIndexOf(@"/") - 1) + " " + file + " " + pathNextFile.Substring(0,pathNextFile.LastIndexOf(@"\")) + " Дата: " + DateTime.Now + " " + SystemInformation.UserName + " " + Environment.MachineName;
            }
            if (file == "удалён")
            {
                text="Файл"+" "+pathToFile+" "+" "+file+" "+ SystemInformation.UserName + " " + Environment.MachineName;
            }
            if (file == "создан")
            {
                text = "Файл" + " " + pathToFile + " " + " " + file + " " + SystemInformation.UserName + " " + Environment.MachineName;
            }
            streamWriter.WriteLine(text);
            streamWriter.Close();
        }
        public void ChangeDir(string pathToFile,string pathNextFile)
        {
            string text;
            text = "Файл: " + pathToFile.Substring(pathToFile.LastIndexOf("/") + 1, pathToFile.Length - pathToFile.LastIndexOf(@"/") - 1) + " Переименован в: " + pathNextFile.Substring(pathNextFile.LastIndexOf(@"\") + 1, pathNextFile.Length - pathNextFile.LastIndexOf(@"\") - 1) + " Дата: " + DateTime.Now;
            CheckChangeDir(text);
        }
        private void button_Click(object sender, EventArgs e)
        {
            FileInfo info = new FileInfo(itempath);
            but = text.Text;
            string pop = itempath;
            pop = pop.Substring(0, pop.LastIndexOf(@"/"));
            if (but != "")
            {
                pop = Path.Combine(pop, but) + info.Extension;
                try
                {
                    if (File.Exists(itempath))
                    {
                        File.Move(itempath, pop);
                        Logirovanie(itempath, pop,"переименован");
                        form.Close();
                    }
                    if (Directory.Exists(itempath))
                    {
                        File_Path_textbox.Text = FilePath;
                        Directory.Move(itempath, pop);
                        Logirovanie(itempath, pop,"переименован");
                        ChangeDir(itempath, pop);
                        form.Close();
                    }
                }
                catch (Exception)
                {
                    form.Close();
                }
                isFile = false;
                itempath = null;
                LoadButtonAction();       
            }
        }
        private  void переименоватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (itempath == null)
            {
                return;
            }
            if (itempath.EndsWith("System") || itempath.EndsWith("Корзина"))
            {
                MessageBox.Show("Нельзя!");
                return;
            }
            FileInfo info = new FileInfo(itempath);   //хз как сделать вообще
            form = new Form();
           text = new TextBox();
               Click.Show(MousePosition, ToolStripDropDownDirection.Right);
            
            text.Text = "";
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Size = new System.Drawing.Size(200,80);
            button1 = new System.Windows.Forms.Button();
            button1.Location = new System.Drawing.Point(100, 0);
            button1.Text = "Клик";
            button1.Click += new EventHandler(this.button_Click);
            form.Controls.Add(text);
            form.Controls.Add(button1);
            form.Show();
        }

        private void Click_Opening(object sender, CancelEventArgs e)
        {

        }

        private void переключитьНаUSBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.DriveType == DriveType.Removable)
                {
                    string put;
                    put = (string.Format("{0}", drive.Name + "\\"));
                    string[] files = Directory.GetFiles(put);
                    listView1.Clear();
                    foreach (string file in files)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = file.Remove(0, file.LastIndexOf('\\') + 1);
                        lvi.ImageIndex = 0; 
                        listView1.Items.Add(lvi);
                    }

                    string[] files2 = Directory.GetDirectories(put);
                    foreach (string file in files2)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = file.Remove(0, file.LastIndexOf('\\') + 1);
                        lvi.ImageIndex = 3; 
                        listView1.Items.Add(lvi);
                    }
                    File_Path_textbox.Text=drive.Name;
                    FilePath = drive.Name;
                }
            }
        }
        private void подключитьUSBToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void отключитьUSBToolStripMenuItem_Click(object sender, EventArgs e)
        {  
        }
        private void goBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File_Path_textbox.Text = FilePathDir;
            FilePath = FilePathDir;
            LoadButtonAction();
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }
       
        private  void работаСПроцессамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
           form2 = Process.Start(Path.Combine(FilePathDir, @"System\Form2\Form2\bin\Release\netcoreapp3.1\Form2.exe"));
        }
        private void CheckProc()
        {
            processes = Process.GetProcesses();
            foreach (Process process in processes)
                try
                {
                    using (PerformanceCounter ramCounter = new PerformanceCounter("Process", "Working Set", process.ProcessName))
                    {
                        if (process.ProcessName == "ScriptedSandbox64" || process.ProcessName == "conhost" || process.ProcessName == "WmiPrvSE" || process.ProcessName == "conhost" || process.ProcessName == "svchost") continue;
                            double ram = ramCounter.NextValue();
                            string tmp = "Process: " + process.ProcessName + "  ID: " + process.Id + "  Ram: " + ram + "\n";
                            AddText(fs, tmp);   
                    }
                }
                catch (Exception)
                {

                }
        }
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
           fs.Write(info, 0, info.Length);
            
        }
        private void CheckChangeDir(string text)
        {
            AddText(fss, text+"\n");
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }
            System.Drawing.Point pt = listView1.PointToClient(new System.Drawing.Point(e.X, e.Y));
            ListViewItem itemdrag = listView1.GetItemAt(pt.X, pt.Y);
            if (itemdrag == null)
            {
                return;
            }
            if (itemdrag.Text=="System" || itemdrag.Text=="C")
            {
                MessageBox.Show("Нельзя");
                return;
            }
            string pathNext = itempath.Substring(0,itempath.LastIndexOf("/"));
            pathNext = Path.Combine(pathNext, itemdrag.Text);
            
            if (Directory.Exists(pathNext))
            {
                if (File.Exists(itempath))
                {
                    string tmp = Path.Combine(pathNext, itempath.Substring(itempath.LastIndexOf("/")+1,itempath.Length-itempath.LastIndexOf("/")-1));
                    try
                    {
                        if (File.Exists(tmp))
                        {
                            MessageBox.Show("Такой файл уже существует");
                            return;
                        }
                        isFile = false;
                        File.Move(itempath, tmp);
                        Logirovanie(itempath, tmp, "перенесён");
                        LoadButtonAction();
                        
                    }
                    catch (Exception)
                    {

                    }
                    
                }
                if (Directory.Exists(itempath))
                {
                    string tmp = Path.Combine(pathNext, itempath.Substring(itempath.LastIndexOf("/") + 1, itempath.Length - itempath.LastIndexOf("/") - 1));
                    try
                    {
                        if (Directory.Exists(tmp))
                        {
                            MessageBox.Show("Такой каталог уже существует");
                            return;
                        }
                        goback();
                        Directory.Move(itempath, tmp);
                        Logirovanie(itempath, tmp, "перенесён");
                        LoadButtonAction();

                    }
                    catch (Exception)
                    {

                    }
                }
            }
            }
        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (itempath.EndsWith("System")|| itempath.EndsWith("Корзина") || itempath.EndsWith("C"))
            {
                MessageBox.Show("Нельзя");
                return;
            }
            listView1.DoDragDrop(listView1.SelectedItems, DragDropEffects.Move);
        }
        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;   
        }
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\tСправка по командам терминала\n\tWindows\npowershell.exe--Открывает проводник\ndir--Отображение каталогов\nping.exe--пингануть сайт\nnotepad.exe--Открыть блокнот\nexplorer.exe--Открывает проводник\ncd--отображает имя текущего каталога указанного диска\n" +
                "cd..--возращается на каталог назад на указонном диске\nmkdir {Directory}--Создание каталога\nrmdir {Directory}--Удаление каталога\ngetmac--отображение физического адреса сетевого адаптера\ntracert--показывает трассировку маршрута до указанного удаленного хоста\n\tLinux\n" +
                "cd--отображает имя текущего каталога указанного диска\ncd..--возращается на каталог назад на указонном диске\nls--Отображение каталогов\nmkdir--Создание каталога\nrmdir--Удаление каталога\npwd [Directory]-- Полный путь вашей директории\nsize--Сколько места занимают файлы" +
                "\ntracepath--отслеживает сетевой путь до указанного адреса назначения и дает каждый переход на пути\nifconfig--просмотреть состояние всех включенных сетевых интерфейсов, включая их имена");
        }
        private void linuxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            form3.SX = "Linux";
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void МПвзаимодействиеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //CheckProc();
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try {

                if (form2 != null)
                {
                    form2.CloseMainWindow();
                }
            }
            catch (Exception) { }
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
                LoadButtonAction();
            if (e.KeyValue == (char)Keys.Escape)
                Close();

            if (e.KeyValue == (char)Keys.Delete)
            {
                deleteclick();
            }

            if (e.KeyValue == (char)Keys.C && e.Modifiers == Keys.Control)
            {
                CopyItem = itempath;
            }

            if (e.KeyValue == (char)Keys.V && e.Modifiers == Keys.Control)
            {
                enter();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
               
        }
    }
}

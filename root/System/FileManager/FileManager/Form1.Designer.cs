
namespace FileManager
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.Go_button = new System.Windows.Forms.Button();
            this.Back_button = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Click = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.копироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.папкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notepadtxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переименоватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Icon_List = new System.Windows.Forms.ImageList(this.components);
            this.File_Path_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.File_name_label = new System.Windows.Forms.Label();
            this.File_type_label = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.процессыОсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.взглянутьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.работаСПроцессамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.терминалToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linuxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.работаСUSBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переключитьНаUSBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ап = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Click.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 530);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "File_Name";
            // 
            // Go_button
            // 
            this.Go_button.Location = new System.Drawing.Point(668, 44);
            this.Go_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Go_button.Name = "Go_button";
            this.Go_button.Size = new System.Drawing.Size(75, 23);
            this.Go_button.TabIndex = 1;
            this.Go_button.Text = "Go";
            this.Go_button.UseVisualStyleBackColor = true;
            this.Go_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Back_button
            // 
            this.Back_button.Location = new System.Drawing.Point(0, 44);
            this.Back_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Back_button.Name = "Back_button";
            this.Back_button.Size = new System.Drawing.Size(75, 23);
            this.Back_button.TabIndex = 2;
            this.Back_button.Text = "Back";
            this.Back_button.UseVisualStyleBackColor = true;
            this.Back_button.Click += new System.EventHandler(this.Back_button_Click);
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.ContextMenuStrip = this.Click;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.Icon_List;
            this.listView1.Location = new System.Drawing.Point(12, 73);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(731, 406);
            this.listView1.SmallImageList = this.Icon_List;
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            this.listView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            this.listView1.Enter += new System.EventHandler(this.listView1_Enter);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
            // 
            // Click
            // 
            this.Click.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Click.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.копироватьToolStripMenuItem,
            this.вставитьToolStripMenuItem,
            this.создатьФайлToolStripMenuItem,
            this.переименоватьToolStripMenuItem});
            this.Click.Name = "contextMenuStrip1";
            this.Click.Size = new System.Drawing.Size(191, 124);
            this.Click.Opening += new System.ComponentModel.CancelEventHandler(this.Click_Opening);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(190, 24);
            this.toolStripMenuItem2.Text = "Удалить";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // копироватьToolStripMenuItem
            // 
            this.копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            this.копироватьToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.копироватьToolStripMenuItem.Text = "Копировать";
            this.копироватьToolStripMenuItem.Click += new System.EventHandler(this.копироватьToolStripMenuItem_Click);
            // 
            // вставитьToolStripMenuItem
            // 
            this.вставитьToolStripMenuItem.Name = "вставитьToolStripMenuItem";
            this.вставитьToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.вставитьToolStripMenuItem.Text = "Вставить";
            this.вставитьToolStripMenuItem.Click += new System.EventHandler(this.вставитьToolStripMenuItem_Click);
            // 
            // создатьФайлToolStripMenuItem
            // 
            this.создатьФайлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.папкаToolStripMenuItem,
            this.notepadtxtToolStripMenuItem});
            this.создатьФайлToolStripMenuItem.Name = "создатьФайлToolStripMenuItem";
            this.создатьФайлToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.создатьФайлToolStripMenuItem.Text = "Создать файл";
            this.создатьФайлToolStripMenuItem.Click += new System.EventHandler(this.создатьФайлToolStripMenuItem_Click);
            // 
            // папкаToolStripMenuItem
            // 
            this.папкаToolStripMenuItem.Name = "папкаToolStripMenuItem";
            this.папкаToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.папкаToolStripMenuItem.Text = "Папка";
            this.папкаToolStripMenuItem.Click += new System.EventHandler(this.папкаToolStripMenuItem_Click);
            // 
            // notepadtxtToolStripMenuItem
            // 
            this.notepadtxtToolStripMenuItem.Name = "notepadtxtToolStripMenuItem";
            this.notepadtxtToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.notepadtxtToolStripMenuItem.Text = "Блокнот";
            this.notepadtxtToolStripMenuItem.Click += new System.EventHandler(this.notepadtxtToolStripMenuItem_Click);
            // 
            // переименоватьToolStripMenuItem
            // 
            this.переименоватьToolStripMenuItem.Name = "переименоватьToolStripMenuItem";
            this.переименоватьToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.переименоватьToolStripMenuItem.Text = "Переименовать";
            this.переименоватьToolStripMenuItem.Click += new System.EventHandler(this.переименоватьToolStripMenuItem_Click);
            // 
            // Icon_List
            // 
            this.Icon_List.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Icon_List.ImageStream")));
            this.Icon_List.TransparentColor = System.Drawing.Color.Transparent;
            this.Icon_List.Images.SetKeyName(0, "пустая.png");
            this.Icon_List.Images.SetKeyName(1, "блокнот.png");
            this.Icon_List.Images.SetKeyName(2, "Снимок экрана 2022-04-30 233151.png");
            this.Icon_List.Images.SetKeyName(3, "R.png");
            // 
            // File_Path_textbox
            // 
            this.File_Path_textbox.Location = new System.Drawing.Point(81, 44);
            this.File_Path_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.File_Path_textbox.Name = "File_Path_textbox";
            this.File_Path_textbox.Size = new System.Drawing.Size(581, 22);
            this.File_Path_textbox.TabIndex = 4;
            this.File_Path_textbox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(467, 530);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "File_Type";
            // 
            // File_name_label
            // 
            this.File_name_label.AutoSize = true;
            this.File_name_label.Location = new System.Drawing.Point(189, 530);
            this.File_name_label.Name = "File_name_label";
            this.File_name_label.Size = new System.Drawing.Size(18, 17);
            this.File_name_label.TabIndex = 6;
            this.File_name_label.Text = "--";
            // 
            // File_type_label
            // 
            this.File_type_label.AutoSize = true;
            this.File_type_label.Location = new System.Drawing.Point(616, 530);
            this.File_type_label.Name = "File_type_label";
            this.File_type_label.Size = new System.Drawing.Size(18, 17);
            this.File_type_label.TabIndex = 7;
            this.File_type_label.Text = "--";
            this.File_type_label.Click += new System.EventHandler(this.label4_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 28);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(855, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьКакToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.процессыОсToolStripMenuItem,
            this.терминалToolStripMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.работаСUSBToolStripMenuItem,
            this.ап});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip2.Size = new System.Drawing.Size(855, 28);
            this.menuStrip2.TabIndex = 9;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip2_ItemClicked);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // процессыОсToolStripMenuItem
            // 
            this.процессыОсToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.взглянутьToolStripMenuItem,
            this.работаСПроцессамиToolStripMenuItem});
            this.процессыОсToolStripMenuItem.Name = "процессыОсToolStripMenuItem";
            this.процессыОсToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.процессыОсToolStripMenuItem.Text = "Процессы ос";
            // 
            // взглянутьToolStripMenuItem
            // 
            this.взглянутьToolStripMenuItem.Name = "взглянутьToolStripMenuItem";
            this.взглянутьToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.взглянутьToolStripMenuItem.Text = "Взглянуть";
            this.взглянутьToolStripMenuItem.Click += new System.EventHandler(this.взглянутьToolStripMenuItem_Click);
            // 
            // работаСПроцессамиToolStripMenuItem
            // 
            this.работаСПроцессамиToolStripMenuItem.Name = "работаСПроцессамиToolStripMenuItem";
            this.работаСПроцессамиToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.работаСПроцессамиToolStripMenuItem.Text = "Работа с процессами";
            this.работаСПроцессамиToolStripMenuItem.Click += new System.EventHandler(this.работаСПроцессамиToolStripMenuItem_Click);
            // 
            // терминалToolStripMenuItem
            // 
            this.терминалToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linuxToolStripMenuItem,
            this.windowsToolStripMenuItem});
            this.терминалToolStripMenuItem.Name = "терминалToolStripMenuItem";
            this.терминалToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.терминалToolStripMenuItem.Text = "Терминал";
            // 
            // linuxToolStripMenuItem
            // 
            this.linuxToolStripMenuItem.Name = "linuxToolStripMenuItem";
            this.linuxToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.linuxToolStripMenuItem.Text = "Linux";
            this.linuxToolStripMenuItem.Click += new System.EventHandler(this.linuxToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.windowsToolStripMenuItem.Text = "Windows";
            this.windowsToolStripMenuItem.Click += new System.EventHandler(this.windowsToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // работаСUSBToolStripMenuItem
            // 
            this.работаСUSBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.переключитьНаUSBToolStripMenuItem,
            this.goBackToolStripMenuItem});
            this.работаСUSBToolStripMenuItem.Name = "работаСUSBToolStripMenuItem";
            this.работаСUSBToolStripMenuItem.Size = new System.Drawing.Size(113, 24);
            this.работаСUSBToolStripMenuItem.Text = "Работа с USB";
            // 
            // переключитьНаUSBToolStripMenuItem
            // 
            this.переключитьНаUSBToolStripMenuItem.Name = "переключитьНаUSBToolStripMenuItem";
            this.переключитьНаUSBToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.переключитьНаUSBToolStripMenuItem.Text = "Переключить на USB";
            this.переключитьНаUSBToolStripMenuItem.Click += new System.EventHandler(this.переключитьНаUSBToolStripMenuItem_Click);
            // 
            // goBackToolStripMenuItem
            // 
            this.goBackToolStripMenuItem.Name = "goBackToolStripMenuItem";
            this.goBackToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.goBackToolStripMenuItem.Text = "GoBack";
            this.goBackToolStripMenuItem.Click += new System.EventHandler(this.goBackToolStripMenuItem_Click);
            // 
            // ап
            // 
            this.ап.Name = "ап";
            this.ап.Size = new System.Drawing.Size(156, 24);
            this.ап.Text = "toolStripMenuItem1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 687);
            this.Controls.Add(this.File_type_label);
            this.Controls.Add(this.File_name_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.File_Path_textbox);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.Back_button);
            this.Controls.Add(this.Go_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "FileManager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Click.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Go_button;
        private System.Windows.Forms.Button Back_button;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox File_Path_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label File_name_label;
        private System.Windows.Forms.Label File_type_label;
        private System.Windows.Forms.ImageList Icon_List;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem процессыОсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem взглянутьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem терминалToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linuxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip Click;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem копироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem папкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notepadtxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переименоватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem работаСUSBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переключитьНаUSBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goBackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem работаСПроцессамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ап;
        private System.Windows.Forms.Timer timer1;
    }
}


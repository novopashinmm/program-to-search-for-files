namespace FindFilesApplication
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.tbox_StartDir = new System.Windows.Forms.TextBox();
			this.btn_Explorer = new System.Windows.Forms.Button();
			this.btn_Find = new System.Windows.Forms.Button();
			this.fbd_StartDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.lbox_Result = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbox_FileForFind = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btn_Clear = new System.Windows.Forms.Button();
			this.tbox_TextForFind = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.flagRecursive = new System.Windows.Forms.CheckBox();
			this.btn_StopFind = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lbl_CurrentDirectory = new System.Windows.Forms.Label();
			this.lbl_Count = new System.Windows.Forms.Label();
			this.btn_SaveResult = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.lbl_Time = new System.Windows.Forms.Label();
			this.chb_Hidden = new System.Windows.Forms.CheckBox();
			this.chb_System = new System.Windows.Forms.CheckBox();
			this.chb_Arch = new System.Windows.Forms.CheckBox();
			this.chb_SaveResultPoisk = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tw_Result = new System.Windows.Forms.TreeView();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbox_StartDir
			// 
			this.tbox_StartDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbox_StartDir.Location = new System.Drawing.Point(12, 68);
			this.tbox_StartDir.Name = "tbox_StartDir";
			this.tbox_StartDir.Size = new System.Drawing.Size(490, 20);
			this.tbox_StartDir.TabIndex = 5;
			// 
			// btn_Explorer
			// 
			this.btn_Explorer.Location = new System.Drawing.Point(12, 9);
			this.btn_Explorer.Name = "btn_Explorer";
			this.btn_Explorer.Size = new System.Drawing.Size(100, 40);
			this.btn_Explorer.TabIndex = 6;
			this.btn_Explorer.Text = "Обозреватель...";
			this.btn_Explorer.UseVisualStyleBackColor = true;
			this.btn_Explorer.Click += new System.EventHandler(this.btn_Explorer_Click);
			// 
			// btn_Find
			// 
			this.btn_Find.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btn_Find.Location = new System.Drawing.Point(3, 3);
			this.btn_Find.Name = "btn_Find";
			this.btn_Find.Size = new System.Drawing.Size(127, 98);
			this.btn_Find.TabIndex = 7;
			this.btn_Find.Text = "Начать поиск";
			this.btn_Find.UseVisualStyleBackColor = true;
			this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
			// 
			// lbox_Result
			// 
			this.lbox_Result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbox_Result.FormattingEnabled = true;
			this.lbox_Result.Location = new System.Drawing.Point(0, 233);
			this.lbox_Result.Name = "lbox_Result";
			this.lbox_Result.Size = new System.Drawing.Size(801, 56);
			this.lbox_Result.TabIndex = 8;
			this.lbox_Result.DoubleClick += new System.EventHandler(this.lbox_Result_DoubleClick);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 52);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(122, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Стартовая директория";
			// 
			// tbox_FileForFind
			// 
			this.tbox_FileForFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbox_FileForFind.Location = new System.Drawing.Point(12, 112);
			this.tbox_FileForFind.Name = "tbox_FileForFind";
			this.tbox_FileForFind.Size = new System.Drawing.Size(490, 20);
			this.tbox_FileForFind.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Файл для поиска";
			// 
			// btn_Clear
			// 
			this.btn_Clear.Location = new System.Drawing.Point(224, 9);
			this.btn_Clear.Name = "btn_Clear";
			this.btn_Clear.Size = new System.Drawing.Size(100, 40);
			this.btn_Clear.TabIndex = 12;
			this.btn_Clear.Text = "Очистить";
			this.btn_Clear.UseVisualStyleBackColor = true;
			this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
			// 
			// tbox_TextForFind
			// 
			this.tbox_TextForFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbox_TextForFind.Location = new System.Drawing.Point(12, 152);
			this.tbox_TextForFind.Name = "tbox_TextForFind";
			this.tbox_TextForFind.Size = new System.Drawing.Size(490, 20);
			this.tbox_TextForFind.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 135);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(97, 13);
			this.label5.TabIndex = 14;
			this.label5.Text = "Текст для поиска";
			// 
			// flagRecursive
			// 
			this.flagRecursive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.flagRecursive.AutoSize = true;
			this.flagRecursive.Location = new System.Drawing.Point(516, 178);
			this.flagRecursive.Name = "flagRecursive";
			this.flagRecursive.Size = new System.Drawing.Size(152, 17);
			this.flagRecursive.TabIndex = 15;
			this.flagRecursive.Text = "Поиск в поддерикториях";
			this.flagRecursive.UseVisualStyleBackColor = true;
			// 
			// btn_StopFind
			// 
			this.btn_StopFind.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btn_StopFind.Location = new System.Drawing.Point(136, 3);
			this.btn_StopFind.Name = "btn_StopFind";
			this.btn_StopFind.Size = new System.Drawing.Size(128, 98);
			this.btn_StopFind.TabIndex = 16;
			this.btn_StopFind.Text = "Остановить поиск";
			this.btn_StopFind.UseVisualStyleBackColor = true;
			this.btn_StopFind.Click += new System.EventHandler(this.btn_StopFind_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.btn_Find, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.btn_StopFind, 1, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(516, 68);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(267, 104);
			this.tableLayoutPanel1.TabIndex = 17;
			// 
			// lbl_CurrentDirectory
			// 
			this.lbl_CurrentDirectory.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lbl_CurrentDirectory.AutoSize = true;
			this.lbl_CurrentDirectory.Location = new System.Drawing.Point(3, 2);
			this.lbl_CurrentDirectory.Name = "lbl_CurrentDirectory";
			this.lbl_CurrentDirectory.Size = new System.Drawing.Size(127, 13);
			this.lbl_CurrentDirectory.TabIndex = 18;
			this.lbl_CurrentDirectory.Text = "Обрабатываемый файл";
			// 
			// lbl_Count
			// 
			this.lbl_Count.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lbl_Count.AutoSize = true;
			this.lbl_Count.Location = new System.Drawing.Point(770, 2);
			this.lbl_Count.Name = "lbl_Count";
			this.lbl_Count.Size = new System.Drawing.Size(13, 13);
			this.lbl_Count.TabIndex = 19;
			this.lbl_Count.Text = "0";
			// 
			// btn_SaveResult
			// 
			this.btn_SaveResult.Location = new System.Drawing.Point(118, 9);
			this.btn_SaveResult.Name = "btn_SaveResult";
			this.btn_SaveResult.Size = new System.Drawing.Size(100, 40);
			this.btn_SaveResult.TabIndex = 20;
			this.btn_SaveResult.Text = "Сохранить результат";
			this.btn_SaveResult.UseVisualStyleBackColor = true;
			this.btn_SaveResult.Click += new System.EventHandler(this.btn_SaveResult_Click);
			// 
			// lbl_Time
			// 
			this.lbl_Time.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lbl_Time.AutoSize = true;
			this.lbl_Time.Location = new System.Drawing.Point(695, 2);
			this.lbl_Time.Name = "lbl_Time";
			this.lbl_Time.Size = new System.Drawing.Size(49, 13);
			this.lbl_Time.TabIndex = 21;
			this.lbl_Time.Text = "00:00:00";
			// 
			// chb_Hidden
			// 
			this.chb_Hidden.AutoSize = true;
			this.chb_Hidden.Location = new System.Drawing.Point(184, 178);
			this.chb_Hidden.Name = "chb_Hidden";
			this.chb_Hidden.Size = new System.Drawing.Size(72, 17);
			this.chb_Hidden.TabIndex = 22;
			this.chb_Hidden.Text = "Скрытый";
			this.chb_Hidden.UseVisualStyleBackColor = true;
			// 
			// chb_System
			// 
			this.chb_System.AutoSize = true;
			this.chb_System.Location = new System.Drawing.Point(12, 178);
			this.chb_System.Name = "chb_System";
			this.chb_System.Size = new System.Drawing.Size(84, 17);
			this.chb_System.TabIndex = 23;
			this.chb_System.Text = "Системный";
			this.chb_System.UseVisualStyleBackColor = true;
			// 
			// chb_Arch
			// 
			this.chb_Arch.AutoSize = true;
			this.chb_Arch.Location = new System.Drawing.Point(102, 178);
			this.chb_Arch.Name = "chb_Arch";
			this.chb_Arch.Size = new System.Drawing.Size(76, 17);
			this.chb_Arch.TabIndex = 24;
			this.chb_Arch.Text = "Архивный";
			this.chb_Arch.UseVisualStyleBackColor = true;
			// 
			// chb_SaveResultPoisk
			// 
			this.chb_SaveResultPoisk.AutoSize = true;
			this.chb_SaveResultPoisk.Checked = true;
			this.chb_SaveResultPoisk.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chb_SaveResultPoisk.Location = new System.Drawing.Point(12, 201);
			this.chb_SaveResultPoisk.Name = "chb_SaveResultPoisk";
			this.chb_SaveResultPoisk.Size = new System.Drawing.Size(122, 17);
			this.chb_SaveResultPoisk.TabIndex = 25;
			this.chb_SaveResultPoisk.Text = "Сохр. пред. поиска";
			this.chb_SaveResultPoisk.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.89263F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.990013F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.999966F));
			this.tableLayoutPanel2.Controls.Add(this.lbl_CurrentDirectory, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.lbl_Count, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.lbl_Time, 1, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 451);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(801, 18);
			this.tableLayoutPanel2.TabIndex = 26;
			// 
			// tw_Result
			// 
			this.tw_Result.Location = new System.Drawing.Point(0, 295);
			this.tw_Result.Name = "tw_Result";
			this.tw_Result.Size = new System.Drawing.Size(801, 150);
			this.tw_Result.TabIndex = 27;
			this.tw_Result.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tw_Result_BeforeExpand);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(803, 471);
			this.Controls.Add(this.tw_Result);
			this.Controls.Add(this.tableLayoutPanel2);
			this.Controls.Add(this.chb_SaveResultPoisk);
			this.Controls.Add(this.chb_Arch);
			this.Controls.Add(this.chb_System);
			this.Controls.Add(this.chb_Hidden);
			this.Controls.Add(this.btn_SaveResult);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.flagRecursive);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbox_TextForFind);
			this.Controls.Add(this.btn_Clear);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbox_FileForFind);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lbox_Result);
			this.Controls.Add(this.btn_Explorer);
			this.Controls.Add(this.tbox_StartDir);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Поиск";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.TextBox tbox_StartDir;
		private System.Windows.Forms.Button btn_Explorer;
		private System.Windows.Forms.Button btn_Find;
		private System.Windows.Forms.FolderBrowserDialog fbd_StartDialog;
		private System.Windows.Forms.ListBox lbox_Result;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbox_FileForFind;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btn_Clear;
		private System.Windows.Forms.TextBox tbox_TextForFind;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox flagRecursive;
		private System.Windows.Forms.Button btn_StopFind;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label lbl_CurrentDirectory;
		private System.Windows.Forms.Label lbl_Count;
		private System.Windows.Forms.Button btn_SaveResult;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lbl_Time;
		private System.Windows.Forms.CheckBox chb_Hidden;
		private System.Windows.Forms.CheckBox chb_System;
		private System.Windows.Forms.CheckBox chb_Arch;
		private System.Windows.Forms.CheckBox chb_SaveResultPoisk;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TreeView tw_Result;
    }
}


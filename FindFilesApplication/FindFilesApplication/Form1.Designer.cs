﻿namespace FindFilesApplication
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
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbox_StartDir
			// 
			this.tbox_StartDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbox_StartDir.Location = new System.Drawing.Point(12, 26);
			this.tbox_StartDir.Name = "tbox_StartDir";
			this.tbox_StartDir.Size = new System.Drawing.Size(304, 20);
			this.tbox_StartDir.TabIndex = 5;
			// 
			// btn_Explorer
			// 
			this.btn_Explorer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Explorer.Location = new System.Drawing.Point(334, 10);
			this.btn_Explorer.Name = "btn_Explorer";
			this.btn_Explorer.Size = new System.Drawing.Size(100, 41);
			this.btn_Explorer.TabIndex = 6;
			this.btn_Explorer.Text = "Обозреватель...";
			this.btn_Explorer.UseVisualStyleBackColor = true;
			this.btn_Explorer.Click += new System.EventHandler(this.btn_Explorer_Click);
			// 
			// btn_Find
			// 
			this.btn_Find.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Find.Location = new System.Drawing.Point(3, 3);
			this.btn_Find.Name = "btn_Find";
			this.btn_Find.Size = new System.Drawing.Size(243, 29);
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
			this.lbox_Result.Location = new System.Drawing.Point(12, 175);
			this.lbox_Result.Name = "lbox_Result";
			this.lbox_Result.Size = new System.Drawing.Size(499, 264);
			this.lbox_Result.TabIndex = 8;
			this.lbox_Result.DoubleClick += new System.EventHandler(this.lbox_Result_DoubleClick);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(21, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(71, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "StartDirectory";
			// 
			// tbox_FileForFind
			// 
			this.tbox_FileForFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbox_FileForFind.Location = new System.Drawing.Point(12, 70);
			this.tbox_FileForFind.Name = "tbox_FileForFind";
			this.tbox_FileForFind.Size = new System.Drawing.Size(304, 20);
			this.tbox_FileForFind.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(21, 54);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "FileForFind";
			// 
			// btn_Clear
			// 
			this.btn_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Clear.Location = new System.Drawing.Point(442, 10);
			this.btn_Clear.Name = "btn_Clear";
			this.btn_Clear.Size = new System.Drawing.Size(75, 41);
			this.btn_Clear.TabIndex = 12;
			this.btn_Clear.Text = "Очистить";
			this.btn_Clear.UseVisualStyleBackColor = true;
			this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
			// 
			// tbox_TextForFind
			// 
			this.tbox_TextForFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbox_TextForFind.Location = new System.Drawing.Point(12, 110);
			this.tbox_TextForFind.Name = "tbox_TextForFind";
			this.tbox_TextForFind.Size = new System.Drawing.Size(304, 20);
			this.tbox_TextForFind.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(21, 93);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 13);
			this.label5.TabIndex = 14;
			this.label5.Text = "TextForFind";
			// 
			// flagRecursive
			// 
			this.flagRecursive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.flagRecursive.AutoSize = true;
			this.flagRecursive.Location = new System.Drawing.Point(334, 110);
			this.flagRecursive.Name = "flagRecursive";
			this.flagRecursive.Size = new System.Drawing.Size(152, 17);
			this.flagRecursive.TabIndex = 15;
			this.flagRecursive.Text = "Поиск в поддерикториях";
			this.flagRecursive.UseVisualStyleBackColor = true;
			// 
			// btn_StopFind
			// 
			this.btn_StopFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_StopFind.Location = new System.Drawing.Point(252, 3);
			this.btn_StopFind.Name = "btn_StopFind";
			this.btn_StopFind.Size = new System.Drawing.Size(244, 29);
			this.btn_StopFind.TabIndex = 16;
			this.btn_StopFind.Text = "Остановить поиск";
			this.btn_StopFind.UseVisualStyleBackColor = true;
			this.btn_StopFind.Click += new System.EventHandler(this.btn_StopFind_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.btn_Find, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.btn_StopFind, 1, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 458);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(499, 35);
			this.tableLayoutPanel1.TabIndex = 17;
			// 
			// lbl_CurrentDirectory
			// 
			this.lbl_CurrentDirectory.AutoSize = true;
			this.lbl_CurrentDirectory.Location = new System.Drawing.Point(12, 133);
			this.lbl_CurrentDirectory.Name = "lbl_CurrentDirectory";
			this.lbl_CurrentDirectory.Size = new System.Drawing.Size(0, 13);
			this.lbl_CurrentDirectory.TabIndex = 18;
			// 
			// lbl_Count
			// 
			this.lbl_Count.AutoSize = true;
			this.lbl_Count.Location = new System.Drawing.Point(15, 155);
			this.lbl_Count.Name = "lbl_Count";
			this.lbl_Count.Size = new System.Drawing.Size(0, 13);
			this.lbl_Count.TabIndex = 19;
			// 
			// btn_SaveResult
			// 
			this.btn_SaveResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_SaveResult.Location = new System.Drawing.Point(334, 57);
			this.btn_SaveResult.Name = "btn_SaveResult";
			this.btn_SaveResult.Size = new System.Drawing.Size(100, 41);
			this.btn_SaveResult.TabIndex = 20;
			this.btn_SaveResult.Text = "Сохранить результат";
			this.btn_SaveResult.UseVisualStyleBackColor = true;
			this.btn_SaveResult.Click += new System.EventHandler(this.btn_SaveResult_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(529, 505);
			this.Controls.Add(this.btn_SaveResult);
			this.Controls.Add(this.lbl_Count);
			this.Controls.Add(this.lbl_CurrentDirectory);
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
			this.Name = "Form1";
			this.Text = "Поиск файлов";
			this.tableLayoutPanel1.ResumeLayout(false);
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
    }
}

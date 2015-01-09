using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FindFilesApplication.Properties;
using Microsoft.Win32;

namespace FindFilesApplication
{
	public enum TypeForFind
	{
		FindFile,
		FindText
	}

	public partial class Form1 : Form
	{
		public Thread Thread;

		public Form1()
		{
			InitializeComponent();
		}

		private void btn_Explorer_Click(object sender, EventArgs e)
		{
			if (fbd_StartDialog.ShowDialog() == DialogResult.OK)
			{
				tbox_StartDir.Text = fbd_StartDialog.SelectedPath;
			}
		}

		private void btn_Find_Click(object sender, EventArgs e)
		{
			ThreadStart threadFind = Finding;
			Thread = new Thread(threadFind);
			Thread.Start();
		}

		private void Finding()
		{
			try
			{
				var flagForFind = TypeForFind.FindFile;
				if (tbox_TextForFind.Text != "")
				{
					flagForFind = TypeForFind.FindText;
				}

				var dir = new DirectoryInfo(tbox_StartDir.Text);
				string file = tbox_FileForFind.Text;
				FindInDir(dir, file, flagForFind, flagRecursive.Checked);
			}
			catch (ThreadAbortException)
			{
				MessageBox.Show(Resources.Form1_btn_StopFind_Click_Поиск_закончен_);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		int _i;
// ReSharper disable once InconsistentNaming
		public void FindInDir(DirectoryInfo dir, string pattern, TypeForFind flagForFind, bool _flagRecursive)
		{
			if (flagForFind == TypeForFind.FindFile)
			{
				foreach (FileInfo fileInfo in dir.GetFiles(pattern))
				{
					_i++;
					SetCountDir(_i);
					SetCurrentDir(fileInfo.FullName);
					SetItemDir(fileInfo.FullName);
				}
				if (_flagRecursive)
					foreach (DirectoryInfo directoryInfo in dir.GetDirectories())
					{
						FindInDir(directoryInfo, pattern, flagForFind, true);
					}
			}
			else
			{
				foreach (FileInfo fileInfo in dir.GetFiles(pattern))
				{
					_i++;
					SetCountDir(_i);
					SetCurrentDir(fileInfo.FullName);
					string[] textFromFile = File.ReadAllLines(fileInfo.FullName, Encoding.Default);
					foreach (string s in textFromFile)
					{
						if (s.Contains(tbox_TextForFind.Text))
							SetItemDir(fileInfo.FullName);
					}
				}
				if (_flagRecursive)
					foreach (DirectoryInfo directoryInfo in dir.GetDirectories())
					{
						FindInDir(directoryInfo, pattern, flagForFind, true);
					}
			}
			SetCurrentDir("");
		}

		private void btn_Clear_Click(object sender, EventArgs e)
		{
			lbox_Result.Items.Clear();
			lbl_Count.Text = "";
			_i = 0;
		}

		private void lbox_Result_DoubleClick(object sender, EventArgs e)
		{
			Process.Start(lbox_Result.SelectedItem.ToString());
		}

		private void btn_StopFind_Click(object sender, EventArgs e)
		{
			try
			{
				Thread.Abort();
			}
			catch (ThreadAbortException)
			{
				MessageBox.Show(Resources.Form1_btn_StopFind_Click_Поиск_закончен_);
			}
		}
		#region чтобы не обращалось несколько потоков к 1 элементу управления
		private void SetCurrentDir(string currdir)
		{
			if (!InvokeRequired)
				lbl_CurrentDirectory.Text = currdir;
			else
				Invoke(new SetStringDelegate(SetCurrentDir), new object[] { currdir });
		}

		private void SetCountDir(int countDir)
		{
			if (!InvokeRequired)
// ReSharper disable once SpecifyACultureInStringConversionExplicitly
				lbl_Count.Text = countDir.ToString();
			else
				Invoke(new SetCountDelegate(SetCountDir), new object[] { countDir });
		}

		private void SetItemDir(object fileinfo)
		{
			if (!InvokeRequired)
				lbox_Result.Items.Add(fileinfo);
			else
				Invoke(new SetItemDelegate(SetItemDir), new[] { fileinfo });
		}

		private delegate void SetCountDelegate(int parameter);

		private delegate void SetItemDelegate(string parameter);

		private delegate void SetStringDelegate(string parameter);
		#endregion

		#region сохранение результата в файл
		private void btn_SaveResult_Click(object sender, EventArgs e)
		{
			saveFileDialog1.Filter = @"txt files (*.txt)|*.txt|All files (*.*)|*.*";
			saveFileDialog1.FilterIndex = 2;
			saveFileDialog1.RestoreDirectory = true;

			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				Stream myStream;
// ReSharper disable once ConditionIsAlwaysTrueOrFalse
				if ((myStream = saveFileDialog1.OpenFile()) != null)
				{
					var sw = new StreamWriter(myStream);
					foreach (var item in lbox_Result.Items)
					{
						sw.WriteLine(item.ToString());
					}
					sw.Close();
					myStream.Close();
				}
			}
		}
		#endregion

		#region сохранение параметров
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\AppFind", true))
			{
				key.SetValue("StartDirectory", tbox_StartDir.Text, RegistryValueKind.String);
				key.SetValue("FileForFind", tbox_FileForFind.Text, RegistryValueKind.String);
				key.SetValue("TextForFind", tbox_TextForFind.Text, RegistryValueKind.String);
				key.SetValue("FlagRecursive", flagRecursive.Checked ? 1 : 0, RegistryValueKind.DWord);
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\AppFind");
			if (key == null)
			{
				key = Registry.CurrentUser.CreateSubKey("Software\\AppFind");
			}

			int flRc = (int)key.GetValue("FlagRecursive", 0);
			flagRecursive.Checked = (flRc == 1);
			string TxFrFn = (string)key.GetValue("TextForFind");
			tbox_TextForFind.Text = TxFrFn;
			string FlFrFn = (string)key.GetValue("FileForFind");
			tbox_FileForFind.Text = FlFrFn;
			string StDr = (string)key.GetValue("StartDirectory");
			tbox_StartDir.Text = StDr;
		}
		#endregion
	}
}
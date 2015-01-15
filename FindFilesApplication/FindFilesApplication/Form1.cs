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
	public partial class Form1 : Form
	{
		private Thread _thread;
		private DateTime _timeStart;
		string _substringDirectory;

		public enum TypeForFind
		{
			FindFile,
			FindText
		}

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
			if (!chb_SaveResultPoisk.Checked)
			{
				btn_Clear_Click(sender, e);
			}
			_timeStart = DateTime.Now;
			_thread = new Thread(Finding);
			_thread.Start();
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

				var attributes = (chb_System.Checked ? FileAttributes.System : 0) |
								 (chb_Arch.Checked ? FileAttributes.Archive : 0) |
								 (chb_Hidden.Checked ? FileAttributes.Hidden : 0);

				var dir = new DirectoryInfo(tbox_StartDir.Text);
				string pattern = tbox_FileForFind.Text;

				FindInDir(dir, pattern, flagForFind, flagRecursive.Checked, attributes);

				ClearTwResult(tw_Result);
				String path = tbox_StartDir.Text;
				AddTwResult(tw_Result, path); //tw_Result.Nodes.Add(path);
				PopulateTreeView(path, tw_Result.Nodes[0], pattern);
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

		public void PopulateTreeView(string directoryValue, TreeNode parentNode, string pattern)
		{
			string[] directoryArray =
			 Directory.GetDirectories(directoryValue);

			var currentDirectory = new DirectoryInfo(directoryValue);

			try
			{
				if (currentDirectory.GetFiles(pattern).Length != 0)
				{
					foreach (var file in currentDirectory.GetFiles(pattern))
					{
						AddTwResultTreeNode(parentNode, file.FullName); //parentNode.Nodes.Add(file.FullName);
					}
				}

				if (directoryArray.Length != 0)
				{
					foreach (string directory in directoryArray)
					{
						_substringDirectory = directory.Substring(
						directory.LastIndexOf('\\') + 1,
						directory.Length - directory.LastIndexOf('\\') - 1);

						var myNode = new TreeNode(_substringDirectory);

						if (Directory.GetFiles(directory, pattern, SearchOption.AllDirectories).Length != 0)
							AddTwResultTreeNode(parentNode, myNode);//parentNode.Nodes.Add(myNode);

						PopulateTreeView(directory, myNode, pattern);
					}
				}
			}
			catch (UnauthorizedAccessException)
			{
				parentNode.Nodes.Add("Access denied");
			} // end catch
		}


		int _i;
// ReSharper disable once InconsistentNaming
		public void FindInDir(DirectoryInfo dir, string pattern, TypeForFind flagForFind, bool flagRecurs, FileAttributes attributes)
		{
			if (flagForFind == TypeForFind.FindFile)
			{
				foreach (FileInfo fileInfo in dir.GetFiles(pattern))
				{
					//MessageBox.Show(fileInfo.Attributes.ToString());
					_i++;
					SetTime(_timeStart);
					SetCountDir(_i);
					SetCurrentDir(fileInfo.FullName);
					if ((fileInfo.Attributes & attributes) == attributes)
						SetItemDir(fileInfo.FullName);
				}
				if (flagRecurs)
					foreach (DirectoryInfo directoryInfo in dir.GetDirectories())
					{
						FindInDir(directoryInfo, pattern, flagForFind, true, attributes);
					}
			}
			else
			{
				foreach (FileInfo fileInfo in dir.GetFiles(pattern))
				{
					_i++;
					SetTime(_timeStart);
					SetCountDir(_i);
					SetCurrentDir(fileInfo.FullName);
					if ((fileInfo.Attributes & attributes) == attributes)
					{
						string[] textFromFile = File.ReadAllLines(fileInfo.FullName, Encoding.Default);
						foreach (string s in textFromFile)
						{

							if (s.Contains(tbox_TextForFind.Text))
								SetItemDir(fileInfo.FullName);
						}
					}
				}
				if (flagRecurs)
					foreach (DirectoryInfo directoryInfo in dir.GetDirectories())
					{
						FindInDir(directoryInfo, pattern, flagForFind, true, attributes);
					}
			}
		}

		private void btn_Clear_Click(object sender, EventArgs e)
		{
			lbox_Result.Items.Clear();
			tw_Result.Nodes.Clear();
			lbl_Count.Text = @"0";
			_i = 0;
			lbl_Time.Text = @"00:00:00";
		}

		private void lbox_Result_DoubleClick(object sender, EventArgs e)
		{
			Process.Start(lbox_Result.SelectedItem.ToString());
		}

		private void btn_StopFind_Click(object sender, EventArgs e)
		{
			try
			{
				_thread.Abort();
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

		private void SetTime(DateTime start)
		{
			if (!InvokeRequired)
				lbl_Time.Text = (DateTime.Now - start).ToString();
			else
				Invoke(new SetTimeDelegate(SetTime), new object[] { start });
		}

		private void ClearTwResult(TreeView node)
		{
			if (!InvokeRequired)
				node.Nodes.Clear();
			else if (node != null) Invoke(new ClearTwResultDelegate(ClearTwResult), new object[] { node });
		}

		private void AddTwResult(TreeView node, string path)
		{
			if (!InvokeRequired)
				node.Nodes.Add(path);
			else if (node != null) Invoke(new AddTwResultDelegate(AddTwResult), new object[] { node, path });
		}

		private void AddTwResultTreeNode(TreeNode node, string path)
		{
			if (!InvokeRequired)
				node.Nodes.Add(path);
			else if (node != null) Invoke(new AddTwResultDelegateTreeNode(AddTwResultTreeNode), new object[] { node, path });
		}

		private void AddTwResultTreeNode(TreeNode node, TreeNode childnode)
		{
			if (!InvokeRequired)
				node.Nodes.Add(childnode);
			else if (node != null) Invoke(new AddTwResultDelegateTreeNodeReloadChildNode(AddTwResultTreeNode), new object[] { node, childnode });
		}

		private delegate void AddTwResultDelegateTreeNodeReloadChildNode(TreeNode node, TreeNode childnode);

		private delegate void AddTwResultDelegateTreeNode(TreeNode node, string path);

		private delegate void AddTwResultDelegate(TreeView node, string path);

		private delegate void ClearTwResultDelegate(TreeView node);

		private delegate void SetTimeDelegate(DateTime start);

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
				if (key != null)
				{
					key.SetValue("StartDirectory", tbox_StartDir.Text, RegistryValueKind.String);
					key.SetValue("FileForFind", tbox_FileForFind.Text, RegistryValueKind.String);
					key.SetValue("TextForFind", tbox_TextForFind.Text, RegistryValueKind.String);
					key.SetValue("FlagRecursive", flagRecursive.Checked ? 1 : 0, RegistryValueKind.DWord);
					key.SetValue("FlagSystem", chb_System.Checked ? 1 : 0, RegistryValueKind.DWord);
					key.SetValue("FlagArchive", chb_Arch.Checked ? 1 : 0, RegistryValueKind.DWord);
					key.SetValue("FlagHidden", chb_Hidden.Checked ? 1 : 0, RegistryValueKind.DWord);
					key.SetValue("FlagSaveResult", chb_SaveResultPoisk.Checked ? 1 : 0, RegistryValueKind.DWord);
				}
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\AppFind") ??
			                  Registry.CurrentUser.CreateSubKey("Software\\AppFind");

			if (key != null)
			{
				var flSr = (int)key.GetValue("FlagSaveResult", 0);
				chb_SaveResultPoisk.Checked = (flSr == 1);
			}
			if (key != null)
			{
				var flRc = (int)key.GetValue("FlagRecursive", 0);
				flagRecursive.Checked = (flRc == 1);
			}
			if (key != null)
			{
				var flSys = (int)key.GetValue("FlagSystem", 0);
				chb_System.Checked = (flSys == 1);
			}
			if (key != null)
			{
				var flArch = (int)key.GetValue("FlagArchive", 0);
				chb_Arch.Checked = (flArch == 1);
			}
			if (key != null)
			{
				var flHidden = (int)key.GetValue("FlagHidden", 0);
				chb_Hidden.Checked = (flHidden == 1);
			}
			if (key != null)
			{
				var txFrFn = (string)key.GetValue("TextForFind");
				tbox_TextForFind.Text = txFrFn;
			}
			if (key != null)
			{
				var flFrFn = (string) key.GetValue("FileForFind");
				tbox_FileForFind.Text = flFrFn;
			}
			if (key != null)
			{
				var stDr = (string) key.GetValue("StartDirectory");
				tbox_StartDir.Text = stDr;
			}
		}
		#endregion
	}
}
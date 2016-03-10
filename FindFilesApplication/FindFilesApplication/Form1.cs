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
        // Поток
		private Thread _thread;

        // Дата начала
		private DateTime _timeStart;

        // Директория поиска
		string _substringDirectory;

        // Тип поиска, файлы или текст
		public enum TypeForFind
		{
			FindFile,
			FindText
		}

	    public enum Recursive
	    {
	        IsRecursive,
            NotRecursive
	    }

        // Конструктор
		public Form1()
		{
			InitializeComponent();
		}

        // Выбор директории в обозревателе
		private void btn_Explorer_Click(object sender, EventArgs e)
		{
			if (fbd_StartDialog.ShowDialog() == DialogResult.OK)
			{
				tbox_StartDir.Text = fbd_StartDialog.SelectedPath;
			}
		}

        // Обработка события поиска
		private void btn_Find_Click(object sender, EventArgs e)
		{
			if (!chb_SaveResultPoisk.Checked)
			{
				btn_Clear_Click(sender, e);
			}
			_timeStart = DateTime.Now;
            SynchronizationContext context = SynchronizationContext.Current;
			_thread = new Thread(Finding);
            _thread.Start(context);
		}

        // Операция поиска файлов
        private void Finding(object state)
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
                Recursive recursive = flagRecursive.Checked ? Recursive.IsRecursive : Recursive.NotRecursive;
                FindInDir(dir, pattern, flagForFind, recursive, attributes);

				ClearTwResult(tw_Result);
				String path = tbox_StartDir.Text;
				AddTwResult(tw_Result, path);
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

        /// <summary>
        /// Построение TreeView
        /// </summary>
        /// <param name="directoryValue"></param>
        /// <param name="parentNode"></param>
        /// <param name="pattern"></param>
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
                        AddTwResult(parentNode, file.FullName); //parentNode.Nodes.Add(file.FullName);
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
                            AddTwResult(parentNode, myNode);//parentNode.Nodes.Add(myNode);

						PopulateTreeView(directory, myNode, pattern);
					}
				}
			}
			catch (UnauthorizedAccessException)
			{
				parentNode.Nodes.Add("Access denied");
			}
		}

		int _i;
        // ReSharper disable once InconsistentNaming
	    /// <summary>
	    /// Поиск в заданной директории
	    /// </summary>
	    /// <param name="dir"></param>
	    /// <param name="pattern"></param>
	    /// <param name="flagForFind"></param>
	    /// <param name="flagRecurs"></param>
	    /// <param name="attributes"></param>
	    public void FindInDir(DirectoryInfo dir, string pattern, TypeForFind flagForFind, Recursive flagRecurs,
	        FileAttributes attributes)
	    {
	        if (flagForFind == TypeForFind.FindFile)
	        {
	            foreach (FileInfo fileInfo in dir.GetFiles(pattern))
	            {
	                _i++;
	                SetTime(_timeStart);
	                SetCountDir(_i);
	                SetCurrentDir(fileInfo.FullName);
	                if ((fileInfo.Attributes & attributes) == attributes)
	                    SetItemDir(fileInfo.FullName);
	            }
	            if (flagRecurs == Recursive.IsRecursive)
	                foreach (DirectoryInfo directoryInfo in dir.GetDirectories())
	                {
                        FindInDir(directoryInfo, pattern, flagForFind, Recursive.IsRecursive, attributes);
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
	            if (flagRecurs == Recursive.IsRecursive)
	                foreach (DirectoryInfo directoryInfo in dir.GetDirectories())
	                {
                        FindInDir(directoryInfo, pattern, flagForFind, Recursive.IsRecursive, attributes);
	                }
	        }
	    }

	    /// <summary>
        /// Очистка значений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void btn_Clear_Click(object sender, EventArgs e)
		{
			lbox_Result.Items.Clear();
			tw_Result.Nodes.Clear();
			lbl_Count.Text = @"0";
			_i = 0;
			lbl_Time.Text = @"00:00:00";
		}

        /// <summary>
        /// Открытие файла по двойному щелчку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void lbox_Result_DoubleClick(object sender, EventArgs e)
		{
			Process.Start(lbox_Result.SelectedItem.ToString());
		}

        /// <summary>
        /// Обработка события остановки поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

		#region Установка значений в контроллы
		private void SetCurrentDir(string currdir)
		{
            lbl_CurrentDirectory.BeginInvoke(new Action(() => { lbl_CurrentDirectory.Text = currdir; }));
		}

		private void SetCountDir(int countDir)
		{
            lbl_Count.Invoke(new Action(() => { lbl_Count.Text = countDir.ToString(); }));
		}

		private void SetItemDir(object fileinfo)
		{
            lbox_Result.Invoke(new Action(() => { lbox_Result.Items.Add(fileinfo); }));
		}

		private void SetTime(object start)
		{
		    lbl_Time.Invoke(new Action(() => {lbl_Time.Text = (DateTime.Now - (DateTime)start).ToString(); }));
		}

		private void ClearTwResult(TreeView node)
		{
            node.Invoke(new Action(() => { node.Nodes.Clear(); }));
		}

		private void AddTwResult(TreeView treeView, string path)
		{
            treeView.Invoke(new Action(() => { treeView.Nodes.Add(path); }));
		}

		private void AddTwResult(TreeNode node, string path)
		{
            Invoke(new Action(() => { node.Nodes.Add(path); }));
		}

		private void AddTwResult(TreeNode node, TreeNode childnode)
		{
            Invoke(new Action(()=>node.Nodes.Add(childnode)));
		}
		#endregion

		#region сохранение результата в файл
        /// <summary>
        /// Сохранение результата в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

		#region сохранение и считывание параметров
        /// <summary>
        /// Сохранение параметров перед закрытием формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
            if (_thread != null)
                _thread.Abort();
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

        /// <summary>
        /// Считывание сохраненных в реестре значений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
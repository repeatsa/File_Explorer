using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class findFile_control : MonoBehaviour {
	findFile_view findFile_View = new findFile_view();
	string Path = null;
	string File = null;
	string ExtensionName = null;
	string CreateTime = null;
	string WriteTime = null;
	string Length = null;
	string Content = null;
	private string _space = " ";
	private string _Enter = "\n";
	private string _extensionName = ".*";
	private int _Zero = 0;



	void Start () {
		
		if (_Zero != Path.Length) {
			if (_Zero != File.Length) {
				pathAndNameFindFiles ();
			} else if (_Zero != ExtensionName.Length) {
				ExtensionName = "*" + ExtensionName;
				pathAndExtensionFindFiles ();
			} else if (_Zero != CreateTime.Length) {
				pathAndCreateTimeFindFiles ();
			} else if (_Zero != WriteTime.Length) {
				pathAndWriteTimeFindFiles ();
			} else if (_Zero != Length.Length) {
				pathAndLengthFindFiles ();
			} else if (_Zero != Content.Length) {
				pathAndOpenFindFiles ();
			} else {
				pathFindDirectory ();
				pathFindFiles ();
			}
		}
	}

	void pathFindDirectory()
	{
		if (Directory.Exists (Path)) {
			string folderName = null;
			foreach (string curfolder in Directory.GetDirectories(Path)) {
				folderName = folderName + curfolder + _Enter;
			}
			toViewFolders(folderName);
		}
	}

	void pathFindFiles()
	{
		if (Directory.Exists (Path)) {
			string fileName = null;
			foreach (string curfile in Directory.GetFiles(Path)) {
				fileName = fileName + curfile +_Enter;
			}
			toViewFiles(fileName);
		}
	}

	void pathAndNameFindFiles()
	{
		if (Directory.Exists (Path)) {
			string fileName = null;
			foreach (string curfile in Directory.GetFileSystemEntries(Path,File+_extensionName)) {
				fileName = fileName + curfile + _Enter;

			}
			foreach (string curfolder in Directory.GetDirectories(Path)) {
				foreach (string curfile in Directory.GetFiles(curfolder,File+_extensionName)) {
					fileName = fileName + curfile + _Enter;
				}
			}
			toViewFiles(fileName);
		}
	}

	void toViewFiles(string toFilesname){
		findFile_View.view_Files (toFilesname);
	}

	void toViewFolders(string toFoldersname){
		findFile_View.view_Folder (toFoldersname);
	}

	void pathAndExtensionFindFiles()
	{
		if (Directory.Exists (Path)) {
			string fileName = null;
			foreach (string curfile in Directory.GetFileSystemEntries(Path,ExtensionName)) {
				fileName = fileName + curfile + _Enter;
			}
			foreach (string curfolder in Directory.GetDirectories(Path)) {
				foreach (string curfile in Directory.GetFiles(curfolder,ExtensionName)) {
					fileName = fileName + curfile + _Enter;
				}
			}
			toViewFiles(fileName);
		}
	}
		
	void pathAndCreateTimeFindFiles()
	{
		if (Directory.Exists (Path)) {
			string fileName = null;
			foreach (string curfile in Directory.GetFileSystemEntries(Path)) {
				FileInfo fileFo = new FileInfo (curfile);
				string fileFoString = fileFo.CreationTime.ToString ();
				int inderSpeace = fileFoString.IndexOf (_space);
				fileFoString = fileFoString.Substring (0,inderSpeace);
				if (fileFoString  == CreateTime) {
					fileName = fileName + curfile + _Enter;

				}
			}
			foreach (string curfolder in Directory.GetDirectories(Path)) {
				foreach (string curfile in Directory.GetFileSystemEntries(curfolder)) {
					FileInfo fileFo = new FileInfo (curfile);
					string fileFoString = fileFo.CreationTime.ToString ();
					int inderSpeace = fileFoString.IndexOf (_space);
					fileFoString = fileFoString.Substring (0,inderSpeace);
					if (fileFoString  == CreateTime) {
						fileName = fileName + curfile + _Enter;
					}
				}
			}
			toViewFiles(fileName);
		}
	}

	void pathAndWriteTimeFindFiles()
	{
		if (Directory.Exists (Path)) {
			string fileName = null;
			foreach (string curfile in Directory.GetFileSystemEntries(Path)) {
				string fileFo = Directory.GetLastWriteTime (curfile).ToString();
				int inderSpeace = fileFo.IndexOf (_space);
				fileFo = fileFo.Substring (0,inderSpeace);
				if (fileFo  == WriteTime) {
					fileName = fileName + curfile + _Enter;
				}
			}
			foreach (string curfolder in Directory.GetDirectories(Path)) { 
				foreach (string curfile in Directory.GetFileSystemEntries(curfolder)) {
					string fileFo = Directory.GetLastWriteTime (curfile).ToString();
					int inderSpeace = fileFo.IndexOf (_space);
					fileFo = fileFo.Substring (0,inderSpeace);
					if (fileFo  == WriteTime) {
						fileName = fileName + curfile + _Enter;
					}
				}
			}
			toViewFiles(fileName);
		}
	}

	void pathAndLengthFindFiles()
	{
		if (Directory.Exists (Path)) {
			string fileName = null;
			foreach (string curfile in Directory.GetFiles(Path)) {
				FileInfo fileFo = new FileInfo (curfile);
				if (Length == fileFo.Length.ToString ()) {
					fileName = fileName + curfile + _Enter;
				}
			}
			foreach (string curfolder in Directory.GetDirectories(Path)) {
				foreach (string curfile in Directory.GetFiles(curfolder)) {
					FileInfo fileFo = new FileInfo (curfile);
					if (Length == fileFo.Length.ToString()) {
						fileName = fileName + curfile + _Enter;
					}
				}
			}
			toViewFiles(fileName);
		}
	}

	void pathAndOpenFindFiles(){
		if (Directory.Exists (Path)) {
			string fileName = null;
			foreach (string curfile in Directory.GetFileSystemEntries(Path)) {
				StreamReader sr = new StreamReader(curfile);
				string str = sr.ReadToEnd ();
				if (str.Contains (Content)) {
					fileName = fileName + curfile + _Enter;
				}
			}
			foreach (string curfolder in Directory.GetDirectories(Path))
			{
				foreach (string curfile in Directory.GetFileSystemEntries(curfolder))
				{
					StreamReader sr = new StreamReader(curfile);
					string str = sr.ReadToEnd ();
					if (str.Contains (Content)) {
						fileName = fileName + curfile + _Enter;
					}
				}
			}
			toViewFiles(fileName);
		}
	}
}
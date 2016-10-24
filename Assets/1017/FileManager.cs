using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class FileManager  {
	private List<FileData> m_arrsFile = new List<FileData> ();


	private string m_sWriteTime = null;
	private FileInfo m_FIFfiles = null;
	//取檔案
	public List<FileData> getFiles(string _sPath){
		_searchPathAndSetFile (_sPath);
		return m_arrsFile;
	}
	private void _searchPathAndSetFile (string _sPath)
	{
		_searchSubFolders (_sPath);
		foreach (string curfile in Directory.GetFiles(_sPath)) {
			_createListContent (curfile,TextLibrary.IZERO);
		}
	}

	private void _searchSubFolders(string _sPath) 
	{
		foreach (string curfolder in Directory.GetDirectories(_sPath)) {
			_createListContent (curfolder,TextLibrary.IONE);
			foreach (string curfile in Directory.GetFiles(curfolder)) {
				_createListContent (curfile,TextLibrary.IZERO);
			}
			_searchSubFolders (curfolder);
		}
	}

	//將資料會成一個DATA放進LIST中
	private void _createListContent(string _sPath,int _iType){
		FileData _FileDate = new FileData();
		_FileDate.setFile (_sPath);
		_FileDate.setkey (_iType);
		m_FIFfiles = new FileInfo (_sPath);
		_FileDate.setCreateTime (m_FIFfiles.CreationTime.ToString ());
		m_sWriteTime = Directory.GetLastWriteTime (_sPath).ToString();
		_FileDate.setWriteTime (m_sWriteTime);
		m_arrsFile.Add (_FileDate);
	}
}

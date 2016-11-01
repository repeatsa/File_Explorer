using System.Collections.Generic;
using System.IO;

public class FileManager  {
	private List<FileData> m_arrsFile = new List<FileData> ();
    public delegate void ManagerDelegate(List<FileData> _arrFiles);
    public ManagerDelegate JudgmentDelegate;


    //取檔案
    public List<FileData> getFiles(){
		return m_arrsFile;
	}
	public void _searchPathAndSetFile (string _sPath)
	{
		foreach (string curfile in Directory.GetFiles(_sPath)) {
			_createListContent (curfile,TextLibrary.selectFileFolder.File);
		}
        JudgmentDelegate(m_arrsFile);
        m_arrsFile.Clear();
       foreach (string curfolder in Directory.GetDirectories(_sPath))
        {
            _createListContent(curfolder, TextLibrary.selectFileFolder.Folder);
           _searchPathAndSetFile(curfolder);
        }
    }

	//將資料會成一個DATA放進LIST中
	private void _createListContent(string _sPath,TextLibrary.selectFileFolder _Type){
		FileData _FileDate = new FileData();
		if (_Type == TextLibrary.selectFileFolder.File) {
			FileInfo _FIFfiles = new FileInfo (_sPath);
			_FileDate.setCreateTime (_FIFfiles.CreationTime.ToString ());
			_FileDate.setWriteTime (_FIFfiles.LastWriteTime.ToString());
			_FileDate.setLength (_FIFfiles.Length);
            _FileDate.setName(_FIFfiles.Name);

        }
		_FileDate.setFile (_sPath);
		_FileDate.setFileFolderType (_Type);

		m_arrsFile.Add (_FileDate);
	}
}

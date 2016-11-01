using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class FileData  {

	//檔案路徑 && 檔案KEY && 檔案創建時間 && 檔案改寫時間
	private string m_sFile = string.Empty;
	private TextLibrary.selectFileFolder m_enumType = TextLibrary.selectFileFolder.None;
	private string m_sCreateTime = string.Empty;
	private string m_sWirteTime = string.Empty;
	private float m_fLength = 0;
    private string m_sName = string.Empty;


	public string getFile (){
		return m_sFile;
	}
	public TextLibrary.selectFileFolder getFileFolerType (){
		return m_enumType;
	}
	public string getCreateTime (){
		return m_sCreateTime;
	}
	public string getWriteTime (){
		return m_sWirteTime;
	}
	public float getLength (){
		return m_fLength;
	}
    public string getName()
    {
        return m_sName;
    }

    public void setFile (string _sFile){
		m_sFile = _sFile;
	}
	public void setFileFolderType (TextLibrary.selectFileFolder _Type){
		m_enumType = _Type;
	}
	public void setCreateTime (string _sCreateTime){
		m_sCreateTime = _sCreateTime;
	}
	public void setWriteTime (string _sWriteTime){
		m_sWirteTime = _sWriteTime;
	}
	public void setLength (float _fLength){
		m_fLength = _fLength;
	}
    public void setName(string _sName)
    {
        m_sName = _sName;
    }
}
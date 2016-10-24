using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class FileData  {

	//檔案路徑 && 檔案KEY && 檔案創建時間 && 檔案改寫時間
	private string m_sFile = null;
	private int m_iKey = 0;
	private string m_sCreateTime = null;
	private string m_sWirteTime = null;

	public string getFile (){
		return m_sFile;
	}
	public int getkey (){
		return m_iKey;
	}
	public string getCreateTime (){
		return m_sCreateTime;
	}
	public string getWriteTime (){
		return m_sWirteTime;
	}
		
	public void setFile (string _sFile){
		m_sFile = _sFile;
	}
	public void setkey (int _iKey){
		m_iKey = _iKey;
	}
	public void setCreateTime (string _sCreateTime){
		m_sCreateTime = _sCreateTime;
	}
	public void setWriteTime (string _sWriteTime){
		m_sWirteTime = _sWriteTime;
	}
}
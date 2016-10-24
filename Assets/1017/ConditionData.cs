using UnityEngine;
using System.Collections;

public class ConditionData {
	//外部八項條件 && 是否輸入 && 單位數值
	private string m_sPath = null;
	private string m_sFile = null;
	private string m_sExtension = null;
	private string m_sCreateTime = null;
	private string m_sWriteTime = null;
	private string m_sMin = null;
	private string m_sMax = null;
	private string m_sContent = null;

	private int m_iMinUnit = 0;
	private int m_iMaxUnit = 0;

	private bool m_bPath = false;
	private bool m_bFile = false;
	private bool m_bExtension = false;
	private bool m_bCreateTime = false;
	private bool m_bWriteTime = false;
	private bool m_bMin = false;
	private bool m_bMax = false;
	private bool m_bContent = false;

	public int getMinUnit (){
		return m_iMinUnit;
	}
	public int getMaxUnit (){
		return m_iMaxUnit;
	}

	public void setMinUnit (int _iDropValue){
		m_iMinUnit = m_iMinUnit +_iDropValue;
	}
	public void setMaxUnit (int _iDropValue){
		m_iMaxUnit = m_iMaxUnit +_iDropValue;
	}



	public string getPath (){
		return m_sPath;
	}
	public string getFile (){
		return m_sFile;
	}
	public string getExtension (){
		return m_sExtension;
	}
	public string getCreateTime (){
		return m_sCreateTime;
	}
	public string getWriteTime (){
		return m_sWriteTime;
	}
	public string getMin (){
		return m_sMin;
	}
	public string getMax (){
		return m_sMax;
	}
	public string getContent (){
		return m_sContent;
	}

	public void setPath(string _sPath){
		m_sPath = _sPath;
	}
	public void setFile(string _sFile){
		m_sFile = _sFile;
	}
	public void setExtension(string _sExtension){
		m_sExtension = _sExtension;
	}
	public void setCreateTime(string _sCreateTime){
		m_sCreateTime = _sCreateTime;
	}
	public void setWriteTime(string _sWriteTime){
		m_sWriteTime = _sWriteTime;
	}
	public void setMin(string _sMin){
		m_sMin = _sMin;
	}
	public void setMax(string _sMax){
		m_sMax = _sMax;
	}
	public void setContent(string _sContent){
		m_sContent = _sContent;
	}

	public bool getPathBool (){
		return m_bPath;
	}
	public bool getFileBool (){
		return m_bFile;
	}
	public bool getExtensionBool (){
		return m_bExtension;
	}
	public bool getCreateTimeBool (){
		return m_bCreateTime;
	}
	public bool getWriteTimeBool (){
		return m_bWriteTime;
	}
	public bool getMinBool (){
		return m_bMin;
	}
	public bool getMaxBool (){
		return m_bMax;
	}
	public bool getContentBool (){
		return m_bContent;
	}

	public void setPathBool(bool _bPath){
		m_bPath = _bPath;
	}
	public void setFileBool(bool _bFile){
		m_bFile = _bFile;
	}
	public void setExtensionBool(bool _bExtension){
		m_bExtension = _bExtension;
	}
	public void setCreateTimeBool(bool _bCreateTime){
		m_bCreateTime = _bCreateTime;
	}
	public void setWriteTimeBool(bool _bWriteTime){
		m_bWriteTime = _bWriteTime;
	}
	public void setMinBool(bool _bMin){
		m_bMin = _bMin;
	}
	public void setMaxBool(bool _bMax){
		m_bMax = _bMax;
	}
	public void setContentBool(bool _bContent){
		m_bContent = _bContent;
	}
}

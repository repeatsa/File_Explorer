using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ConditionData {
	//外部八項條件 && 是否輸入 && 單位數值
	private string m_sPath = string.Empty;
	private string m_sFile = string.Empty;
	private string m_sExtension = string.Empty;
	private string m_sCreateTime = string.Empty;
	private string m_sWriteTime = string.Empty;
	private string m_sMin = string.Empty;
	private string m_sMax = string.Empty;
	private string m_sContent = string.Empty;

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

    public void setPath(string _sPath)
    {
        m_sPath = _sPath;
        if(string.Empty != _sPath)
        {
            m_bPath = true;
        }
        else
        {
            m_bPath = false;
        }
    }

    public void setFile(string _sFile)
    {
        m_sFile = _sFile;
        if (string.Empty != _sFile)
        {
            m_bFile = true;
        }
        else
        {
            m_bFile = false;
        }
    }
    public void setExtension(string _sExtension)
    {
        m_sExtension = _sExtension;
        if (string.Empty != _sExtension)
        {
            m_bExtension = true;
        }
        else
        {
            m_bExtension = false;
        }
    }
    public void setCreateTime(string _sCreateTime)
    {
        m_sCreateTime = _sCreateTime;
        if (string.Empty != _sCreateTime)
        {
            m_bCreateTime = true;
        }
        else
        {
            m_bCreateTime = false;
        }
    }
    public void setWriteTime(string _sWriteTime)
    {
        m_sWriteTime = _sWriteTime;
        if (string.Empty != _sWriteTime)
        {
            m_bWriteTime = true;
        }
        else
        {
            m_bWriteTime = false;
        }
    }
    public void setMin(string _sMin)
    {
        m_sMin = _sMin;
        if (string.Empty != _sMin)
        {
            m_bMin = true;
        }
        else
        {
            m_bMin = false;
        }
    }
    public void setMax(string _sMax)
    {
        m_sMax = _sMax;
        if (string.Empty != _sMax)
        {
            m_bMax = true;
        }
        else
        {
            m_bMax = false;
        }
    }
    public void setContent(string _sContent)
    {
        m_sContent = _sContent;
        if (string.Empty != _sContent)
        {
            m_bContent = true;
        }
        else
        {
            m_bContent = false;
        }
    }






    public void setCondition(InputField _sCondition , TextLibrary.selectConditionType _ConditionType)
	{
		switch (_ConditionType) {
		case TextLibrary.selectConditionType.inputFieldpath:
                setPath(_sCondition.text);
            break;
		case TextLibrary.selectConditionType.inputField:
                setFile(_sCondition.text);
            break;
		case TextLibrary.selectConditionType.inputExtension:
                setExtension(_sCondition.text);
            break;
		case TextLibrary.selectConditionType.inputCreateTime:
                setCreateTime(_sCondition.text);
            break;
		case TextLibrary.selectConditionType.inputWriteTime:
                setWriteTime(_sCondition.text);
			break;
		case TextLibrary.selectConditionType.inputLengthMin:
                setMin(_sCondition.text);
			break;
		case TextLibrary.selectConditionType.inputLengthMax:
                setMax(_sCondition.text);
			break;
		case TextLibrary.selectConditionType.inputContent:
                setContent(_sCondition.text);
			break;
		}
	}
}

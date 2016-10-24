using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class FileInFoView : MonoBehaviour {
	private ConditionData m_ConditionData = new ConditionData();
	private FileInFoControl m_FileInFoControl = new FileInFoControl ();
	private List<bool> m_arrConditionBool = new List<bool>();
	private List<string> m_arrFiles = new List<string>();
	private Text m_text =null;



	void Start () {
		m_FileInFoControl.Appear += _view;
		_readCondition ();
		m_text = GameObject.FindGameObjectWithTag ("outputFiles").GetComponent<Text> ();
		m_FileInFoControl.assignCondition (m_ConditionData);
	}

	//呈現
	private  void _view(string _sfile){
		m_text.text = m_text.text + _sfile + "\n";
	}

	//讀取外部條件
	private void _readCondition(){
		string _sFileCondition = null;
		bool _bConditionBool = false;
		int _iDropValue = TextLibrary.IZERO;
		_sFileCondition = GameObject.FindGameObjectWithTag("inputFieldpath").GetComponent<InputField>().text;
		_bConditionBool = _determineBool (_sFileCondition);
		m_ConditionData.setPath (_sFileCondition);
		m_ConditionData.setPathBool (_bConditionBool);

		_sFileCondition = GameObject.FindGameObjectWithTag("inputField").GetComponent<InputField>().text;
		_bConditionBool = _determineBool (_sFileCondition);
		m_ConditionData.setFile (_sFileCondition);
		m_ConditionData.setFileBool (_bConditionBool);

		_sFileCondition = GameObject.FindGameObjectWithTag("inputExtension").GetComponent<InputField>().text;
		_bConditionBool = _determineBool (_sFileCondition);
		m_ConditionData.setExtension (_sFileCondition);
		m_ConditionData.setExtensionBool (_bConditionBool);

		_sFileCondition = GameObject.FindGameObjectWithTag("inputCreateTime").GetComponent<InputField>().text;
		_bConditionBool = _determineBool (_sFileCondition);
		m_ConditionData.setCreateTime (_sFileCondition);
		m_ConditionData.setCreateTimeBool (_bConditionBool);

		_sFileCondition = GameObject.FindGameObjectWithTag("inputWriteTime").GetComponent<InputField>().text;
		_bConditionBool = _determineBool (_sFileCondition);
		m_ConditionData.setWriteTime (_sFileCondition);
		m_ConditionData.setWriteTimeBool (_bConditionBool);

		_sFileCondition = GameObject.FindGameObjectWithTag("inputLengthMin").GetComponent<InputField>().text;
		_bConditionBool = _determineBool (_sFileCondition);
		m_ConditionData.setMin (_sFileCondition);
		m_ConditionData.setMinBool (_bConditionBool);

		_sFileCondition = GameObject.FindGameObjectWithTag("inputLengthMax").GetComponent<InputField>().text;
		_bConditionBool = _determineBool (_sFileCondition);
		m_ConditionData.setMax (_sFileCondition);
		m_ConditionData.setMaxBool (_bConditionBool);

		_sFileCondition = GameObject.FindGameObjectWithTag("inputContent").GetComponent<InputField>().text;
		_bConditionBool = _determineBool (_sFileCondition);
		m_ConditionData.setContent (_sFileCondition);
		m_ConditionData.setContentBool (_bConditionBool);


		_iDropValue = GameObject.FindGameObjectWithTag ("mindropdowm").GetComponent<Dropdown> ().value;
		m_ConditionData.setMinUnit (_iDropValue);

		_iDropValue = GameObject.FindGameObjectWithTag ("maxdropdowm").GetComponent<Dropdown> ().value;
		m_ConditionData.setMaxUnit (_iDropValue);
	}

	//判斷外面各條件是否輸入資料
	private bool _determineBool(string _sContent){
		if (TextLibrary.IZERO == _sContent.Length) {
			return false;
		} else {
			return true;
		}
	}
}

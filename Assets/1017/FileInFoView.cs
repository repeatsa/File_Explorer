using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Threading;
//using System.ComponentModel;


public class FileInFoView : MonoBehaviour {
	private ConditionData m_ConditionData = new ConditionData();
	private FileInFoControl m_FileInFoControl = new FileInFoControl ();
	private List<string> m_arrFiles = new List<string>();
	private Text m_text =null;
	private string[] m_arrsCondition = new string[]{"inputFieldpath","inputField","inputExtension","inputCreateTime","inputWriteTime","inputLengthMin","inputLengthMax","inputContent"};
	private Thread m_Thread ;
    private InputField[] m_arrConditionInputField = new InputField[8];

    void Start () {
		int _iDropValue = 0;
		TextLibrary.selectConditionType _selectconditiontype = TextLibrary.selectConditionType.None;
		for (int i = 0; i < m_arrsCondition.Length; ++i) {
            m_arrConditionInputField[i] = GameObject.FindGameObjectWithTag(m_arrsCondition[i]).GetComponent<InputField>();
			_selectconditiontype = (TextLibrary.selectConditionType)System.Enum.Parse(typeof(TextLibrary.selectConditionType),m_arrsCondition[i]);
			m_ConditionData.setCondition(m_arrConditionInputField[i], _selectconditiontype);
		}
		_iDropValue = GameObject.FindGameObjectWithTag ("mindropdowm").GetComponent<Dropdown> ().value;
		m_ConditionData.setMinUnit (_iDropValue);
		_iDropValue = GameObject.FindGameObjectWithTag ("maxdropdowm").GetComponent<Dropdown> ().value;
		m_ConditionData.setMaxUnit (_iDropValue);
		m_text = GameObject.FindGameObjectWithTag ("outputFiles").GetComponent<Text> ();

        m_FileInFoControl.AppearDelegate += _view;
        m_FileInFoControl.readyToWork(m_ConditionData);
        //m_Thread = new Thread (_NewThreadToControl);
		//m_Thread.Start ();

       /* m_FileInFoControl.m_BackgroundWorker.WorkerReportsProgress = true;
        m_FileInFoControl.m_BackgroundWorker.WorkerSupportsCancellation = true;
        m_FileInFoControl.m_BackgroundWorker.DoWork += new DoWorkEventHandler(m_FileInFoControl.bw_DoWork);
        m_FileInFoControl.m_BackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(m_FileInFoControl.bw_ProgressChanged);
        m_FileInFoControl.m_BackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(m_FileInFoControl.bw_RunWorkerCompleted);
        */

    }




    /*private void _NewThreadToControl(){
		m_FileInFoControl.readyToWork(m_ConditionData);
	}*/
	//呈現
	private  void _view(string _sfile){
			m_text.text = m_text.text + _sfile + "\n";
	}

	private void OnDisable(){
		//m_Thread.Abort ();
	}
}
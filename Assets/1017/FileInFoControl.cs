using System.Collections.Generic;
using System.IO;
//using System.ComponentModel;



public class FileInFoControl {

    private FileInFoModel m_FileInFoModel = null;
    private FileManager m_FileManager = null;
    private delegate void m_FileDelegate(string _sFile);
    private m_FileDelegate m_AppearDelegate;
    private ConditionData m_ConditionData = null;
    private bool m_bAnswer = false;

    public m_FileDelegate bbbb(){
       return m_AppearDelegate;
    }

    public void readyToWork(ConditionData _ConditionData)
    {
        m_FileInFoModel = new FileInFoModel();
        m_FileManager = new FileManager();
        //m_FileManager.JudgmentDelegate += assignCondition;
        m_ConditionData = _ConditionData;
        m_FileManager._searchPathAndSetFile(m_ConditionData.getPath());
    }

}
using System.Collections.Generic;
using System.IO;
//using System.ComponentModel;



public class FileInFoControl  {

	private FileInFoModel m_FileInFoModel = new FileInFoModel();
	private FileManager m_FileManager = new FileManager();
    public delegate void FileDelegate(string _sFile);
	public  FileDelegate AppearDelegate;
    private ConditionData m_ConditionData = null;
    //private List<FileData> m_arrFiles = null;
    // public BackgroundWorker m_BackgroundWorker = new BackgroundWorker();
    private bool m_bAnswer = false;



    /*
    public void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        m_FileInFoControl.assignCondition(m_ConditionData);
    }
    public void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
       
    }
    public void bw_RunWorkerCompleted(object sender, RunWorkerComp0letedEventArgs e)
    {
        Debug.Log("結束");
    }
    */




    public void readyToWork(ConditionData _ConditionData)
    {
        m_FileManager.JudgmentDelegate += assignCondition;
        m_ConditionData = _ConditionData;
        m_FileManager._searchPathAndSetFile(m_ConditionData.getPath());
    }

    //將檔案DATA進行條件DATA比對
    public void assignCondition(List<FileData> _arrFiles)
    {
        bool _bPathSafe = false;
        try
        {
            if (Directory.Exists(m_ConditionData.getPath()))
            {
                _bPathSafe = true;
            }
        }
        catch
        {
            _bPathSafe = false;
        }
        if (_bPathSafe)
        {
            for (int _iFileOrder = 0; _iFileOrder < _arrFiles.Count; ++_iFileOrder)
            {

                if (m_ConditionData.getFileBool())
                {
                    m_bAnswer = m_FileInFoModel.filterNameExtension(
                        _arrFiles[_iFileOrder].getFile(),
                        m_ConditionData.getFile()
                    );
                    if (true != m_bAnswer)
                    {
                        continue;
                    }
                }
                if (m_ConditionData.getExtensionBool())
                {
                    m_bAnswer = m_FileInFoModel.filterNameExtension(
                        _arrFiles[_iFileOrder].getFile(),
                        m_ConditionData.getExtension()
                    );
                    if (true != m_bAnswer)
                    {
                        continue;
                    }
                }
                if (m_ConditionData.getCreateTimeBool())
                {
                    m_bAnswer = m_FileInFoModel.changeInFoAndFilterTimesType(
                        m_ConditionData.getCreateTime(),
                        _arrFiles[_iFileOrder].getCreateTime()
                    );
                    if (true != m_bAnswer)
                    {
                        continue;
                    }
                }
                if (m_ConditionData.getWriteTimeBool())
                {
                    m_bAnswer = m_FileInFoModel.changeInFoAndFilterTimesType(
                        m_ConditionData.getWriteTime(),
                        _arrFiles[_iFileOrder].getWriteTime()
                    );
                    if (true != m_bAnswer)
                    {
                        continue;
                    }
                }
                if (m_ConditionData.getMinBool())
                {
                    TextLibrary.selectMinMaxType _selectminmaxtype = TextLibrary.selectMinMaxType.None;
                    if (m_ConditionData.getMaxBool())
                    {
                        _selectminmaxtype = TextLibrary.selectMinMaxType.MinAndMax;
                    }
                    else
                    {
                        _selectminmaxtype = TextLibrary.selectMinMaxType.Min;
                    }
                    m_bAnswer = m_FileInFoModel.filterSize(
                        _arrFiles[_iFileOrder],
                        _arrFiles[_iFileOrder].getFileFolerType(),
                        m_ConditionData,
                        _selectminmaxtype
                    );
                    if (true != m_bAnswer)
                    {
                        continue;
                    }
                }
                if (m_ConditionData.getMaxBool())
                {
                    TextLibrary.selectMinMaxType _selectminmaxtype = TextLibrary.selectMinMaxType.Max;
                    m_bAnswer = m_FileInFoModel.filterSize(
                        _arrFiles[_iFileOrder],
                        _arrFiles[_iFileOrder].getFileFolerType(),
                        m_ConditionData,
                        _selectminmaxtype
                    );
                    if (true != m_bAnswer)
                    {
                        continue;
                    }
                }
                if (m_ConditionData.getContentBool())
                {
                    m_bAnswer = m_FileInFoModel.filterContent(
                        _arrFiles[_iFileOrder].getFile(),
                        m_ConditionData.getContent(),
                        _arrFiles[_iFileOrder].getFileFolerType()
                    );
                    if (true != m_bAnswer)
                    {
                        continue;
                    }
                }
                AppearDelegate(_arrFiles[_iFileOrder].getName());
            }
        }
	}
}
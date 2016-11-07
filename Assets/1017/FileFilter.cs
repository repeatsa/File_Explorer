using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;


public class FileFilter {

    private ConditionData m_ConditionData = null;
    private FileInFoModel m_FileInFoModel = null;
    private bool m_bAnswer = false;
    


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

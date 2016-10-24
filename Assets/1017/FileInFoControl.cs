using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class FileInFoControl  {

	private FileInFoModel m_FileInFoModel = new FileInFoModel();
	private FileManager m_FileManager = new FileManager();
	public delegate void FileDelegate(string _sFile);
	public  FileDelegate Appear;

	//將檔案DATA進行條件DATA比對
	public void assignCondition(ConditionData _ConditionData){
		List<FileData> _arrFiles = m_FileManager.getFiles (_ConditionData.getPath());
		List<string> _arrsAnswer = new List<string> ();
		string _sAnswer = null;
		try{
			if (Directory.Exists (_ConditionData.getPath())) {
				for(int _iFileOrder =0 ; _iFileOrder < _arrFiles.Count ; ++_iFileOrder)
				{
					if(_ConditionData.getFileBool()){
						_sAnswer = m_FileInFoModel.filterNameExtension(
							_arrFiles[_iFileOrder].getFile(),
							_ConditionData.getFile()
						);
						if(null != _sAnswer)
						{
							Appear(_sAnswer);
							continue;
						}
					}
					if(_ConditionData.getExtensionBool()){
						_sAnswer = m_FileInFoModel.filterNameExtension(
							_arrFiles[_iFileOrder].getFile(),
							_ConditionData.getExtension()
						);
						if(null != _sAnswer)
						{
							Appear(_sAnswer);
							continue;
						}
					}
					if(_ConditionData.getCreateTimeBool()){
						_sAnswer = m_FileInFoModel.changeInFoAndFilterTimesType(
							_arrFiles[_iFileOrder].getFile(),
							_ConditionData.getCreateTime(),
							_arrFiles[_iFileOrder].getCreateTime(),
							TextLibrary.IONE
						);
						if(null != _sAnswer)
						{
							Appear(_sAnswer);
							continue;
						}
					}
					if(_ConditionData.getWriteTimeBool()){
						_sAnswer = m_FileInFoModel.changeInFoAndFilterTimesType(
							_arrFiles[_iFileOrder].getFile(),
							_ConditionData.getWriteTime(),
							_arrFiles[_iFileOrder].getWriteTime(),
							TextLibrary.ITWO
						);
						if(null != _sAnswer)
						{
							Appear(_sAnswer);
							continue;
						}
					}
					if(_ConditionData.getMinBool()){
						_sAnswer = m_FileInFoModel.filterSize(
							_arrFiles[_iFileOrder].getFile(),
							_arrFiles[_iFileOrder].getkey(),
							_ConditionData
						);
						if(null != _sAnswer)
						{
							Appear(_sAnswer);
							continue;
						}
					}
					if(_ConditionData.getMaxBool()){
						_sAnswer = m_FileInFoModel.filterSize(
							_arrFiles[_iFileOrder].getFile(),
							_arrFiles[_iFileOrder].getkey(),
							_ConditionData
						);
						if(null != _sAnswer)
						{
							Appear(_sAnswer);
							continue;
						}
					}
					if(_ConditionData.getContentBool()){
						_sAnswer = m_FileInFoModel.filterContent(
							_arrFiles[_iFileOrder].getFile(),
							_ConditionData.getContent(),
							_arrFiles[_iFileOrder].getkey()
						);
						if(null != _sAnswer)
						{
							Appear(_sAnswer);
							continue;
						}
					}

				}
			}
			//return _arrsAnswer;
		}
		catch{
			//return null;
		}
	}
}

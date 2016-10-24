using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class FileInFoModel  {

	//篩選名稱及副檔名
	public string filterNameExtension (string _sFile,string _sFactor ){
		int iNumber =  _sFile.IndexOf(_sFactor);
		if (iNumber > TextLibrary.IZERO) {
			return _sFile;
		} else {
			return null;
		}
	}

	//轉換成資料流跟篩選狀態
	public string changeInFoAndFilterTimesType(string _sFile, string _sFactor ,string _sTime,  int _iType){
		TextLibrary.selectCreateWriteType selectType = TextLibrary.selectCreateWriteType.Zero;
		string _sData = null;
		selectType = (TextLibrary.selectCreateWriteType)_iType;

		if (TextLibrary.selectCreateWriteType.Frist == selectType) {
			_sData = _filterCreateWriteTime (_sFile,_sTime, _sFactor);
		}
		if (TextLibrary.selectCreateWriteType.Second == selectType) {
			_sData = _filterCreateWriteTime (_sFile,_sTime, _sFactor);
		}
		return _sData;
	}

	//篩選創建及修改時間
	private string _filterCreateWriteTime(string _sFile,string _sData,string _sFactor ){
		int iSpace = _sData.IndexOf (TextLibrary.SSPACE);
		_sData = _sData.Substring (TextLibrary.IZERO, iSpace);
		if (_sData == _sFactor) {
			return _sFile;
		} else {
			return null;
		}
	}
	//做比大還比小的判定，type{事件，最小值單位，最大值單位}
	public string filterSize(string _sfile,int _iKey,ConditionData _ConditionData){
		TextLibrary.selectCreateWriteType selectType = TextLibrary.selectCreateWriteType.Zero;
		FileInfo _fileinfo = new FileInfo (_sfile);
		string _sOutPutFile = null;
		if (true == _ConditionData.getMinBool () && true == _ConditionData.getMaxBool ()) {
			selectType = TextLibrary.selectCreateWriteType.Third;
		} else if (true == _ConditionData.getMinBool ()) {
			selectType = TextLibrary.selectCreateWriteType.Frist;
		}
		else if (true ==  _ConditionData.getMaxBool ()) {
			selectType = TextLibrary.selectCreateWriteType.Second;
		}
		if (TextLibrary.IONE !=_iKey) {
			double _dMin = TextLibrary.IZERO;
			double _dMax = TextLibrary.IZERO;
			switch (selectType) {
			case TextLibrary.selectCreateWriteType.Frist:
				_dMin = _filterFilesUnit (_ConditionData.getMin(),_ConditionData.getMinUnit());
				if (_fileinfo.Length >= _dMin) {
					_sOutPutFile = _sfile;
				}
				break;
			case TextLibrary.selectCreateWriteType.Second:
				_dMax = _filterFilesUnit (_ConditionData.getMax(), _ConditionData.getMaxUnit());
				if (_fileinfo.Length <= _dMax) {
					_sOutPutFile = _sfile;
				}
				break;
			case TextLibrary.selectCreateWriteType.Third:
				_dMin = _filterFilesUnit (_ConditionData.getMin(), _ConditionData.getMinUnit());
				_dMax = _filterFilesUnit (_ConditionData.getMax(), _ConditionData.getMaxUnit());
				if (_fileinfo.Length <= _dMax && _fileinfo.Length >= _dMin) {
					_sOutPutFile = _sfile;
				}
				break;
			default:
				_sOutPutFile = null;
				break;
			}
			return _sOutPutFile;
		}else{
			return null;
		}
	}
	//篩選檔案單位
	private double _filterFilesUnit(string _sCondition , int _iUnitType){
		TextLibrary.selectSize selectSizeType = TextLibrary.selectSize.BYTE;
		selectSizeType = (TextLibrary.selectSize) _iUnitType;
		double _dConditionSize = TextLibrary.IZERO;
		switch (selectSizeType) {
		case TextLibrary.selectSize.GB:
			_dConditionSize = _changeSizeUnit (_sCondition,_iUnitType);
			break;
		case TextLibrary.selectSize.MB:
			_dConditionSize = _changeSizeUnit (_sCondition,_iUnitType);
			break;
		case TextLibrary.selectSize.KB:
			_dConditionSize = _changeSizeUnit (_sCondition,_iUnitType);
			break;
		case TextLibrary.selectSize.BYTE:
			_dConditionSize = _changeSizeUnit (_sCondition,_iUnitType);
			break;
		default:
			_dConditionSize = TextLibrary.IZERO;
			break;
		}
		return _dConditionSize;
	}
	//轉換單位成Byte
	private double _changeSizeUnit(string _sCondition , int _iUnitType)
	{
		double _dFileSize = TextLibrary.IZERO;
		double _dValue = TextLibrary.IONE;
		if (double.TryParse (_sCondition, out _dFileSize)) {
			for (int i = 0; i < _iUnitType; ++i) {
				_dValue = _dValue * TextLibrary.DCAPACITY;
			}
			_dFileSize = _dFileSize * _dValue;
		} else {	
			_dFileSize = TextLibrary.IZERO;
		}
		return _dFileSize;
	}
	//篩選內容
	public string filterContent(string _sFiles,string _sCondition,int _iKey) {
		StreamReader _SRfile = null;
		string _sFile = null;
		if (_iKey == TextLibrary.IZERO) {
			try {
				_SRfile = new StreamReader (_sFiles);
				string _sSrString = _SRfile.ReadToEnd ();
				if (_sSrString.Contains (_sCondition)) {
					_sFile = _sFiles;
				}
			} catch {
				_sFile = null;
			} finally {
				_SRfile.Close ();
			}
			return _sFile;
		} else {
			return null;
		}
	}
}

using System.IO;

public class FileInFoModel  {

	//篩選名稱及副檔名
	public bool filterNameExtension(string _sFile,string _sFactor ){
		int iNumber =  _sFile.IndexOf(_sFactor);
        bool _bAnswer = false;
        //0以下代表在String找不到此字串
        if (iNumber > 0) {
            _bAnswer = true;
            return _bAnswer;
		} else {
			return _bAnswer;
		}
	}

	//轉換成資料流跟篩選狀態
	public bool changeInFoAndFilterTimesType( string _sFactor ,string _sTime){
        bool _bAnswer = false;
        int _iSpace = _sTime.IndexOf (TextLibrary.SSPACE);
        if (0 > _iSpace)
        {
            return _bAnswer;
        }
		_sTime = _sTime.Substring (0, _iSpace);
		if (_sTime == _sFactor) {
            _bAnswer = true;
		}
		return _bAnswer;
	}
	//做比大還比小的判定，type{事件，最小值單位，最大值單位}
	public bool filterSize(FileData _sfile,TextLibrary.selectFileFolder _FileFolderType,ConditionData _ConditionData, TextLibrary.selectMinMaxType _enumType){
        bool _bAnswer = false;
		if (TextLibrary.selectFileFolder.File ==_FileFolderType) {
			float _fMin = 0.0f;
			float _fMax = 0.0f;
			switch (_enumType) {
			case TextLibrary.selectMinMaxType.Min:
				_fMin = _filterFilesUnit (_ConditionData.getMin(),_ConditionData.getMinUnit());
				if (_sfile.getLength() >= _fMin) {
                        _bAnswer = true;
                }
				break;
			case TextLibrary.selectMinMaxType.Max:
				_fMax = _filterFilesUnit (_ConditionData.getMax(), _ConditionData.getMaxUnit());
				if (_sfile.getLength() <= _fMax) {
                        _bAnswer = true;
                    }
				break;
			case TextLibrary.selectMinMaxType.MinAndMax:
				_fMin = _filterFilesUnit (_ConditionData.getMin(), _ConditionData.getMinUnit());
				_fMax = _filterFilesUnit (_ConditionData.getMax(), _ConditionData.getMaxUnit());
				if (_sfile.getLength() <= _fMax && _sfile.getLength() >= _fMin) {
                        _bAnswer = true;
                    }
				break;
			default:
                    _bAnswer = false;
				break;
			}
			return _bAnswer;
		}else{
			return _bAnswer;
		}
	}
    //篩選檔案單位
    private float _filterFilesUnit(string _sCondition , int _iUnitType){
		TextLibrary.selectSize selectSizeType = TextLibrary.selectSize.BYTE;
		selectSizeType = (TextLibrary.selectSize) _iUnitType;
		float _fConditionSize = 0;
		switch (selectSizeType) {
		case TextLibrary.selectSize.GB:
			_fConditionSize = _changeSizeUnit (_sCondition,_iUnitType);
			break;
		case TextLibrary.selectSize.MB:
			_fConditionSize = _changeSizeUnit (_sCondition,_iUnitType);
			break;
		case TextLibrary.selectSize.KB:
			_fConditionSize = _changeSizeUnit (_sCondition,_iUnitType);
			break;
		case TextLibrary.selectSize.BYTE:
			_fConditionSize = _changeSizeUnit (_sCondition,_iUnitType);
			break;
		default:
			_fConditionSize = 0;
			break;
		}
		return _fConditionSize;
	}
	//轉換單位成Byte
	private float _changeSizeUnit(string _sCondition , int _iUnitType)
	{	//條件轉成Byte
		float _fFileSize = 0.0f;
		//算次方的初始值
		float _fValue = 1.0f;
		if (float.TryParse (_sCondition, out _fFileSize)) {
			for (int i = 0; i < _iUnitType; ++i) {
				_fValue = _fValue * TextLibrary.FCAPACITY;
			}
			_fFileSize = _fFileSize * _fValue;
		} else {	
			_fFileSize = 0;
		}
		return _fFileSize;
	}
	//篩選內容
	public bool filterContent(string _sFiles,string _sCondition,TextLibrary.selectFileFolder _Type) {
		StreamReader _SRfile = null;
		bool _bAnswer = false;
		if (_Type == TextLibrary.selectFileFolder.File) {
			try {
				_SRfile = new StreamReader (_sFiles);
				string _sSrString = _SRfile.ReadToEnd ();
				if (_sSrString.Contains (_sCondition)) {
                    _bAnswer = true;
				}
			} catch {
			} finally {
				_SRfile.Close ();
			}
			return _bAnswer;
		} else {
			return _bAnswer;
		}
	}
}
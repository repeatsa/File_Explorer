using UnityEngine;
using System.Collections;
	using System.IO;
using System.Threading;


public class file_Control {
	file_Model fileModel = new file_Model();
	private ArrayList _findArray = new ArrayList ();
	public ArrayList arrAnswerFile = new ArrayList ();
	const int ZERO = 0;
	const int ONE = 1;
	const int TWO = 2;
	const int THREE = 3;
	const int FIVE = 5;
	const float CAPACITY = 1024;
	const string SPACE = " ";
	const string POINT = ".";
	public 	Thread threadFiles =null;
	private string _ContenT = null;
	private int _LengthType = 0;
	const string KB = "KB";
	const string MB = "MB";
	const string GB = "GB";
	private float _floatLengthMin = 0.0f;
	private float _floatLengthMax = 0.0f;
	public void findFile(string sPath,string sFile,string sExtensionName,string sCreateTime,string sWriteTime,string sLengthMin,string sLengthMax,string sContent){
		
		if(Directory.Exists (sPath)) {
			fileModel.fModel (sPath);
			for (int seat = 0; seat < fileModel.arrFileArryList.Count; seat++) {
				
				if (sFile.Length != ZERO) {
					addFileAndExtension (sFile, seat);
				}

				if (sExtensionName.Length != ZERO) {
					addFileAndExtension (sExtensionName, seat);
					Debug.Log ("已進入副檔名區");
					}
				if (sCreateTime.Length != ZERO) {
					FileInfo fileFo = new FileInfo (fileModel.arrFileArryList [seat].ToString ());
					string fileFoString = fileFo.CreationTime.ToString ();
					removeSuffixAndAddArray (fileFoString,sCreateTime,seat);
				}
				if (sWriteTime.Length != ZERO) {
					string fileFo = Directory.GetLastWriteTime (fileModel.arrFileArryList [seat].ToString ()).ToString ();
					removeSuffixAndAddArray (fileFo,sWriteTime,seat);
				}

				if (sLengthMin.Length != ZERO && sLengthMax.Length != ZERO) {
					_LengthType = ONE;
					chooseLength (_LengthType,seat,sLengthMin,sLengthMax,ZERO);
				}else if (sLengthMin.Length != ZERO || sLengthMax.Length != ZERO) {
					_LengthType = TWO;
					if (sLengthMin.Length != ZERO) {
						chooseLength (_LengthType, seat, sLengthMin, sLengthMax, ZERO);
					} else {
						chooseLength (_LengthType,seat,sLengthMin,sLengthMax,ONE);
					}
				}
				if (sContent.Length != ZERO) {
					_ContenT = sContent;
					threadFiles = new Thread (readFiles);
					threadFiles.Start (seat);
				}
				if (sFile.Length == ZERO && sExtensionName.Length == ZERO && sCreateTime.Length == ZERO && sWriteTime.Length == ZERO && sLengthMin.Length == ZERO && sLengthMax.Length == ZERO && sContent.Length == ZERO) {
					_findArray.Add (fileModel.arrFileArryList [seat]);
				}
			}

		}
		foreach(string sFiles in _findArray){
			if(!arrAnswerFile.Contains(sFiles)){
				arrAnswerFile.Add(sFiles);
			}
		}
	}
	private void addFileAndExtension (string sFactor , int iSeat){
		int strNumber =  fileModel.arrFileArryList [iSeat].ToString().IndexOf(sFactor);
		if (strNumber > ZERO) {
			_findArray.Add (fileModel.arrFileArryList [iSeat]);
		}
	}

	private void removeSuffixAndAddArray(string sFile,string sCondition,int iSeat){
		int inderSpeace = sFile.IndexOf (SPACE);
		sFile = sFile.Substring (ZERO, inderSpeace);
		if (sFile == sCondition) {
			_findArray.Add (fileModel.arrFileArryList [iSeat]);
		}
	}
	private void readFiles(object oSeat){
		
		string files = fileModel.arrFileArryList [(int)oSeat].ToString ();
		int filesNumber = files.LastIndexOf (POINT);
		filesNumber = files.Length - filesNumber;
		if (filesNumber <= FIVE) {
			StreamReader fileSR = new StreamReader (fileModel.arrFileArryList [(int)oSeat].ToString ());
			string srString = fileSR.ReadToEnd ();
			if (srString.Contains (_ContenT)) {
				_findArray.Add (fileModel.arrFileArryList [(int)oSeat]);
				Debug.Log ("已進入檔案內容區");
				}
			}
	}
	private void chooseLength(int iLengthtype,int iSeat,string sMin,string sMax, int iType){
		string str = fileModel.arrFileArryList [iSeat].ToString ();
		int strNumber = str.LastIndexOf (POINT);
		strNumber = str.Length - strNumber;
		if (strNumber <= FIVE) {
			FileInfo fileFo = new FileInfo (fileModel.arrFileArryList [iSeat].ToString ());

			switch(iLengthtype)
			{
			case ONE:
				attarneySize (sMin,ref _floatLengthMin);
				attarneySize (sMax,ref _floatLengthMax);
				if (_floatLengthMin <= fileFo.Length && _floatLengthMax >= fileFo.Length) {
					_findArray.Add (fileModel.arrFileArryList [iSeat]);
					Debug.Log ("輸入了大和小");
				}
				break;
			case TWO:
				if (iType == ZERO) {
					attarneySize (sMin, ref _floatLengthMin);
				} else {
					attarneySize (sMax,ref _floatLengthMax);
				}
				if (_floatLengthMin <= fileFo.Length) {
					_findArray.Add (fileModel.arrFileArryList [iSeat]);
					Debug.Log ("輸入了小");
				}else if (_floatLengthMax >= fileFo.Length) {
					_findArray.Add (fileModel.arrFileArryList [iSeat]);
					Debug.Log ("輸入了大");
					}
				break;
			}
		}
	}
	public void closeThread(bool bYesOrNo){
		if (_ContenT != null) {
			if (bYesOrNo) {
				Debug.Log (bYesOrNo);
				threadFiles.Abort ();
			}
		}
	}
	private void attarneySize(string sMin,ref float fMin){
		int iCount = sMin.Length - TWO;

		if (sMin.Contains (GB)) {
			
			forSize (sMin, iCount, THREE, ref fMin);
		} else if (sMin.Contains (MB)) {
			
			forSize (sMin, iCount, TWO, ref fMin);
		} else if (sMin.Contains (KB)) {

			forSize (sMin, iCount, ONE, ref fMin);
		} else {
			fMin = float.Parse (sMin);
		}
	}
	private void forSize(string sMin,int iCount,int iAlltimes,ref float fMin){
		sMin = sMin.Substring (ZERO,iCount);
		fMin = float.Parse (sMin);
		for (int onetime = ONE; onetime <= iAlltimes; ++onetime) {
			fMin = fMin * CAPACITY;
		}
	}
}
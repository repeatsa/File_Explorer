using UnityEngine;
using System.Collections;
using System.IO;
using System.Threading;


public class file_Control {
	file_Model fileModel = new file_Model();
	private ArrayList _findArray = new ArrayList ();
	public ArrayList arrAnswerFile = new ArrayList ();
	private const int _zero = 0;
	private int _one = 1;
	private int _two = 2;
	private int _three = 3;
	private int _five = 5;
	private float _capacity = 1024;
	private string _space = " ";
	private string _point = ".";
	public 	Thread threadFiles =null;
	private string _ContenT = null;
	private int _LengthType = 0;
	private string _KB = "KB";
	private string _MB = "MB";
	private string _GB = "GB";
	private float _floatLengthMin = 0.0f;
	private float _floatLengthMax = 0.0f;
	public void findFile(string path,string file,string ExtensionName,string CreateTime,string WriteTime,string fLengthMin,string fLengthMax,string Content){
		
		if(Directory.Exists (path)) {
			fileModel.fModel (path);
			for (int seat = 0; seat < fileModel.arrFileArryList.Count; seat++) {
				
				if (file.Length != _zero) {
					addFileAndExtension (file, seat);
				}

				if (ExtensionName.Length != _zero) {
					addFileAndExtension (ExtensionName, seat);
					Debug.Log ("已進入副檔名區");
					}
				if (CreateTime.Length != _zero) {
					FileInfo fileFo = new FileInfo (fileModel.arrFileArryList [seat].ToString ());
					string fileFoString = fileFo.CreationTime.ToString ();
					removeSuffixAndAddArray (fileFoString,CreateTime,seat);
				}
				if (WriteTime.Length != _zero) {
					string fileFo = Directory.GetLastWriteTime (fileModel.arrFileArryList [seat].ToString ()).ToString ();
					removeSuffixAndAddArray (fileFo,WriteTime,seat);
				}

				if (fLengthMin.Length != _zero && fLengthMax.Length != _zero) {
					_LengthType = _one;
					chooseLength (_LengthType,seat,fLengthMin,fLengthMax,_zero);
				}else if (fLengthMin.Length != _zero || fLengthMax.Length != _zero) {
					_LengthType = _two;
					if (fLengthMin.Length != _zero) {
						chooseLength (_LengthType, seat, fLengthMin, fLengthMax, _zero);
					} else {
						chooseLength (_LengthType,seat,fLengthMin,fLengthMax,_one);
					}
				}
				if (Content.Length != _zero) {
					_ContenT = Content;
					threadFiles = new Thread (readFiles);
					threadFiles.Start (seat);
				}
				if (file.Length == _zero && ExtensionName.Length == _zero && CreateTime.Length == _zero && WriteTime.Length == _zero && fLengthMin.Length == _zero && fLengthMax.Length == _zero && Content.Length == _zero) {
					_findArray.Add (fileModel.arrFileArryList [seat]);
				}
			}

		}
		foreach(string files in _findArray){
			if(!arrAnswerFile.Contains(files)){
				arrAnswerFile.Add(files);
			}
		}
	}
	private void addFileAndExtension (string factor , int seat){
		int strNumber =  fileModel.arrFileArryList [seat].ToString().IndexOf(factor);
		if (strNumber > _zero) {
			_findArray.Add (fileModel.arrFileArryList [seat]);
		}
	}

	private void removeSuffixAndAddArray(string file,string condition,int seat){
		int inderSpeace = file.IndexOf (_space);
		file = file.Substring (_zero, inderSpeace);
		if (file == condition) {
			_findArray.Add (fileModel.arrFileArryList [seat]);
		}
	}
	private void readFiles(object seat){
		
		string files = fileModel.arrFileArryList [(int)seat].ToString ();
		int filesNumber = files.LastIndexOf (_point);
		filesNumber = files.Length - filesNumber;
		if (filesNumber <= _five) {
			StreamReader fileSR = new StreamReader (fileModel.arrFileArryList [(int)seat].ToString ());
			string srString = fileSR.ReadToEnd ();
			if (srString.Contains (_ContenT)) {
				_findArray.Add (fileModel.arrFileArryList [(int)seat]);
				Debug.Log ("已進入檔案內容區");
				}
			}
	}
	private void chooseLength(int lengthtype,int seat,string min,string max, int type){
		string str = fileModel.arrFileArryList [seat].ToString ();
		int strNumber = str.LastIndexOf (_point);
		strNumber = str.Length - strNumber;
		if (strNumber <= _five) {
			FileInfo fileFo = new FileInfo (fileModel.arrFileArryList [seat].ToString ());

			switch(lengthtype)
			{
			case 1:
				attarneySize (min,ref _floatLengthMin);
				attarneySize (max,ref _floatLengthMax);
				if (_floatLengthMin <= fileFo.Length && _floatLengthMax >= fileFo.Length) {
					_findArray.Add (fileModel.arrFileArryList [seat]);
					Debug.Log ("輸入了大和小");
				}
				break;
			case 2:
				if (type == _zero) {
					attarneySize (min, ref _floatLengthMin);
				} else {
					attarneySize (max,ref _floatLengthMax);
				}
				if (_floatLengthMin <= fileFo.Length) {
					_findArray.Add (fileModel.arrFileArryList [seat]);
					Debug.Log ("輸入了小");
				}else if (_floatLengthMax >= fileFo.Length) {
					_findArray.Add (fileModel.arrFileArryList [seat]);
					Debug.Log ("輸入了大");
					}
				break;
			}
		}
	}
	public void closeThread(bool YesOrNo){
		if (_ContenT != null) {
			if (YesOrNo) {
				Debug.Log (YesOrNo);
				threadFiles.Abort ();
			}
		}
	}
	private void attarneySize(string min,ref float Fmin){
		int count = min.Length - _two;

		if (min.Contains (_GB)) {
			
			forSize (min, count, _three, ref Fmin);
		} else if (min.Contains (_MB)) {
			
			forSize (min, count, _two, ref Fmin);
		} else if (min.Contains (_KB)) {

			forSize (min, count, _one, ref Fmin);
		} else {
			Fmin = float.Parse (min);
		}
	}
	private void forSize(string min,int count,int alltimes,ref float Fmin){
		min = min.Substring (_zero,count);
		Fmin = float.Parse (min);
		for (int onetime = _one; onetime <= alltimes; ++onetime) {
			Fmin = Fmin * _capacity;
		}
	}
}
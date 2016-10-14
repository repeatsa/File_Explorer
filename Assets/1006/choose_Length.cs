using UnityEngine;
using System.Collections;
using System.IO;

public class choose_Length {
	private float _fLengthMin = 0.0f;
	private float _fLengthMax = 0.0f;
	find_Word findWord = new find_Word();
	public void chooseLength(string sFile , int iType , string sMin,string sMax, ref bool bVictory){
		//string str = fileModel.arrFileArryList [iSeat].ToString ();
		int strNumber = sFile.LastIndexOf (findWord.m_sPoint);
		strNumber = sFile.Length - strNumber;
		if (strNumber <= findWord.m_iFive) {
			FileInfo fileFo = new FileInfo (sFile);
			switch(iType)
			{
			case 1:
				attarneySize (sMin,ref _fLengthMin);
				attarneySize (sMax,ref _fLengthMax);
				if (_fLengthMin <= fileFo.Length && _fLengthMax >= fileFo.Length) {
					find_Control.g_arrAnswerFile.Add(sFile);
					bVictory = true;
				}
				break;
			case 2:
				attarneySize (sMin, ref _fLengthMin);
				if (_fLengthMin <= fileFo.Length) {
					find_Control.g_arrAnswerFile.Add(sFile);
					bVictory = true;
				}
				break;
			case 3:
				attarneySize (sMax,ref _fLengthMax);
				if (_fLengthMax >= fileFo.Length) {
					find_Control.g_arrAnswerFile.Add(sFile);
					bVictory = true;
				}
				break;
			}
		}
	}
	private void attarneySize(string sFile,ref float fLength){
		int iCount = sFile.Length - findWord.m_iTwo;

		if (sFile.ToUpper().Contains (findWord.m_sGB)) {

			forSize (sFile, iCount, findWord.m_iThree, ref fLength);
		} else if (sFile.ToUpper().Contains (findWord.m_sMB)) {

			forSize (sFile, iCount, findWord.m_iTwo, ref fLength);
		} else if (sFile.ToUpper().Contains (findWord.m_sKB)) {

			forSize (sFile, iCount, findWord.m_iOne, ref fLength);
		} else {
			fLength = float.Parse (sFile);
		}
	}
	private void forSize(string sFile,int iCount,int iTimes,ref float fLength){
		sFile = sFile.Substring (findWord.m_iZero,iCount);
		fLength = float.Parse (sFile);
		for (int onetime = findWord.m_iOne; onetime <= iTimes; ++onetime) {
			fLength = fLength * findWord.m_fCapacity;
		}
	}
}

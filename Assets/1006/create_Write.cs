using UnityEngine;
using System.Collections;

public class create_Write  {

	public void removeSuffixAndAddArray(string sFile,string sData, string sCondition ,string sSpace, int iZero , ref bool bVictory){
		int iSpace = sData.IndexOf (sSpace);
		sData = sData.Substring (iZero, iSpace);
		if (sData == sCondition) {
			find_Control.g_arrAnswerFile.Add (sFile);
			bVictory = true;
		}
	}
}
using UnityEngine;
using System.Collections;

public class name_Extension  {

	public void addFileAndExtension (string sFile, string sFactor , int iZero , ref bool bVictory){
		int iNumber =  sFile.IndexOf(sFactor);
		if (iNumber > iZero) {
			find_Control.g_arrAnswerFile.Add (sFile);
			bVictory = true;

		}
	}
}

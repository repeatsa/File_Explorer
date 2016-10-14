using UnityEngine;
using System.Collections;
using System.IO;

public class read_files {

	find_Word findWord = new find_Word();

	public void readFiles(string sFile,int iKeys,string sContent , ref bool bVictory){

		if (iKeys == findWord.m_iOne) {
			StreamReader fileSR = new StreamReader (sFile);
			string srString = fileSR.ReadToEnd ();
			if (srString.Contains (sContent)) {
				find_Control.g_arrAnswerFile.Add (sFile);
				bVictory = true;
			}
		}
	}
}

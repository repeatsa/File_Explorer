using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class find_Model{
	find_Word findWord = new find_Word();
	public List<string> arrFile = new List<string> ();
	public List<int> arrKeys = new List<int> ();
	public void fModel (string sPath)
	{
		_findDirectories (sPath);
		foreach (string curfile in Directory.GetFiles(sPath)) {
			arrFile.Add (curfile);
			arrKeys.Add (findWord.m_iOne);
		}
	}
	private void _findDirectories(string sPath) {
		foreach (string curfolder in Directory.GetDirectories(sPath)) {
			arrFile.Add (curfolder);
			arrKeys.Add (findWord.m_iTwo);
			foreach (string curfile in Directory.GetFiles(curfolder)) {
				arrFile.Add (curfile);
				arrKeys.Add (findWord.m_iOne);
			}
			_findDirectories (curfolder);
		}
	}
}
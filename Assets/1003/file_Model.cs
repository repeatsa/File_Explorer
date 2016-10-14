using UnityEngine;
using System.Collections;
using System.IO;

public class file_Model {
	public ArrayList arrFileArryList = new ArrayList ();
	public void fModel (string path)
	{
		foreach (string curfolder in Directory.GetDirectories(path)) {
			arrFileArryList.Add (curfolder);
			foreach (string curfile in Directory.GetFiles(curfolder)) {
				arrFileArryList.Add (curfile);
			}
		}
		foreach (string curfile in Directory.GetFiles(path)) {
			arrFileArryList.Add (curfile);
		}
	}
}

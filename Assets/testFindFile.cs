using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class testFindFile : MonoBehaviour {
	
	//string result;
	// Use this for initialization
	void Start () {
		string DPath = Application.dataPath;
		print (DPath);

		string result = Path.GetFileNameWithoutExtension(DPath);
		/*result = Path.GetFullPath(DPath);
		print (result);
		result = result + "\\";
		print (result);
		result = Path.GetExtension(DPath);
		print (result);
		result = Path.GetPathRoot(DPath);
		print (result);*/


		int num = DPath.LastIndexOf ("/");
		string last_DPath = DPath.Substring (0,num);
		DirectoryInfo last_directoryInfo = new DirectoryInfo (last_DPath);
		foreach (FileInfo curfile in last_directoryInfo.GetFiles("*.*")) {
			string filename = curfile.Name;
			print ("上一層檔案有:" + filename);
		}
		foreach (DirectoryInfo curfolder in last_directoryInfo.GetDirectories()) {
			string folername = curfolder.Name;
			print ("上一層資料夾內有:" + folername);
		}



		DirectoryInfo directoryInfo = new DirectoryInfo (DPath);
		foreach (DirectoryInfo curfolder in directoryInfo.GetDirectories()) {
			string foldername = curfolder.Name;
			print (result+"內有資料夾名為:"+foldername);
			DPath = DPath + "/" + foldername;
			DirectoryInfo next_directoryInfo = new DirectoryInfo (DPath);
			foreach (DirectoryInfo next_curfolder in next_directoryInfo.GetDirectories()) {
				string next_folername = next_curfolder.Name;
				print (foldername+"內有資料夾名為:"+next_folername);
			}
			foreach (FileInfo next_curfoler in next_directoryInfo.GetFiles("*.*")) {
				string next_folername = next_curfoler.Name;
				print (foldername+"內有檔案名為:"+next_folername);
			}
		}
		foreach (FileInfo curfile in directoryInfo.GetFiles("*.*")) {
			string filename = curfile.Name;
			print (result+"內有檔案名為:"+filename);
		}









		/*foreach (FileInfo curfile in directoryInfo.GetFiles("*.*")) {
			string filename = curfile.Name;
			print ("當前資料夾內有:_"+filename);
			int next_num = filename.LastIndexOf (".");
			filename = filename.Substring (0,next_num);
			DPath = DPath + "/" + filename;
			if (Directory.Exists (DPath)) {
				directoryInfo = new DirectoryInfo (DPath);
				foreach (FileInfo next_curfile in directoryInfo.GetFiles("*.*")) {
					string next_filename = next_curfile.Name;
					print ("下一層資料夾內有:_" + next_filename);
				}
				int last_num = DPath.LastIndexOf ("/");
				DPath = DPath.Substring (0,last_num);
			} else {
				int last_num = DPath.LastIndexOf ("/");
				DPath = DPath.Substring (0,last_num);
			}
		}*/

		/*string next_DPath = DPath + "/testFolder";
		print (next_DPath);
		directoryInfo = new DirectoryInfo (next_DPath);
		foreach (FileInfo curfile in directoryInfo.GetFiles("*.*")) {
			string filename = curfile.Name;
			print ("下一層資料夾內有:_" + filename);
		}*/




		//FileInfo[] fileInfo = directoryInfo.GetFiles("*.jpg", SearchOption.TopDirectoryOnly);
		//print (fileInfo[0]);

	}

	// Update is called once per frame
	void Update () {
	}
}

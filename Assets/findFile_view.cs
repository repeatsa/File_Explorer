using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class findFile_view : MonoBehaviour {


	public void view_Folder(string folderName){
		GameObject folder = GameObject.FindGameObjectWithTag ("outputFolder");
		folder.GetComponent<Text> ().text = folderName ;
	}

	public void view_Files(string filesName){
		GameObject files = GameObject.FindGameObjectWithTag ("outputFiles");
		files.GetComponent<Text> ().text = filesName;
	}
}
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class file_View : MonoBehaviour {
	file_Control fileControl = new file_Control();
	private string _Path = null;
	private string _File = null;
	private string _ExtensionName = null;
	private string _CreateTime = null;
	private string _WriteTime = null;
	private string _LengthMin = null;
	private string _LengthMax = null;
	private string _Content = null;

	void Awake (){
		_Path = GameObject.FindGameObjectWithTag("inputFieldpath").GetComponent<InputField>().text;
		_File = GameObject.FindGameObjectWithTag("inputField").GetComponent<InputField>().text;
		_ExtensionName = GameObject.FindGameObjectWithTag("inputExtension").GetComponent<InputField>().text;
		_CreateTime = GameObject.FindGameObjectWithTag("inputCreateTime").GetComponent<InputField>().text;
		_WriteTime = GameObject.FindGameObjectWithTag("inputWriteTime").GetComponent<InputField>().text;
		_LengthMin = GameObject.FindGameObjectWithTag("inputLengthMin").GetComponent<InputField>().text;
		_LengthMax = GameObject.FindGameObjectWithTag("inputLengthMax").GetComponent<InputField>().text;
		_Content = GameObject.FindGameObjectWithTag("inputContent").GetComponent<InputField>().text;
	}

	void Start () {
		fileControl.findFile (_Path,_File,_ExtensionName,_CreateTime,_WriteTime,_LengthMin,_LengthMax,_Content);
		view ();
	}

	void view(){
		string answer = null;
		GameObject files = GameObject.FindGameObjectWithTag ("outputFiles");
		for (int i = 0; i < fileControl.arrAnswerFile.Count; i++) {
			answer = answer + fileControl.arrAnswerFile [i].ToString () + "\n";
		}
		files.GetComponent<Text> ().text = answer;
	}
	void OnDisable(){
		fileControl.closeThread (true);
		Debug.Log ("關");
	}
}

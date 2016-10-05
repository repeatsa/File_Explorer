using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class findFile : MonoBehaviour {
	//private InputField _inputText = null;
	static string g_Path = null;
	static string g_File = null;
	// Use this for initialization
	void Start () {
		//_inputText =((InputField)GameObject.FindGameObjectWithTag ("inputField"));
		g_Path = GameObject.FindGameObjectWithTag("inputFieldpath").GetComponent<InputField>().text;
		g_File = GameObject.FindGameObjectWithTag("inputField").GetComponent<InputField>().text; 
		//g_Path = _inputText.GetComponent<GUIText>().text;
		Debug.Log (g_Path);
		//Debug.Log (g_Path);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

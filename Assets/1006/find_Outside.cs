using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class find_Outside  {

	public string _Path = null;
	public string _File = null;
	public string _ExtensionName = null;
	public string _CreateTime = null;
	public string _WriteTime = null;
	public string _LengthMin = null;
	public string _LengthMax = null;
	public string _Content = null;

	public void findOutside (){
		_Path = GameObject.FindGameObjectWithTag("inputFieldpath").GetComponent<InputField>().text;
		_File = GameObject.FindGameObjectWithTag("inputField").GetComponent<InputField>().text;
		_ExtensionName = GameObject.FindGameObjectWithTag("inputExtension").GetComponent<InputField>().text;
		_CreateTime = GameObject.FindGameObjectWithTag("inputCreateTime").GetComponent<InputField>().text;
		_WriteTime = GameObject.FindGameObjectWithTag("inputWriteTime").GetComponent<InputField>().text;
		_LengthMin = GameObject.FindGameObjectWithTag("inputLengthMin").GetComponent<InputField>().text;
		_LengthMax = GameObject.FindGameObjectWithTag("inputLengthMax").GetComponent<InputField>().text;
		_Content = GameObject.FindGameObjectWithTag("inputContent").GetComponent<InputField>().text;
	}
}

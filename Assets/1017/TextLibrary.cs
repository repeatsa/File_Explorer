using UnityEngine;
using System.Collections;
using System.IO;

public class TextLibrary  {

	public const string SSPACE = " ";
	public const string SPOINT = ".";
	public const float FCAPACITY = 1024.0f;

	//private ArrayList m_sText = new ArrayList();


	/*public void readStringTxt(){
		string _sLine = string.Empty;
		string _sPath = Application.dataPath;
		StreamReader _srStringTxt = new StreamReader(_sPath+ "\\StringLibrary.txt"); 
		while((_sLine = _srStringTxt.ReadLine()) != null)
		{
			m_sText.Add(_sLine);	
		}
		
	}*/

	public enum selectSize
	{
		BYTE = 0,
		KB ,
		MB ,
		GB ,
	}

	public enum selectFileFolder
	{
		None = 0,
		File,
		Folder,
	}

	public enum selectMinMaxType
	{
		None = 0,
		Min,
		Max,
		MinAndMax,
	}
	public enum selectConditionType
	{
		None = 0,
		inputFieldpath,
		inputField,
		inputExtension,
		inputCreateTime,
		inputWriteTime,
		inputLengthMin,
		inputLengthMax,
		inputContent,
	}
}

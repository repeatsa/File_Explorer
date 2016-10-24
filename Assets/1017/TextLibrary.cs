using UnityEngine;
using System.Collections;

public class TextLibrary  {

	public const int IZERO = 0;
	public const int IONE = 1;
	public const int ITWO = 2;
	public const int ITHREE = 3;
	public const string SSPACE = " ";
	public const string SPOINT = ".";
	public const double DCAPACITY = 1024;

	public enum selectCreateWriteType
	{
		Zero = 0,
		Frist = 1,
		Second = 2,
		Third = 3,
	}
	public enum selectSize
	{
		BYTE = 0,
		KB = 1,
		MB = 2,
		GB = 3,
	}
}

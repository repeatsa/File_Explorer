using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class find_View : MonoBehaviour {
	find_Control findControl = new find_Control();
	private Text _text =null;
	void Start () {
		InvokeRepeating ("view",0.0f,1.0f);
		_text = GameObject.FindGameObjectWithTag ("outputFiles").GetComponent<Text> ();
		findControl.findFile ();
	}
	void view(){
		if (false == findControl.threadFiles.IsAlive) {
			string answer = null;
			for (int i = 0; i < find_Control.g_arrAnswerFile.Count; ++i) {
				answer = answer + find_Control.g_arrAnswerFile[i].ToString () + "\n";
			}
			_text.text = answer;
			CancelInvoke ();
		}
	}
}
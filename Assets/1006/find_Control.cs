using UnityEngine;
using System.Collections;
using System.IO;
using System.Threading;

public class find_Control {
	find_Model findModel =new find_Model();
	find_Word findWord = new find_Word();
	find_Outside findOutside = new find_Outside ();
	name_Extension nameExtension = new name_Extension (); 
	create_Write createWrite = new create_Write();
	choose_Length chooseLength = new choose_Length();
	read_files readFiles = new read_files();
	public static ArrayList g_arrAnswerFile = new ArrayList ();
	public Thread threadFiles =null;
	private bool _bVictory = false;


	public void findFile() {
		findOutside.findOutside ();
		threadFiles = new Thread (_readFiles);
		threadFiles.Start ();
		//threadFiles.Join ();
	}

	private void _readFiles(){
		if (Directory.Exists (findOutside._Path)) {
			findModel.fModel (findOutside._Path);
			//int iTotal = findModel.arrFile.Count + findModel.arrFolder.Count;
			for (int iSeat = 0; iSeat < findModel.arrFile.Count; ++iSeat) {
				if (findWord.m_iZero != findOutside._File.Length) {
					nameExtension.addFileAndExtension (findModel.arrFile[iSeat].ToString(),findOutside._File,findWord.m_iZero , ref _bVictory);
					if (true == _bVictory) {
						_bVictory = false;
						continue;
					}
				}
				if (findWord.m_iZero !=  findOutside._ExtensionName.Length) {
					nameExtension.addFileAndExtension (findModel.arrFile[iSeat].ToString(),findOutside._ExtensionName,findWord.m_iZero, ref _bVictory);
					if (true == _bVictory) {
						_bVictory = false;
						continue;
					}
				}
				if (findWord.m_iZero !=  findOutside._CreateTime.Length) {
					FileInfo fFileFo = new FileInfo (findModel.arrFile[iSeat].ToString ());
					createWrite.removeSuffixAndAddArray (findModel.arrFile[iSeat].ToString (),fFileFo.CreationTime.ToString (),findOutside._CreateTime,findWord.m_sSpace,findWord.m_iZero, ref _bVictory);
					if (true == _bVictory) {
						_bVictory = false;
						continue;
					}
				}
				if (findWord.m_iZero !=  findOutside._WriteTime.Length) {
					string sFileFo = Directory.GetLastWriteTime (findModel.arrFile[iSeat]).ToString();
					createWrite.removeSuffixAndAddArray (findModel.arrFile[iSeat].ToString (),sFileFo,findOutside._WriteTime,findWord.m_sSpace,findWord.m_iZero, ref _bVictory);
					if (true == _bVictory) {
						_bVictory = false;
						continue;
					}
				}
				if (findWord.m_iZero !=  findOutside._LengthMin.Length && findWord.m_iZero !=  findOutside._LengthMax.Length) {
					int iType = findWord.m_iOne;
					chooseLength.chooseLength (findModel.arrFile[iSeat].ToString (),iType,findOutside._LengthMin,findOutside._LengthMax , ref _bVictory);
					if (true == _bVictory) {
						_bVictory = false;
						continue;
					}
				} else if (findWord.m_iZero != findOutside._LengthMin.Length) {
					int iType = findWord.m_iTwo;
					chooseLength.chooseLength (findModel.arrFile[iSeat].ToString (),iType,findOutside._LengthMin,findOutside._LengthMax, ref _bVictory);
					if (true == _bVictory) {
						_bVictory = false;
						continue;
					}
				} else if (findWord.m_iZero != findOutside._LengthMax.Length) {
					int iType = findWord.m_iThree;
					chooseLength.chooseLength (findModel.arrFile[iSeat].ToString (),iType,findOutside._LengthMin,findOutside._LengthMax, ref _bVictory);
					if (true == _bVictory) {
						_bVictory = false;
						continue;
					}
				}

				if (findWord.m_iZero != findOutside._Content.Length) {
					
					readFiles.readFiles (findModel.arrFile[iSeat].ToString (),findModel.arrKeys[iSeat],findOutside._Content,ref _bVictory);
					if (true == _bVictory) {
						_bVictory = false;
						continue;
					}
				}

				if (findWord.m_iZero == findOutside._File.Length && findWord.m_iZero ==  findOutside._ExtensionName.Length && findWord.m_iZero ==  findOutside._CreateTime.Length && findWord.m_iZero ==  findOutside._WriteTime.Length && findWord.m_iZero ==  findOutside._LengthMin.Length && findWord.m_iZero ==  findOutside._LengthMax.Length && findWord.m_iZero == findOutside._Content.Length) {
					g_arrAnswerFile.Add (findModel.arrFile[iSeat]);
				}

			}
		}
		threadFiles.Abort ();
	}
}
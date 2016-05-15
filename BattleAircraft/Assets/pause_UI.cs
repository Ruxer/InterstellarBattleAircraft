using UnityEngine;
using System.Collections;

public class pause_UI : MonoBehaviour {







	public void pauseClick(){

		print ("游戏将要暂停");

		Time.timeScale = 0;

	}



}

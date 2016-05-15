using UnityEngine;
using System.Collections;

public class BGMManager : MonoBehaviour {



	//或取相机对象上的声音源组件。
	AudioSource _audio;


	void Start () {

		_audio = gameObject.GetComponent<AudioSource> ();


	}



	void Update () {
	


		if (!_audio.isPlaying) {
			
			_audio.clip = Resources.Load ("背景音乐_02") as AudioClip;

			_audio.Play (10);

		}
	}  



}

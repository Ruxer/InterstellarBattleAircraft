using UnityEngine;
using System.Collections;

public class prop : MonoBehaviour {



	protected GameObject doubu;


	void Start () {
	
		doubu = Resources.Load ("douBullet") as GameObject;


	}




	void Update () {
	




	}


	void propMess(GameObject gameObject){


	//Instantiate (doubu, gameObject.transform.position, gameObject.transform.rotation);



	}


}

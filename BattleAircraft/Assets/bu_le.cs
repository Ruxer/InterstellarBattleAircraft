using UnityEngine;
using System.Collections;

public class bu_le : MonoBehaviour {


	protected Transform m_transform;



	void Start () {
	


		m_transform = this.transform;


	}



	void Update () {
	
		float k = 1.2f;
		m_transform.Translate (k * Time.deltaTime, 1.5f * k * Time.deltaTime, 0);





	}
}

using UnityEngine;
using System.Collections;

public class douBu : MonoBehaviour {

	//当前对象的transform。
	protected Transform m_transform;

	//两个子对象
	protected GameObject bullet_left;
	protected GameObject bullet_right;


	void Start () {
	
		m_transform = this.transform;

		bullet_left = m_transform.GetChild (0).gameObject ;
		bullet_right = m_transform.GetChild (1).gameObject;


	}
	
	void Update () {
	

		Instantiate (bullet_left, m_transform.position, m_transform.rotation);


		Instantiate (bullet_right, m_transform.position, m_transform.rotation);

	}
}

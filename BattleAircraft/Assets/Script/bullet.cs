using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {


	//子弹速度
	public float m_speed = 0.02f;


	//子弹初始化的位置坐标
	protected Transform m_transform;

	void Start () {
	
		m_transform = this.transform;


	}
	
	void Update () {



		if (m_transform.position.y >= 6.45f) {

			Destroy (this.gameObject);

		}
			m_transform.Translate (Vector3.up * m_speed);

	}

	void OnTriggerEnter2D(Collider2D other){

		Destroy (this.gameObject);

	}


}

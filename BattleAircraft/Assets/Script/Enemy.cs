using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {


	protected Transform m_transform;


	//移动速度
	public float m_speed = 0.05f;


	//旋转速度
	public float m_rotSpeed = 50;

	//变向间隔时间
	protected float m_time = 1.5f;

	//生命值
	//[HideInInspector ]
	public float m_life = 10;

	//Text UI元素
	Text text;


	void Start () {
	
		m_transform = this.transform;

		float a = Random.value;

		text = GameObject.Find ("Canvas/分数").GetComponent<Text>();


	}



	void Update () {
	
		if (m_transform.position.y < -6.74f) {

			Destroy (this.gameObject);
		}


		UpdateM();

	
	}



	//控制敌机的移动轨迹

	protected void UpdateM(){


		m_time -= Time.deltaTime;

		if(m_time <= 0){


			m_time = 3;

			//改变旋转方向
			m_rotSpeed = -m_rotSpeed;


		}


		//前进
		m_transform.Translate (Vector3.down * m_speed );


		//旋转
		m_transform.Rotate (Vector3.forward ,m_rotSpeed * Time.deltaTime  );


	}




	//得分
	static float grade;



	//碰撞检测

	void OnTriggerEnter2D(Collider2D collisionInfo){

		//碰撞一次生命值-1
		m_life--;

		//生命值为0时
		if (m_life == 0) {

			//销毁当前对象（敌机）
			Destroy (this.gameObject);

			//分数+70
			grade += 70;

			//在UI层显示得分
			text.text = grade.ToString ();//格式转换

		}

	}


	void sendM(){

		Destroy (this.gameObject);


	}







}

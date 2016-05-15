using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class warplane_control : MonoBehaviour {


	//默认对象移动速度
	public float m_speed = 0.03f;

	protected Transform m_transform;

	//子弹对象
	GameObject bullet;

	//生命条对象
	Slider slider;

	//战机生命值
	//static	float m_life = 100;


	// Transform MainTrasfrom;

	Vector2 v;

	//子弹发射持续时间
	public float s_time = 0.05f;
	//子弹发射停顿时间
	float tmp = 0;


	float b_time = 3;

	//限制战机移动
	protected float limitMove_left = -3.46f;
	protected float limitMove_right = 3.5f;
	protected float limitMove_top = 5.52f;
	protected float limitMove_bottom = -5.52f;



	void Start () {
	
		m_transform = this.transform;

		bullet =  Resources.Load ("bullet_main",typeof(GameObject)) as GameObject;

		slider = GameObject.Find ("Canvas/Slider").GetComponent<Slider> ();

		//MainTrasfrom = this.transform.parent;//先设置父级的位置



	}


	void Update () {
	


		if (slider.value == 0) {

			Destroy (this.gameObject);

			//Application.LoadLevel (0);

			SceneManager.LoadScene (0);

		}


		//上移
		if (Input.GetKey (KeyCode.W) && m_transform.position.y < 5.52f) {
		
			m_transform.Translate (Vector3.up * m_speed);
		
		}
		//下移
		if (Input.GetKey (KeyCode.S) && m_transform.position.y > -5.52f) {

			m_transform.Translate (Vector3.down * m_speed);

		}
		//左移
		if (Input.GetKey (KeyCode.A) && m_transform.position.x > -3.46f) {

			m_transform.Translate (Vector3.left * m_speed);


		}
		//右移
		if (Input.GetKey (KeyCode.D) && m_transform.position.x < 3.5f) {

			m_transform.Translate (Vector3.right * m_speed);


		}

		//子弹发射持续时间减少
		s_time -= Time.deltaTime;


		if (s_time > 0) {
			
			shooter ();
		

		} else {

			tmp += Time.deltaTime;

			if (tmp >= 0.2f) {

				s_time = 0.5f;
				tmp = 0;
			}
		}
//			g.transform.parent = MainTrasfrom ;//设置实例化对象的父级
//			g.transform.localScale = Vector3.one;//设置缩放比例1,1,1

		TouchMove ();


	}

	void shooter(){



		v = m_transform.position;

		v.y += 0.7f;


		b_time--;

		if (b_time ==2 || b_time == -1) {

			GameObject g = (GameObject)Instantiate (bullet, v, m_transform.rotation);
	
		} 

		if(b_time == -1){

			b_time = 3;
		}





	}


	void shooterP(){






	}



	//touch Devices
	void TouchMove(){

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {

			Vector2 p = Input.GetTouch(0).deltaPosition;

			m_transform.Translate(p.x * m_speed, p.y * m_speed, 0);

		

		}



	}



	void OnTriggerEnter2D(Collider2D other){


		if (other.tag.Equals ("Enemy_01") || other.tag.Equals ("Enemy_03")) {




			//Debug.Log ("敌机01碰撞上了战机");

			other.SendMessage ("sendM");



			slider.value -= 10;



		}

		if (other.tag.Equals ("boss_01") || other.tag.Equals ("boss_02") || other.tag.Equals ("boss_03") ) {

			//Debug.Log ("战机碰撞上了boss机");


			slider.value -= 25;

		//	m_transform.gameObject.SendMessage ("propMess",m_transform.gameObject);


		}

		if(other.tag.Equals("bullet_boss")){


			slider.value -= 20;


		}




	}

	void OnTriggerStay2D(Collider2D other){


		if (other.tag.Equals ("bullet_boss")) {

			slider.value -= 25;

		}

	}





}

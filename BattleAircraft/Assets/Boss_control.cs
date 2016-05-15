using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Boss_control : MonoBehaviour {


	//声明位置变量
	protected Transform m_transform;

	//boss机移动速度
	float m_speed = 0.03f;

	//判断左右
	bool isleft = true;

	//定义子弹发射的间断时间
	float s_time = 2.5f;

	//子弹对象
	public Transform bossBullet;

//	//位置信息
	Vector3	position;
	Vector3 positionLeft;
	Vector3 positionRight;


	//boss1生命值
	protected float bossLife = 1000f;




	void Start () {
	
	

		//获取boss机位置信息
		m_transform = this.transform;


	}



	void Update () {
	

		if (bossLife == 0) {
			
			//Application.LoadLevel (0);

			SceneManager.LoadScene (0);

			Destroy (this.gameObject);


		
		}


		if (m_transform.position.y > 2.85f) {
			//向下运动
			Boss_MoveDown ();

		} else {



			//发射子弹
			BossShooter();

			//左右运动
			Boss_MoveleftRight ();
		}


	}

	/**
		boss机向前运动一段时间后左右运动
	*/

	//boss机向前移动范围（7.68f,2.85f）
	void Boss_MoveDown(){

		m_transform.Translate (Vector3.down * m_speed);

	}

	//boss机左右移动的范围（-1.41f,1.39f)

	void Boss_MoveleftRight(){

		IsTrue ();
		
		if (isleft) {
			
			m_transform.Translate (Vector3.left * (m_speed - 0.015f));

		} else {

			m_transform.Translate (Vector3.right * (m_speed - 0.015f));

		}
	                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
	
		}

	//判断是要向左运动还是向右运动
	void IsTrue(){

		if (m_transform.position.x <= -1.41f) {

			isleft = false;
		}else if(m_transform.position.x >= 1.39f){


			isleft = true;

		}


	}



	//子弹发射方法
	void BossShooter(){

		//子弹发射位置

		//左(-1.26f, 2.1f)
		//右(1.26f,2.1f)

		 position = this.transform.position;

		 positionLeft = new Vector3(position.x - 1.26f,position.y - 0.7f);
		 positionRight = new Vector3(position.x + 1.26f,position.y - 0.7f);

		s_time -= Time.deltaTime;

		if (s_time <= 0) {

			Instantiate (bossBullet,positionLeft,m_transform.rotation);

			Instantiate (bossBullet,positionRight,m_transform.rotation);

			s_time = 1.2f;
		}


	}



	//子弹碰撞检测

	void OnTriggerEnter2D(Collider2D other){



		bossLife -= 10;




	}






}

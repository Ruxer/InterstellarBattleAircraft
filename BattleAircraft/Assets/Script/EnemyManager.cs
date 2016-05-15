using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {



	private  GameObject enemy;

	private GameObject boss01;

	//private Vector3 _transform;


	//敌机出现间隔
	public float e_time = 5;

	/*
		确定敌机出现的时机
		敌机种类:
		1:按照特定路线运动
		2:特殊类敌机,冲向战机,自杀式敌机。
		3:发射子弹类敌机:1）固定发射 2）移动发射

	*/

	//种类1出现时间
	protected float time_e1 = 2f;

	//种类2出现时间
	protected float time_e2;

	//种类3出现时间
	protected float time_e3;


	//敌机出现的位置

	//敌机种类1出现的位置

	//左上角(-4.37,6.6)
	//右上角(4.39,6.56)

	//Vector3 position_topLeft = new Vector3(-4.37f,6.6f);

	Vector3 position_topLeft = new Vector3(-3.84f,7.55f);

	//Vector3 position_topRight = new Vector3(4.39f,6.56f);

	Vector3 position_topRight = new Vector3(2.1f,17.15f);

	//敌机第一梯度持续时间
	float grads_01 = 5f;

	//敌机第二梯度持续时间
	float grads_02 = 10f;

	//相邻敌机出现间隙
	float timeGap = 1f;


	//boss1出现的时间
	float time_boss01 = 18f;

	//boss1出现的位置
	Vector3 position_boss1 = new Vector3(-0.04f,7.68f);

	void Start () {
	

		 enemy = Resources.Load ("Enemy") as GameObject;

		boss01 = Resources.Load ("boss1") as GameObject;

	}
	

	void Update () {
	

	//	Instantiate (enemy, position_topLeft, enemy.transform.rotation);

		grads_01 -= Time.deltaTime;
		grads_02 -= Time.deltaTime;

		time_boss01 -= Time.deltaTime;
		if(time_boss01 <= 0){

			time_boss01 = 999999f;

			Instantiate (boss01,position_boss1,boss01.transform.rotation);


		}

		if (grads_01 >= 0) {

			timeGap -= Time.deltaTime;

			if (timeGap <= 0) {

				Instantiate (enemy, position_topLeft, enemy.transform.rotation);

				timeGap = 0.8f;
			}

		} else if(grads_02 >= 0){


			timeGap -= Time.deltaTime;

			if (timeGap <= 0) {

				Instantiate (enemy, position_topRight, enemy.transform.rotation);

				timeGap = 0.8f;
			}


		}

	}


	//间隔的创建敌机对象
	void createEnemy(float time){


		time -= Time.deltaTime;

		if (time <= 0) {

			Instantiate (enemy, position_topLeft, enemy.transform.rotation);

		}


	}


}



	//-2.44  -0.81  -0.79  

//	Vector3 positionR(){
//
//
//		float f = Random.Range (-2.8f,3.2f);
//
//		f += 0.7f;
//
//		Vector3 v = new Vector3 (f, 6.14f);
//
//		return v;
//
//	}


//}

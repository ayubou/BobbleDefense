using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

	public GameObject[] Train;


	// Use this for initialization
	void Start () {
		CreateEnemie ();
		//Vector2 tmp = Train[0].transform.position;
		//var sh = Train[0].GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {

		//if (transform.position.y > 4.0f) {
		//CreateEnemie ();
		//}
		//var test = transform.position.y;
		//Debug.Log (test);
	}




	void CreateEnemie(){

		//初期の配置座標を設定
		Vector2 placePosition = new Vector2(-2.05f,4.0f);

		//回転角度の設定
		Quaternion q = new Quaternion();
		q= Quaternion.identity;

		//配置
		for (int i = 0; i < 5; i++){

			//ランダム表示
			int rand = Random.Range (0, Train.Length);
			Instantiate(Train[rand], placePosition, q);

			//横幅の取得
			var sr = Train[rand].GetComponent<SpriteRenderer>();
			placePosition.x += sr.bounds.size.x + 0.15f;

		}
	}
}

using UnityEngine;
using UnityEngine.UI;
using MarchingBytes;

public class MoveGameObject : MonoBehaviour {

    public Vector3 moveVector;
    public float speed;

	float proSp;

	private GameOver gOver; // получаем знаечиню закончилас ли игра или нет
    public SpeedGame moveSpeed;

	void Start () {
        moveSpeed = GameObject.Find("Canvas").GetComponent<SpeedGame>();      
		gOver = GameObject.Find("Ground").GetComponent<GameOver>();
	}
	

	void Update () {
        
        if(!gOver.gameOver)
            speed = moveSpeed.speed;
		if(gOver.gameOver) {
			if(speed == proSp) // если игра закончилас то проверяем текуший скорсоть если они равны то сразу делим на два
				speed = speed / 2;

			if (speed != 0)
				speed = speed - 0.5f;
		}

		transform.Translate (moveVector * Time.deltaTime * speed);


		if (transform.position.z < -45)
            EasyObjectPool.instance.ReturnObjectToPool(gameObject);

	}



}

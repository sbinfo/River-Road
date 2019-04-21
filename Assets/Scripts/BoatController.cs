using UnityEngine;

public class BoatController : MonoBehaviour {

    public Transform target; // Позиция таргета
    public Vector3 moveLeftVector;  
    public Vector3 moveRightVector;
    public float speed;
    bool isLeft;
    bool isRight;

	void Update () {

        Vector3 moveVector = new Vector3(target.position.x, transform.position.y, transform.position.z);           

        if(isLeft || Input.GetKey("left"))
        {
            if (target.position.x > -7f)
            {
                target.Translate(moveLeftVector * Time.deltaTime * speed);
            }
        }

        if(isRight || Input.GetKey("right"))
        {
            if (target.position.x < 6.23f)
            {
                target.Translate(moveRightVector * Time.deltaTime * speed);
            }
        }

        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, moveVector, Time.deltaTime * (speed - 4.0f));

	}

    public void TurnLeft(bool isOn)
    {
        isLeft = isOn;
    }

    public void TurnRight(bool isOn)
    {
        isRight = isOn;
    }
}

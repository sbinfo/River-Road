using UnityEngine;

public class RotateFish : MonoBehaviour
{

    public float speed;

	void FixedUpdate () {
        transform.Rotate(Vector3.up * Time.fixedDeltaTime * speed);
	}
}

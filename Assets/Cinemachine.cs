
using UnityEngine;

public class Cinemachine : MonoBehaviour
{

	public Transform target;

	public float smoothSpeed = 0.125f;

	public float yPosition;
	public float offset;

	void FixedUpdate()
	{
		yPosition = target.position.y;

		transform.position = new Vector3 (transform.position.x, yPosition, transform.position.z);
	}

}

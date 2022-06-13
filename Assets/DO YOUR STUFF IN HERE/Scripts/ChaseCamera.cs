using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
	public Transform target;

	public float smoothSpeed = 0.125f;
    public float rotationSpeed = 5f;
	public Vector3 offset;

    Vector3 cameraRotationOffset;

    void Awake()
    {
        cameraRotationOffset = transform.localEulerAngles;
    }

	void FixedUpdate ()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.eulerAngles + cameraRotationOffset), Time.deltaTime * rotationSpeed);
		

		//transform.LookAt(target);
	}
}
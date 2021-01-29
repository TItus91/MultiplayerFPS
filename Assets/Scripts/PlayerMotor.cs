using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
	private Vector3 velocity = Vector3.zero;
	private Vector3 xRotation = Vector3.zero;
	private Vector3 cameraRotation = Vector3.zero;

	[SerializeField]
	private Camera cam;

	private Rigidbody rb;


	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	//działa z każdą iteracją fizyki
	private void FixedUpdate()
	{
		PerformMovement();
		PerformRotation();
	}


	public void Move(Vector3 _velocity)
	{
		velocity = _velocity;
	}

	public void Rotate(Vector3 _rotation)
	{
		xRotation = _rotation;
	}

	public void RotateCamera(Vector3 _cameraRotation)
	{
		cameraRotation = _cameraRotation;
	}

	void PerformMovement()
	{
		if (velocity != Vector3.zero)
		{
			rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
		}
	}

	void PerformRotation()
	{
		if (xRotation != Vector3.zero)
		{
			rb.MoveRotation(rb.rotation * Quaternion.Euler(xRotation));
		}

		if (cam != null)
		{
			cam.transform.Rotate(-cameraRotation);
		}
	}

	


}

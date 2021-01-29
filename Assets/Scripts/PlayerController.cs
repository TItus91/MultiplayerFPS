using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float mouseSensitivity = 3f;

	private PlayerMotor motor;
	private Camera cam;

	private void Start()
	{
		motor = GetComponent<PlayerMotor>();
	}

	private void Update()
	{
		// ruch przód-tył i prawo-lewo
		float _xMovement = Input.GetAxisRaw("Horizontal");
		float _zMovement = Input.GetAxisRaw("Vertical");

		Vector3 _moveHorizontal = transform.right * _xMovement;    // Vector3.right odnosi się do globalnych współrzędnych, transform.right do lokalnych współrzędnych naszego grzacza. Uwzlędnia już rotację.
		Vector3 _moveVertical = transform.forward * _zMovement;

		Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed; // normalized znaczy, że suma vectorów zawsze wynosi 1, czyli nie przyspieszymy bardziej idąc w dwóch kierunkach na raz.

		motor.Move(_velocity);

		// rotacja wokół Y dla całego Playera, wokół X dla samej kamery
		float _yRotation = Input.GetAxisRaw("Mouse X");

		Vector3 _rotation = new Vector3(0f, _yRotation, 0f) * mouseSensitivity;
		motor.Rotate(_rotation);

		float _xRotation = Input.GetAxisRaw("Mouse Y");

		Vector3 _cameraRotation = new Vector3(_xRotation, 0f, 0f) * mouseSensitivity;
		motor.RotateCamera(_cameraRotation);
	}

}
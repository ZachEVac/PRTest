using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
	float rotationX;
	float mouseSensitivity = 350f;
	public Transform player;

	void Start()
    {
		//Hides and locks cursor
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
    }

	void Update()
    {
		//Mouse input
		float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
		float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;

		//Moves Camera up and down
		rotationX -= mouseY;
		rotationX = Mathf.Clamp(rotationX, -90f, 90f);
		transform.localEulerAngles = new Vector3(rotationX, 0f, 0f);

		//Rotates left and right
		player.Rotate(Vector3.up * mouseX);
    }

	//Video link: https://www.youtube.com/watch?v=W_wqA2a4iK0
}

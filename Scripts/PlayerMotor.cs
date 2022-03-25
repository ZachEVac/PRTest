using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
	private CharacterController controller;
	private Vector3 playerVelocity;
	private bool isGrounded;
	public float gravity = -9.8f;
	public float jumpHeight = 2.5f;
	public float speed = 8f;
	
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }
	//recieve the inputs for out InputManager.cs and apply them to our character controller.
	public void ProcessMove(Vector2 input)
	{
		Vector3 moveDirection = Vector3.zero;
		moveDirection.x = input.x;
		moveDirection.z = input.y;
		controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
		playerVelocity.y += gravity * Time.deltaTime;
		if (isGrounded && playerVelocity.y < 0)
			playerVelocity.y = -8f;
		controller.Move(playerVelocity * Time.deltaTime);
		Debug.Log(playerVelocity.y);
	}
	public void Kangaroo()
	{
		if (isGrounded)
		{
			playerVelocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PR1
{

    public class PlayerMovement : MonoBehaviour
    {
        //Variables
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private float jumpSpeed = 0.2f;
        [SerializeField] private float gravity = 2f;

        //Controls smooth movement, higher number = more floaty
        private float smoothInputSpeed = 0.05f;

        //References
        CharacterController characterController;
        Vector3 moveDirection;
        Vector3 flatSmooth;
        private Vector3 smoothInputVelocity;

        void Awake() => characterController = GetComponent<CharacterController>();

        //Fixed Update locks it to current FPS
        void FixedUpdate()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 inputDirection = new Vector3(horizontal, 0, vertical);
            Vector3 transformDirection = transform.TransformDirection(inputDirection);

            //flatMovement is put through SmoothDamp, which gives player smoother movement and prevents instantly switching directions
            Vector3 flatMovement = moveSpeed * Time.deltaTime * transformDirection;
            flatSmooth = Vector3.SmoothDamp(flatSmooth, flatMovement, ref smoothInputVelocity, smoothInputSpeed);

            //Final line for movement, using flatSmooth from Smoothdamp line
            moveDirection = new Vector3(flatSmooth.x, moveDirection.y, flatSmooth.z);

            //Jumping
            if (PlayerJumped)
                moveDirection.y = jumpSpeed;

            else if (characterController.isGrounded)
                moveDirection.y = 0f;

            else
                moveDirection.y -= gravity * Time.deltaTime;

            characterController.Move(moveDirection);
        }

        private bool PlayerJumped => characterController.isGrounded && Input.GetKey(KeyCode.Space);
    }

    //Video links: https://www.youtube.com/watch?v=krA-B8yItc0&t=370s
    //             https://www.youtube.com/watch?v=fyV77lN1Yl0&t=1972s
}

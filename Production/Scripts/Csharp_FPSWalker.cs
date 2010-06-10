using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class Csharp_FPSWalker : MonoBehaviour {

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private bool isGrounded = false;
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        //Gravity
        moveDirection.y -= gravity * Time.deltaTime;

        //Move the controller
        CharacterController controller = GetComponent<CharacterController>();
        CollisionFlags flags = controller.Move(moveDirection * Time.deltaTime);
        isGrounded = (flags & CollisionFlags.CollidedBelow) != 0;
	    
	}
}

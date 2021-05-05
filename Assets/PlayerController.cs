using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float force;
    public float jumpForce;
    Vector3 direction3D = Vector3.zero;
    public float horizontalDrag;

    public bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        InputManager.MovementEvent += Move;
        InputManager.JumpEvent += Jump;
    }

    // Update is called once per frame
    void Update()
    {

        if(direction3D != Vector3.zero)
        {
            rb.AddForce(direction3D * Time.deltaTime * force, ForceMode.Force);
        }

        rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(0, rb.velocity.y, 0), horizontalDrag*Time.deltaTime);
        
    }

    void Move(Vector2 direction)
    {

        direction3D = new Vector3(direction.x, 0, direction.y);
        
    }

    public void Jump()
    {
        Jump(true);
    }

    void Jump(bool value)
    {
        if (!value)
        {
            return;
        }

        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

}

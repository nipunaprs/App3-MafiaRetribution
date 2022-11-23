using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifiedPlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float runSpeed;
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public float groundDrag;
    public Transform isGroundedObject;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;

    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public KeyCode jumpKey = KeyCode.Space;

    //Animations
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Ground check
        grounded = Physics.Raycast(isGroundedObject.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");


        

        //jumping
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }


        SpeedControl();


        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
        HandleAnimations();
    }

    private void MovePlayer()
    {
        //calc movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(grounded && animator.GetBool("run"))
            rb.AddForce(moveDirection.normalized * runSpeed * 10f,ForceMode.Force);
        else if (grounded && animator.GetBool("walk"))
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

    }

    private void HandleAnimations()
    {

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(jumpKey))
        {
            //Run straight
            animator.SetBool("run", false);
            animator.SetBool("jump", false);
            animator.SetBool("walk", false);

        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(jumpKey))
        {
            animator.SetBool("run", true);
            animator.SetBool("jump", false);
            animator.SetBool("walk", false);
        }
        else if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(jumpKey))
        {
            animator.SetBool("run", false);
            animator.SetBool("jump", false);
            animator.SetBool("walk", true);
        }
        else if (Input.GetKey(jumpKey))
        {
            animator.SetBool("run", false);
            animator.SetBool("jump", true);
            animator.SetBool("walk", false);
        }


    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed && animator.GetBool("walk"))
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
        else if(flatVel.magnitude > moveSpeed && animator.GetBool("run"))
        {
            Vector3 limitedVel = flatVel.normalized * runSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }



    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
        animator.SetBool("jump", false);
    }
}

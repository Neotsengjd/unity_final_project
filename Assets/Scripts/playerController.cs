using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float runSpeed = 8f; // How fast player run, 8f is good
    public float walkSpeed = 2f;
    bool running;


    Rigidbody rb; // myRB in the video
    Animator anim; // myAnim in the video
    bool facingRight;

    //for jumping
    bool grounded = false;
    Collider[] groundCollisions;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        running = false;

        if(grounded && Input.GetAxis("Jump") > 0){
            grounded = false;
            anim.SetBool("grounded", grounded);
            rb.velocity = new Vector3(rb.velocity.x, 0, 0);
            rb.AddForce(new Vector3(0, jumpHeight, 0));
        }


        groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if(groundCollisions.Length > 0)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        anim.SetBool("grounded", grounded);

        //jump
        anim.SetFloat("verticalSpeed", rb.velocity.y);
        

        float move =  Input.GetAxis("Horizontal"); // Get horizontal input, using input Manager
        float sneaking = Input.GetAxisRaw("Fire3"); // Get Shift(Fire3) bottom
        
        anim.SetFloat("speed", Mathf.Abs(move));
        anim.SetFloat("sneaking", sneaking);

        float firing = Input.GetAxis("Fire1");
        anim.SetFloat("shooting", firing);

        if ((sneaking > 0 || firing > 0) && grounded)
        {
            
            rb.velocity = new Vector3(move * walkSpeed, rb.velocity.y, 0);
        }
        else
        {
            rb.velocity = new Vector3(move * runSpeed, rb.velocity.y, 0);
            if (Mathf.Abs(move) > 0)
                running = true;
        }

        if (move > 0 && !facingRight) Flip(); // Facing left but move right
        else if(move < 0 && facingRight) Flip(); // Facing right but move left
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scale = transform.localScale;
        Scale.z *= -1;
        transform.localScale = Scale;   
    }

    public float GetFacing()
    {
        if (facingRight) return 1;
        else return -1;
    }

    public bool getRunning()
    {
        return (running);
    }

}

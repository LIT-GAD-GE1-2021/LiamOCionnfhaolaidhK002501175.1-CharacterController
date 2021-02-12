using System.Collections;

using UnityEngine;

public class AdventurerScript : MonoBehaviour
{
    
    public float jumpSpeed;
    public float horizontalSpeed = 10;
    public LayerMask whatIsGround;
    public Transform groundcheck;
    private bool grounded;
    private bool jump;

    bool facingRight = true;
    private float hAxis;
    private Rigidbody2D theRigidBody;
    private Animator theAnimator;

    private float groundRadius = 0.5f;
    public float fallMultiplier = 5.0f;
    public float lowJumpMultiplier = 3.0f;

    public bool attackCheck = false;


    // Start is called before the first frame update
    void Start()
    {
        
        jump = false;
        grounded = false;

        // Get the components we need
        theRigidBody = GetComponent<Rigidbody2D>();
        theAnimator = GetComponent<Animator>();
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {
            theAnimator.SetFloat("AttackFloat", 1);

            attackCheck = true;

            Debug.Log("Hello");

        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            theAnimator.SetFloat("AttackFloat", 0);

            attackCheck = false;

            Debug.Log("Bye");

        }




        if (attackCheck == false)
        {
          float xVelocity = theRigidBody.velocity.x;
          float yVelocity = theRigidBody.velocity.y;


           jump = Input.GetKeyDown(KeyCode.Space);
           theAnimator.SetFloat("vspeed", xVelocity);

           theAnimator.SetFloat("vspeed", Mathf.Abs(hAxis));

           hAxis = Input.GetAxis("Horizontal");

           theAnimator.SetFloat("hspeed", yVelocity);

           theAnimator.SetFloat("hspeed", Mathf.Abs(hAxis));

        }

        else if (attackCheck == true)
        {
            float xVelocity = 0;
            float yVelocity = 0;


        }



       



        Collider2D colliderWeCollidedWith = Physics2D.OverlapCircle(groundcheck.position, groundRadius, whatIsGround);

        grounded = (bool)colliderWeCollidedWith;

        theAnimator.SetBool("ground", grounded);


        if (grounded)
        {
            if ((hAxis > 0) && (facingRight == false))
            {
                Flip();
            }
            else if ((hAxis < 0) && (facingRight == true))
            {
                Flip();
            }
        }
    }

    void FixedUpdate()
    {

       if (grounded && jump)
        {

            theRigidBody.velocity = new Vector2(theRigidBody.velocity.x, jumpSpeed);
        }

        if (theRigidBody.velocity.y < 0)
        {
           
            theRigidBody.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;

        }
        else if ((theRigidBody.velocity.y > 0) && (!Input.GetKey(KeyCode.Space)))
        {
           
            theRigidBody.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
        }

        if (grounded && !jump)
        {
            theRigidBody.velocity = new Vector2(horizontalSpeed * hAxis, theRigidBody.velocity.y);
        }

    }

    private void Flip()
    {
        
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;

        //flip the x axis
        theScale.x *= -1;

        //apply it back to the local scale
        transform.localScale = theScale;
    }


}

using System.Collections;
using System.Collections.Generic;
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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

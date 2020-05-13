using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour

{

    public float moveSpeed;
    private float moveSpeedStore;

    public float jumpForce;

    public float jumpTime;

    private float jumpTimeCounter;

    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;


    private Rigidbody2D myRigidBody;

    public bool grounded;
    public LayerMask whatIsGround;

   

    private Animator myAnimator;

    public Transform groundCheck;

    public float groundCheckRadius;

    public GameManager gameManager;

    
    private bool stoppedJumping;

    
    private bool canDoubleJump;


    
    public AudioSource jumpSound;

    public AudioSource deathSound;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        
        myAnimator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;

        speedMilestoneCount = speedIncreaseMilestone;

        
        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;

        stoppedJumping = true;
        canDoubleJump = true;
    }

    // Update is called once per frame
    void Update()
    {



        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

       
        if (transform.position.x > speedMilestoneCount) {

            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;

        }


        
        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

        // if space bar or left mouse button is pressed then jump
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {


            // only allow jumping if grounded is true
            if (grounded)
            {
                
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                stoppedJumping = false;
                
                jumpSound.Play();
            }

            //if the player is not grounded and canDoubleJump is true
            if (!grounded && canDoubleJump) {
                
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);

                
                jumpTimeCounter = jumpTime;

                
                stoppedJumping = false;

                
                canDoubleJump = false;

                
                jumpSound.Play();


            }

        }
        // if the jump key is held down then allow to add more jumpForce to the rigid body
       
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping) {
            if (jumpTimeCounter > 0) {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }



        }
        // if the jump key is let go then reset the jumpTimeCounter to 0 so that no further jumpforce can be added
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) {

            jumpTimeCounter = 0;
            stoppedJumping = true;

        }
        // when the player is grounded then reset the jumpTimeCounter back to jumpTime so that the new jump can be done again
        if (grounded) {

            jumpTimeCounter = jumpTime;
            canDoubleJump = true;

        }


       




        myAnimator.SetFloat("Speed", myRigidBody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
    }

    // triggered when one object with a box collider touches another object with a box collider
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "killbox") {


            deathSound.Play();
            gameManager.restartGame();

            // reset moveSpeed, speedMilestoneCount speedIncreaseMilestone back to original values
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private Rigidbody2D myRigidBody;
    private Animator myAnimator;

	[SerializeField]
	private float movementSpeed;

    private bool attack;

	private bool slide;

    private bool facingRight;

	[SerializeField]
	private Transform[] groundPoints;

	[SerializeField]
	private float groundRadius;

	[SerializeField]
	private LayerMask whatIsGround;

	private bool isGrounded;

	private bool jump;

	[SerializeField]
	private bool airControl;

	[SerializeField]
	private float jumpForce;

	// Use this for initialization
	void Start () {
        facingRight = true;
		myRigidBody = GetComponent<Rigidbody2D> ();
        myAnimator = GetComponent<Animator>();
	}
	
    void Update()
    {
        HandleInput();
    }

	// Update is called once per frame
	void FixedUpdate() {
		float horizontal = Input.GetAxis("Horizontal");

		isGrounded = IsGrounded ();

		handleMovement (horizontal);

        HandleAttacks();

		HandleAttacks ();

        Flip(horizontal);

		ResetValues ();
	}
	private void handleMovement (float horizontal){
		if (!myAnimator.GetBool ("slide") && !this.myAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("attack") && (isGrounded || airControl)) {
			myRigidBody.velocity = new Vector2 (horizontal * movementSpeed, myRigidBody.velocity.y);
		}
		if (isGrounded && jump) {
			isGrounded = false;
			myRigidBody.AddForce (new Vector2 (0, jumpForce));
			myAnimator.SetTrigger ("Jump");
		}
		if (slide && !this.myAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Slide")) {
			myAnimator.SetBool ("slide", true);
		} else if (!this.myAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Slide")) {
			myAnimator.SetBool ("slide", false);
		}
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));

		}
    private void HandleAttacks()
    {
		if (attack && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
        {
            myAnimator.SetTrigger("attack");
			myRigidBody.velocity = Vector2.zero;
        }
    }

    private void HandleInput()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			jump = true;

		}
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            attack = true;
        }
		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			slide = true;
		}
    }

    private void Flip(float horizontal)
    {
    if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }


    }
	private void ResetValues () {
		attack = false;
		slide = false;
		jump = false;
	}
	private bool IsGrounded(){
		if (myRigidBody.velocity.y <= 0){
			foreach (Transform point in groundPoints) {
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);

				for (int i = 0; i < colliders.Length; i++) {
					if (colliders [i].gameObject != gameObject) {
						return true;
					}
				}
			}

	}
		return false;
	}
	private void HandleLayersP(){
		if (!isGrounded) {
			myAnimator.SetLayerWeight (1, 1);
		} 
		else {
			myAnimator.SetLayerWeight (1, 0);
		}
	}

}

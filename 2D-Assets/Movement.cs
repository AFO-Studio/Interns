using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Animator anim;
    public CharacterController cc;

    private bool facingRight;

    void Awake()
    {
        this.cc = (CharacterController)GetComponent(typeof(CharacterController));
        anim = GetComponent<Animator>();
    }

    private void Flip(float horizontal)
    {
        if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        anim.SetFloat("Forward", x);
    }
}
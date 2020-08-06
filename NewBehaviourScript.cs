using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D     playerRB;
    private Animator        playerAnimator;

    public float            speedPlayer;
    public float            jumpForce;

    public bool             isLookRight;

    public Transform        groundCheck;
    private bool            isGrounded;

    void Start()
    {

        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

    }

    
    void Update()
    {

        float h = Input.GetAxisRaw("Horizontal");

        if(h >0 && !isLookRight) 
        {
            Flip();
        }
        else if(h<0 && isLookRight) 
        {
            Flip();
        }

        float speedY = playerRB.velocity.y;

        if (Input.GetButtonDown("Jump") && isGrounded == true) 
        {
            playerRB.AddForce(new Vector2(0, jumpForce));
        }

        playerRB.velocity = new Vector2(h * speedPlayer, speedY);

        playerAnimator.SetInteger("h", (int) h);
        playerAnimator.SetBool("isGrounded", isGrounded);
        playerAnimator.SetFloat("speedY", speedY);

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f);
    }
    void Flip()
    {
        isLookRight = !isLookRight;
        float x = transform.localScale.x * -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }
}

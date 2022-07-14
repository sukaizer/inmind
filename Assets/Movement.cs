using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector2 jumpHeight;
    public float gravityScale = 5;
    public Rigidbody rb;
    public Animator animator;

    bool isFacingRight = true;
    bool jump = false;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalMove = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float speed = 50.0f;
        Vector3 moveDirection = new(horizontalMove, 0, vertical);
        transform.position += speed * Time.deltaTime * moveDirection;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


        if (horizontalMove > 0 && !isFacingRight)
        {
            Flip();
        } else if (horizontalMove < 0 && isFacingRight)
        {
            Flip();
        }
        if (Input.GetKeyDown("space")) {
            rb.AddForce(jumpHeight, ForceMode.Impulse);
            jump = true;
            animator.SetBool("Jump", true);
        }

    }

    private void FixedUpdate()
    {
        rb.AddForce((gravityScale - 1) * rb.mass * Physics.gravity);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        isFacingRight = !isFacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void OnLanding ()
    {
        print("on ground");
        animator.SetBool("Jump", false);
        jump = false;
    }

}

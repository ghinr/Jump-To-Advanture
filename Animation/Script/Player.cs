using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3 : MonoBehaviour
{
    private float speed = 7f;
    private Rigidbody2D body;
    private Animator anim;
    private bool canJump = true;
    public float jumpForce = 10f;
    private bool grounded = true;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        Vector3 scale = transform.localScale;
        if (horizontalInput > 0.01f)
            scale.x = Mathf.Abs(scale.x);
        else if (horizontalInput < -0.01f)
            scale.x = -Mathf.Abs(scale.x);
        transform.localScale = scale;

        if (canJump && Input.GetButtonDown("Jump"))
        {
            body.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            canJump = false;
            grounded = false;
            anim.SetTrigger("jump");
        }

        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            grounded = true;
        }
    }
}

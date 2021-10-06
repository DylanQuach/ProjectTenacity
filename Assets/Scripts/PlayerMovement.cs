using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float Speed = 10.0f;

    [SerializeField]
    private float JumpForce = 500;

    private float PlayerDefaultSpeed;

    Rigidbody2D Rigidbody;

    private Animator animator;

    private SpriteRenderer spriteRenderer;



    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        PlayerDefaultSpeed = Speed;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Rigidbody.AddForce(new Vector2(0, JumpForce));
            animator.SetBool("Jump", true);
        }
    }
    
    //using this since it causes less stutter
    private void FixedUpdate()
    {
        animator.SetFloat("Speed", 0);

        //move right
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * +Speed * Time.deltaTime;
            spriteRenderer.flipX = false;
            animator.SetFloat("Speed", 10);
        }

        //move left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.right * -Speed * Time.deltaTime;
            spriteRenderer.flipX = true;
            animator.SetFloat("Speed", 10);
        }

        if (IsGrounded())
        {
            animator.SetBool("Jump", false);
        }
        else
        {
            animator.SetBool("Jump", true);

        }

    }

    public void SetSpeed(float NewSpeed)
    {
        Speed = NewSpeed;
    }

    public float GetPlayerDefaultSpeed()
    {
        return PlayerDefaultSpeed;
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        return hit.collider != null;
    }
}

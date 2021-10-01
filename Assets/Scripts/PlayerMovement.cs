using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float Speed = 10.0f;

    [SerializeField]
    private float JumpForce = 500;

    Rigidbody2D Rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody.AddForce(new Vector2(0, JumpForce));
        }
    }
    
    //using this since it causes less stutter
    private void FixedUpdate()
    {
        //move right
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * +Speed * Time.deltaTime;
        }

        //move left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.right * -Speed * Time.deltaTime;
        }

    }

}

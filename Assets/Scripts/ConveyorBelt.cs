using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{

    enum MovementDirection
    {
        Right,
        Left
    }

    [SerializeField]
    private float PlayerSpeed = 5f;

    [SerializeField]
    private MovementDirection Direction = MovementDirection.Left;

    private GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("AddFriction", 0, 0.01f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CancelInvoke();
        }
    }


    void AddFriction()
    {
        if(Direction == MovementDirection.Left)
        {
            Player.transform.position += Vector3.right * -PlayerSpeed * 0.01f;
        }
        else if(Direction == MovementDirection.Right)
        {
            Player.transform.position += Vector3.right * +PlayerSpeed * 0.01f;
        }
    }
}

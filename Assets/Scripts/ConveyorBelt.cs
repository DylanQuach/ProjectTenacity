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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnterCollision(collision.gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        ExitCollision(collision.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        EnterCollision(col.gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        ExitCollision(other.gameObject);
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

    void EnterCollision(GameObject GO)
    {
        if (GO.CompareTag("Player"))
        {
            InvokeRepeating("AddFriction", 0, 0.01f);
        }
    }

    void ExitCollision(GameObject GO)
    {
        if (GO.CompareTag("Player"))
        {
            CancelInvoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfall : MonoBehaviour
{
    [SerializeField]
    private float PlayerSpeed = 5;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().SetSpeed(PlayerSpeed);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //gets the player movement component on the player and sets its speed to its default speed
            collision.gameObject.GetComponent<PlayerMovement>().SetSpeed(collision.gameObject.GetComponent<PlayerMovement>().GetPlayerDefaultSpeed());
        }
    }
}

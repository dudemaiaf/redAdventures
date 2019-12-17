using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMoviment moviment;
    void OnCollisionEnter2D (Collision2D collisionInfo)
    {
        if(collisionInfo.collider.tag == "Enemy")
        {
            //Debug.Log("1");
            moviment.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredMinion : MonoBehaviour
{
    public float speed;
    public float distance;
    [SerializeField]
    private bool movingRight = false;

    enum AnimationParameters { WalkTrigger };

    public Transform groundDetection;

    public Animator animator;
    public float delay;
    public bool animationGo = true;

    //private GameManager gameManager;
    private Rigidbody2D rigidbody2d;

    void Start(){
        //gameManager = FindObjectOfType<GameManager>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false){
            if(movingRight == true){
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = false;
            }else{
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingRight = true;
            }
        }

        StartCoroutine(timeOfAnimation(delay));
    }
    

    IEnumerator timeOfAnimation (float time){
        if(animationGo){
            animator.SetBool("Walk", true);
            animationGo = false;
        }else{
            yield return new WaitForSeconds(time);
            animationGo = true;
        }
    }

    // void OnTriggerEnter2D (Collision2D collider)
    // {
    //     if(collider.gameObject.tag == "Player")
    //     {
    //         if(collider.GetComponent<Rigidbody2D>().velocity.y <= 0f)
    //         {
    //             collider.GetComponent<Rigidbody2D>().velocity = new Vector2(rigidbody2d.velocity.x, collider.GetComponent<PlayerController>().jump);
    //             Destroy(gameObject);
    //         } 
    //     }
    // }
}

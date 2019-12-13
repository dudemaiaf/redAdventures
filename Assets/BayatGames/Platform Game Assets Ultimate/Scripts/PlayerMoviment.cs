using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{   
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        //StartCoroutine(settingRunAnimation());
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping",true);
        }

        //if(Input.GetButtonDown)
    }

    public void OnLanding ()
    {
        Debug.Log("111");
        animator.SetBool("IsJumping", false);
    }

    // IEnumerator settingRunAnimation (){
    //     animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    //     yield return new WaitForSeconds(0.5f);
    //     Debug.Log("Animação 2");
    // }

    void FixedUpdate ()
    {
        //move o player
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}

using System.Collections;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{

    Animator animator;
    public float val;
    public Transform groundCheck;
    public  float groundDistance = 0.1f;
    public LayerMask whatIsGround;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        val = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool("isRunning");
        bool movementInput = (Input.GetKey("w")  || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"));
        bool sprintingInput = Input.GetKey(KeyCode.LeftShift);
        bool jumpingInput = Input.GetKey(KeyCode.Space);
        bool touchGround = true;//Physics.CheckSphere(groundCheck.position, groundDistance, whatIsGround);


        //Controlla se sta camminando
        if(!isRunning && movementInput)
        {
            animator.SetBool("isRunning", true);
        }
        if(isRunning && !movementInput)
        {
            animator.SetBool("isRunning", false);
        }

        //Controlla se sta correndo
        if(movementInput && sprintingInput)
        {
            animator.SetBool("isSprinting", true);
        }
        else
        {
            animator.SetBool("isSprinting", false);
        }

        //Controlla se sta saltando
        if(jumpingInput && touchGround)
        {
            animator.SetBool("Jump", true);
            touchGround = false;
        }
        else
        {
            animator.SetBool("Jump", false);
        }

            

        
    }
}

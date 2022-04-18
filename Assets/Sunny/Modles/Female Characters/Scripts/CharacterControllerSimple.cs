using UnityEngine;
using System.Collections;

public class CharacterControllerSimple : MonoBehaviour
{

    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;

    private float runningFloat = 2f;
    CharacterController controller;
    Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
      //物体播放动画和走动


        

           
           
          

            if (Input.GetKey(KeyCode.W))
        {
            speed = 5;
            float curSpeed = Mathf.Abs(speed * Input.GetAxis("Vertical"));
           
                animator.SetFloat("Speed", curSpeed);

                transform.Translate(speed * Time.deltaTime * transform.forward, Space.World);
              
            }


            if (Input.GetKeyUp(KeyCode.W))
        {
            speed = 0;
            float curSpeed = Mathf.Abs(speed * Input.GetAxis("Vertical"));
           
            animator.SetFloat("Speed", curSpeed);

                
            }
        

       
        
    }
}

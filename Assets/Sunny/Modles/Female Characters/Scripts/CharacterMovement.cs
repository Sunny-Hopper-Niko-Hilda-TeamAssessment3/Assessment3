using UnityEngine;

namespace Cinemachine.Examples
{

[AddComponentMenu("")] // Don't display in add component menu
public class CharacterMovement : MonoBehaviour
{
    public bool keepDirection = false;
    public float turnSpeed = 10f;
    public KeyCode sprintJoystick = KeyCode.JoystickButton2;
    public KeyCode sprintKeyboard = KeyCode.Space;

    private float turnSpeedMultiplier;
    private float speed = 0f;
    private float direction = 0f;
    private bool isSprinting = false;
    private Animator anim;
    private Vector3 targetDirection;
    private Vector2 input;
    private Quaternion freeRotation;
    private Camera mainCamera;
    private float velocity;

	// Use this for initialization
	void Start ()
	{
	    anim = GetComponent<Animator>();
	    mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
        
	    input.x = Input.GetAxis("Horizontal");
	    input.y = Input.GetAxis("Vertical");

		// set speed to both vertical and horizontal inputs
        if (keepDirection) speed = Mathf.Abs(input.x) + input.y;
        else speed = Mathf.Abs(input.x) + Mathf.Abs(input.y);

        speed = Mathf.Clamp(speed, 0f, 1f);
        speed = Mathf.SmoothDamp(anim.GetFloat("Speed"), speed, ref velocity, 0.1f);
        anim.SetFloat("Speed", speed);

            if (input.y < 0f && keepDirection) direction = input.y;
	    else direction = 0f;
        
        anim.SetFloat("Direction", direction);
	    

        // set sprinting
	    if ((Input.GetKeyDown(sprintJoystick) || Input.GetKeyDown(sprintKeyboard)) && input != Vector2.zero && direction >= 0f) isSprinting = true;
	    if ((Input.GetKeyUp(sprintJoystick) || Input.GetKeyUp(sprintKeyboard))|| input == Vector2.zero) isSprinting = false;
        anim.SetBool("isSprinting", isSprinting);
        
        // Update target direction relative to the camera view (or not if the Keep Direction option is checked)
        UpdateTargetDirection();
        if (input != Vector2.zero && targetDirection.magnitude > 0.1f)
        {
            Vector3 lookDirection = targetDirection.normalized;
            freeRotation = Quaternion.LookRotation(lookDirection, transform.up);
            var diferenceRotation = freeRotation.eulerAngles.y - transform.eulerAngles.y;
            var eulerY = transform.eulerAngles.y;

            if (diferenceRotation < 0 || diferenceRotation > 0) eulerY = freeRotation.eulerAngles.y;
            var euler = new Vector3(0, eulerY, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(euler), turnSpeed * turnSpeedMultiplier * Time.deltaTime);
        }


            if (Input.GetKeyDown(KeyCode.J))
            {
                
                anim.SetBool("isattack1", true);
            }
            if (Input.GetKeyUp(KeyCode.J))
            {
                anim.SetBool("isattack1", false) ;
            }

            if (Input.GetKeyDown(KeyCode.K))
            {

                anim.SetBool("isattack3", true);
            }
            if (Input.GetKeyUp(KeyCode.K))
            {
                anim.SetBool("isattack3", false);
            }

            if (speed >= 0.8f && anim.GetBool("isattack1")==false)
            {
                transform.Translate(Vector3.forward * Time.deltaTime *5);
            }
            else
            {
                //  transform.Translate(Vector3.forward * Time.deltaTime * 3);
            }


        }

    public virtual void UpdateTargetDirection()
    {
            
            if (!keepDirection)
            {
                turnSpeedMultiplier = 1f;
                var forward = mainCamera.transform.TransformDirection(Vector3.forward);
                forward.y = 0;

                //get the right-facing direction of the referenceTransform
                var right = mainCamera.transform.TransformDirection(Vector3.right);

                // determine the direction the player will face based on input and the referenceTransform's right and forward directions
                targetDirection = input.x * right + input.y * forward;
            }
            else
            {
                turnSpeedMultiplier = 0.2f;
                var forward = transform.TransformDirection(Vector3.forward);
                forward.y = 0;

                //get the right-facing direction of the referenceTransform
                var right = transform.TransformDirection(Vector3.right);
                targetDirection = input.x * right + Mathf.Abs(input.y) * forward;
            }

        }


        public void OnPointerUpEvent1(int i)
        {

            if (i == 1)
            {
                ///  Debug.Log("抬起1" + this.gameObject.name);
                anim.SetBool("isattack1", false);
               
            }
            else if (i == 3 || i == 2)
            {
                // Debug.Log("抬起2" + this.gameObject.name);
                anim.SetBool("isattack2", false);
               
            }
            else if ( i==4)
            {
                anim.SetBool("isattack3", false);
                // Debug.Log("抬起3" + this.gameObject.name);
               
            }
           

        }


    }

}

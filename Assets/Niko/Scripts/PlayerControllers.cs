using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControllers : MonoBehaviour
{
    private CharacterController cc;
    public float moveSpeed;
    private float horizontalMove, verticalMove;
    private Vector3 dir;
    public float gravity;
    private Vector3 velocity;
    private int count;
    public AudioClip audioclip;
    private Transform audioPosition;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public AudioSource audioSource;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
      //  Cursor.lockState = CursorLockMode.Locked;
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void SetCountText()
    {
        countText.text = "Count" + count.ToString();
        if(count >= 10)
        {
            winTextObject.SetActive(true);
        }
    }

    private void Update()
    {

        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxis("Vertical") * moveSpeed;

        dir = transform.forward * verticalMove + transform.right * horizontalMove;
        cc.Move(dir * Time.deltaTime);

     

        velocity.y -= gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
            audioSource.Play();
           
        }
    } 
}
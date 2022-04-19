using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsManger : MonoBehaviour
{

    public int AnimalsNum = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameUI.Instance.AddScore(AnimalsNum);
            Destroy(this.gameObject);
        }
    }


}

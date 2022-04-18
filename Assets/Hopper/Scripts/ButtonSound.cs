using UnityEngine;
using System.Collections;
 
public class ButtonSound : MonoBehaviour {
 
	public AudioClip clip;
	public AudioSource source;
	public void click()
        {		                       
            source.PlayOneShot(clip);
	}
}
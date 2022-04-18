using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GetHelp : MonoBehaviour
{
	public void LoadsGame (string name)
	{
		SceneManager.LoadScene(name);
	}



}

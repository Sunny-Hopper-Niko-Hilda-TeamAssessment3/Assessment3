using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame1 : MonoBehaviour
{
    public void LoadsGame ()
	{
		SceneManager.LoadScene("NavigationScene");
	}
}

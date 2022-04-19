using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackStart : MonoBehaviour
{
    public void LoadsGame ()
	{
		SceneManager.LoadScene("HildaScene");
	}
}

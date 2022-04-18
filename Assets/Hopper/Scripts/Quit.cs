using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Quit : MonoBehaviour {


    bool isStop = true;
    public GameObject Menu;

    public void OnQuit()
    {
        SceneManager.LoadScene(0);
    }

    public void OnResume()
    {
        Time.timeScale = 1f;
        Menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (isStop == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                isStop = false;
                Menu.SetActive(true);
                Cursor.visible = true;
			    Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                isStop = true;
                Menu.SetActive(false);
            }
        }
    }
}

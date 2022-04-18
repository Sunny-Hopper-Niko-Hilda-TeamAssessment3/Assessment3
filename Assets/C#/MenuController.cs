using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{

    public GameObject MyIntroduceUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Playthegame(string  Name)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Name);
    }

    public void Introduce()
    {
        Time.timeScale = 1;
        MyIntroduceUI.SetActive(true);
    }

    public void CloseIntroduce()
    {
        Time.timeScale = 1;
        MyIntroduceUI.SetActive(false);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }


}

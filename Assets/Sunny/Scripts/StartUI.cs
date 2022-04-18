using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEditor;

public class StartUI : MonoBehaviour {
  
	public Button Btn1;
	
	public Button Btn2;
	
	


    //Start screen
    void Start()
    {
		Btn1.gameObject.transform.DOScale(1.2f, 1).SetLoops(-1, LoopType.Yoyo);
		Btn2.gameObject.transform.DOScale(1.1f, 1).SetLoops(-1, LoopType.Yoyo);
	
		Btn1.onClick.AddListener(() => { SceneManager.LoadScene("GameMain"); } );

		Btn2.onClick.AddListener(() => {
            //QuitGame();
            BackMenu();

        });
    }


    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }

	//Quit Game
	public void QuitGame()
    {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif


	}


}

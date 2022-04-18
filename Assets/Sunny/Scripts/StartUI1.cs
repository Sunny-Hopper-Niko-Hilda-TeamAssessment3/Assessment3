using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEditor;

public class StartUI1 : MonoBehaviour {
   //开始按钮
	public Button btn_start;
	//退出按钮
	public Button btn_quit;


	public InputField Value1;
	public InputField Value2;

    //Start screen
    void Start()
    {

		btn_quit.gameObject.transform.DOScale(1.2f, 1).SetLoops(-1, LoopType.Yoyo);
		btn_start.gameObject.transform.DOScale(1.2f, 1).SetLoops(-1, LoopType.Yoyo);
		
		btn_quit.onClick.AddListener(() =>
        {

#if UNITY_EDITOR    //In editor mode
			EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
		});
		btn_start.onClick.AddListener(() => {

            if (Value1.text=="123" && Value2.text=="123")
            {
				SceneManager.LoadScene("Start1");
			}
			


		});
	
    }

	//玩法回调函数
	public void SetFalse1()
    {
	


	}


	//玩法回调函数
	public void SetFalse2()
	{
		


	}
}

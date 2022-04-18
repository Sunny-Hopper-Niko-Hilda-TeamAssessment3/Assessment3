using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    //Score text
    public Text txt_score;
    public int Count;
   
    //胜利界面
    public GameObject successObj;
    //失败页面
    public GameObject failObj;

    //金币父物体

    public Transform CoinParent;

    public AudioSource BGMusic;
    private void Awake()
    {         
           Instance = this;
    }

    //添加点击事件
    private void Start()
    {
     

    }
    
    //失败界面
    public void Lose()
    {
       
        failObj.SetActive(true);
        Time.timeScale = 0;
    }


    //失败界面
    public void Succcess()
    {
        Time.timeScale = 0;
        successObj.SetActive(true);
        Time.timeScale = 0;
    }

    
   

    //Exit
    public void QuitGame() {

        Time.timeScale = 1;
        SceneManager.LoadScene("Sunny");
        Time.timeScale = 1;
    }

    //Play again
    public void StartAgain() {


        Time.timeScale = 1;
        SceneManager.LoadScene("GameMain");
        Time.timeScale = 1;
    }

  
    public void MenuBtn()
    {
        if (BGMusic.enabled==true)
        {
            BGMusic.enabled = false;
        }
        else
        {
            BGMusic.enabled = true;
        }
    }


    public void Pause()
    {

        Time.timeScale = 0;
    }


    public void Continue()
    {

        Time.timeScale = 1;
    }

}

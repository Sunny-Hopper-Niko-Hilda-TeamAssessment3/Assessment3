using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

    public static GameUI Instance;

    public GameObject gameLoseUI;
    public GameObject gameWinUI;
    bool gameIsOver;

    public int Score = 0;
    
    public float SkillTimeNum = 10;
 
    public Slider SkillTimeNumSlider;
    public bool IsSkill = false;
    public GameObject[] SkillEnemy;

    public Button SkillsBtn;

    public GameObject EndWin;

    public GameObject[] AnimalsNumUI;

    public GameObject IntroduceUI;

    public AudioSource GetSound;

    void Start()
    {
        Instance = this;

        Guard.OnGuardHasSpottedPlayer += ShowGameLoseUI;
        FindObjectOfType<Player> ().OnReachedEndOfLevel += ShowGameWinUI;
    }

    
    void Update()
    {
        if (gameIsOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (IsSkill == true)
        {
            SkillTimeNum -= Time.deltaTime;
            SkillTimeNumSlider.value = SkillTimeNum;

            if (SkillTimeNum <= 0)
            {
                IsSkill = false;

                for (int n = 0; n < SkillEnemy.Length; n++)
                {
                    SkillEnemy[n].SetActive(false);
                }

                SkillTimeNumSlider.gameObject.SetActive(false);
            }
        }

    }
    
    public void SkillsBtnLis()
    {

        IsSkill = true;
        SkillTimeNum = 7;

        for (int n = 0;n < SkillEnemy.Length;n++)
        {
            SkillEnemy[n].SetActive(true);
        }
       
        SkillsBtn.gameObject.SetActive(false);
        
    }

    void ShowGameWinUI()
    {
        OnGameOver (gameWinUI);
    }

    void ShowGameLoseUI()
    {
        OnGameOver (gameLoseUI);
    }

    void OnGameOver(GameObject gameOverUI)
    {
        gameOverUI.SetActive (true);
        gameIsOver = true;
        Guard.OnGuardHasSpottedPlayer -= ShowGameLoseUI;
        FindObjectOfType<Player> ().OnReachedEndOfLevel -= ShowGameWinUI;
    }



    public void AddScore(int Animals)
    {
        GetSound.Play();
       Score++;

        if (Animals == 0)
        {
            AnimalsNumUI[0].SetActive(true);
        }
        else if(Animals == 1)
        {
            AnimalsNumUI[1].SetActive(true);
        }
        else if (Animals == 2)
        {
            AnimalsNumUI[2].SetActive(true);
        }
        else if (Animals == 3)
        {
            AnimalsNumUI[3].SetActive(true);
        }

        if (Score == 4)
        {
            EndWin.SetActive(true);
        }
    }

    public void GotoMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }


    public void QuitListener()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }

    public void openIntroduceUI()
    {
        Time.timeScale = 0;
        IntroduceUI.SetActive(true);
    }

    public void closeIntroduceUI()
    {
        Time.timeScale = 1;
        IntroduceUI.SetActive(false);
    }


}

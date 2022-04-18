using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerRoom : MonoBehaviour
{
    public static TimerRoom Int;
    private void Awake()
    {
        Int = this;
    }
    public int keyFrame = 0;

    public  bool IsTime;
    public float initSeconds;
    public float nowSeconds;
    public GameObject uis;
    void Start() {
        IntTime();
    }
    // Update is called once per frame
    void Update()
    {
        timejs();
    }

    public string Texttime;  //当前时间
                             //时间初始化
    public void IntTime()
    {
        IsTime = true;
        nowSeconds = initSeconds;//当前时间
        ConverToTimeStr((int)nowSeconds);
    }
    void timejs()
    {
        if (IsTime)
        {
            nowSeconds = initSeconds -= Time.deltaTime;
            Texttime = ConverToTimeStr((int)nowSeconds);
            transform.GetComponent<Text>().text = Texttime;
            if (nowSeconds <= 0)
            {
                GameManager.Instance.Lose();
                IsTime = false;
            }
        }

    }
    string ConverToTimeStr(int sec)
    {
        int h = sec / 3600;
        int m = (sec - h * 300) / 60;
        int s = sec % 60;
        return string.Format("{0:D2}:{1:D2}", m, s);
    }

    public string OverTime()
    {
      
        IsTime = false;
        return Texttime;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
using UnityEngine.SceneManagement;

public class tuichu : MonoBehaviour {

	public Button[] buttons;
	void Start () {
		tuichu s = new tuichu();
		buttons[0].onClick.AddListener(chongzai);
		buttons[1].onClick.AddListener(tuichus);
	}

	void chongzai() {
		SceneManager.LoadScene("scen1");
	}
	void tuichus() {
		Application.Quit();
	}
}

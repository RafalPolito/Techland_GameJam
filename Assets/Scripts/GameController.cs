using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public static bool isPaused = false;
    public Image m_FadeScreen;
	
	void Update () {
	    if(Input.GetButtonDown("Pause")) {
            isPaused = !isPaused;
        }

        if(isPaused && Time.timeScale != 0) {
            Time.timeScale = 0;
            m_FadeScreen.color = new Color(0f, 0f, 0f, 0.5f);
        } else if(!isPaused && Time.timeScale != 1) {
            Time.timeScale = 1;
            m_FadeScreen.color = new Color(0f, 0f, 0f, 0f);
        }
	}

}

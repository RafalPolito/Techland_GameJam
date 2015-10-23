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
            Pause();
        } else if(!isPaused && Time.timeScale != 1) {
            Unfade();
        }
	}

    public void Fade() {
        Time.timeScale = 0;
        m_FadeScreen.color = new Color(0f, 0f, 0f, 1f);
    }

    public void Pause() {
        Time.timeScale = 0;
        m_FadeScreen.color = new Color(0f, 0f, 0f, 0.5f);
    }

    public void Unfade() {
        Time.timeScale = 1;
        m_FadeScreen.color = new Color(0f, 0f, 0f, 0f);
    }

}

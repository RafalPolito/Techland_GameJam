using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class GameController : MonoBehaviour {

    public static bool isPaused = false;
    public Image m_FadeScreen;
	public static bool m_GameOver = false;
    public static bool m_Cold = false;
    public static bool m_Win = false;
    public Text m_GameOverText;
    public Text m_ColdText;
    public Text m_PauseText;
    public Text m_WinText;
    public UnityEvent m_GameOverEvent;    

    void Update () {
        if(m_GameOver) {
            Fade();
            m_GameOverText.color = Color.white;
        } else {
            if(isPaused && Time.timeScale != 0) {
                Pause();
            } else if(!isPaused && Time.timeScale != 1) {
                Unfade();
            }
        }

        if(m_Cold) {
            Fade();
            m_ColdText.enabled = true;
        }

        if(m_Win) {
            Fade();
            m_WinText.enabled = true;
        }

        /*if(Input.GetButtonDown("Pause")) {
            isPaused = !isPaused;
            m_PauseText.enabled = !m_PauseText.enabled;
        }*/
	}

    public void Fade() {
        m_FadeScreen.color = new Color(0f, 0f, 0f, 1f);
        Time.timeScale = 0;
    }

    public void Pause() {
        //m_FadeScreen.color = new Color(0f, 0f, 0f, 0.5f);
        Time.timeScale = 0;
    }

    public void Unfade() {
        //m_FadeScreen.color = new Color(0f, 0f, 0f, 0f);
        Time.timeScale = 1;
    }

}

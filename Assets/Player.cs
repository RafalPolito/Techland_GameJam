using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    public static float m_FreezeLevel = 100;
    public float m_FreezingSpeed = 1;
    public RectTransform m_FreezeBar;

    void Start () {
	    
	}
	
	void Update () {
        m_FreezeLevel -= (m_FreezingSpeed * Time.deltaTime);

        if(m_FreezeLevel <= 0) {
            Application.LoadLevel(0);
        }

        m_FreezeBar.sizeDelta = new Vector2(m_FreezeLevel, m_FreezeBar.sizeDelta.y);
    }
}

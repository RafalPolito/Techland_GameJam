using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Player : MonoBehaviour {

    public static float m_FreezeLevel = 100;
    public float m_FreezingSpeed = 1;
    public RectTransform m_FreezeBar;

    private ThirdPersonCharacter m_ThirdPersonCharacter;

    void Start () {
        m_ThirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
    }
	
	void Update () {
        m_FreezeLevel -= (m_FreezingSpeed * Time.deltaTime);

        if(m_FreezeLevel <= 0) {
            Application.LoadLevel(0);
        }

        m_ThirdPersonCharacter.m_AnimSpeedMultiplier = m_FreezeLevel/100;
        m_FreezeBar.sizeDelta = new Vector2(m_FreezeLevel, m_FreezeBar.sizeDelta.y);
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Player : MonoBehaviour {

    public static float m_FreezeLevel = 100;
    public static float m_CurrentFreezeLevel;
    public float m_FreezingSpeed = 1;
    public float m_SnowFallingMultipler = 3;
    public RectTransform m_FreezeBar;
    public SnowEmitter m_SnowEmitter;
    public bool isNearFirecamp = false;
    public Color m_ColdColor = new Color(0f, 0.5f, 1f, 1f);
    public Color m_WarmColor = new Color(1f, 0.5f, 0f, 1f);
    public Text m_GameOver;
    public static bool isGameOver = false;
    public UnityEvent m_GameOverEvent;

    private ThirdPersonCharacter m_ThirdPersonCharacter;

    void Awake () {
        m_CurrentFreezeLevel = m_FreezeLevel;
        m_ThirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
    }
	
    float FreezeLevel() {
        if(m_CurrentFreezeLevel >= 75) {
            return 1f;
        } else if(m_CurrentFreezeLevel >= 50) {
            return 0.75f;
        } else if(m_CurrentFreezeLevel >= 25) {
            return 0.5f;
        } else {
            return 0.25f;
        }
    }

	void Update () {
        if(isNearFirecamp) {
            if(m_CurrentFreezeLevel < m_FreezeLevel) {
                m_CurrentFreezeLevel += (m_FreezingSpeed * Time.deltaTime);
                m_FreezeBar.GetComponent<Image>().color = m_WarmColor;
            }

            if(m_CurrentFreezeLevel >= m_FreezeLevel) {
                m_CurrentFreezeLevel = m_FreezeLevel;
                m_FreezeBar.GetComponent<Image>().color = Color.white;
            }
        } else {
            if(m_SnowEmitter.isSnowFalling) {
                m_CurrentFreezeLevel -= (m_FreezingSpeed * m_SnowFallingMultipler * Time.deltaTime);                
            } else {
                m_CurrentFreezeLevel -= (m_FreezingSpeed * Time.deltaTime);
            }

            m_FreezeBar.GetComponent<Image>().color = m_ColdColor;
        }

        if(m_CurrentFreezeLevel <= 0) {
            isGameOver = true;
            m_GameOverEvent.Invoke();
            m_GameOver.color = Color.white;
        }

        m_ThirdPersonCharacter.m_AnimSpeedMultiplier = FreezeLevel();
        m_FreezeBar.sizeDelta = new Vector2(m_CurrentFreezeLevel, m_FreezeBar.sizeDelta.y);
    }

    void OnTriggerEnter(Collider other) {
        if(other.GetComponent<Firecamp>() != null) {
            isNearFirecamp = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.GetComponent<Firecamp>() != null) {
            isNearFirecamp = false;
        }
    }
}

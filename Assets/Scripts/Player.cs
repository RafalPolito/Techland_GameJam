using UnityEngine;
using UnityEngine.UI;
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

    private ThirdPersonCharacter m_ThirdPersonCharacter;

    void Awake () {
        m_CurrentFreezeLevel = m_FreezeLevel;
        m_ThirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
    }
	
	void Update () {
        if(isNearFirecamp && m_CurrentFreezeLevel < m_FreezeLevel) {
            m_CurrentFreezeLevel += (m_FreezingSpeed * Time.deltaTime);
        } else if(m_SnowEmitter.isSnowFalling) {
            m_CurrentFreezeLevel -= (m_FreezingSpeed * m_SnowFallingMultipler * Time.deltaTime);
        } else {
            m_CurrentFreezeLevel -= (m_FreezingSpeed * Time.deltaTime);
        }

        if(m_CurrentFreezeLevel <= 0) {
            Application.LoadLevel(0);
        }

        m_ThirdPersonCharacter.m_AnimSpeedMultiplier = m_CurrentFreezeLevel/100;
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

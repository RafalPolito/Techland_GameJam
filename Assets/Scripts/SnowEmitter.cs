﻿using UnityEngine;
using System.Collections;

public class SnowEmitter : MonoBehaviour {

    public ParticleSystem m_EmitterInstance;
    public float m_LastSign = 1;
    public static int m_Count = 0;
    public float m_Timer = 7;
    private float m_ShakeTimer = 0;
    private static float m_CurrentTimer;
    public int m_EmitCount = 100;

    public bool isSnowFalling {
        get {
            if(m_EmitterInstance != null && m_EmitterInstance.particleCount > 0 && m_CurrentTimer <= 0) {
                return true;
            }

            return false;
        }
    }

    void Awake() {
        m_EmitterInstance.Stop();
        m_EmitterInstance.Clear();

        m_CurrentTimer = m_Timer;
    }

    void Update () {
        if(m_EmitterInstance != null) {
            m_Count = m_EmitterInstance.particleCount;

            if(m_EmitterInstance.particleCount > 0) {
                m_CurrentTimer -= Time.deltaTime;
            }

            if(m_EmitterInstance.particleCount == 0) {
                m_CurrentTimer = m_Timer;
            }

            if(!CameraRotator.isStarting) {
                float cameraShake = Input.GetAxis("CameraShake");

                if(cameraShake != 0 && Mathf.Sign(cameraShake) != m_LastSign) {
                    m_EmitterInstance.Emit(100);
                    m_LastSign = Mathf.Sign(cameraShake);
                } else if(m_EmitterInstance != null) {
                    m_EmitterInstance.Stop();
                }

                m_ShakeTimer -= Time.deltaTime;
            }
        }
    }
}

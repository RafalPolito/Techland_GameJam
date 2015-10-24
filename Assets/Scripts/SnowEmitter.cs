using UnityEngine;
using System.Collections;

public class SnowEmitter : MonoBehaviour {

    public ParticleSystem m_EmitterInstance;
    public float m_LastSign = 1;
    public static int m_Count = 0;
    public float m_Timer = 7;
    private float m_ShakeTimer = 0;
    private static float m_CurrentTimer;

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

                if(cameraShake != 0) {
                    if(m_ShakeTimer <= 0) {
                        m_EmitterInstance.Emit(50);
                        m_ShakeTimer = 1;
                    }
                } else if(m_EmitterInstance != null) {
                    m_EmitterInstance.Stop();
                }

                m_ShakeTimer -= Time.deltaTime;
            }
        }
    }
}

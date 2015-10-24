using UnityEngine;
using System.Collections;

public class SnowEmitter : MonoBehaviour {

    public ParticleSystem m_EmitterInstance;
    public float m_LastSign = 1;
    public static int m_Count = 0;

    public bool isSnowFalling {
        get {
            if(m_EmitterInstance.particleCount > 0) {
                return true;
            }

            return false;
        }
    }

    void Awake() {
        m_EmitterInstance.Stop();
        m_EmitterInstance.Clear();
    }

    void Update () {
        m_Count = m_EmitterInstance.particleCount;

        if(!CameraRotator.isStarting) {
            float cameraShake = Input.GetAxis("CameraShake");

            if(cameraShake != 0 && Mathf.Sign(cameraShake) != m_LastSign) {
                m_EmitterInstance.Emit(10);
                m_LastSign = Mathf.Sign(cameraShake);
            } else if(m_EmitterInstance != null) {
                m_EmitterInstance.Stop();
            }
        }
    }
}

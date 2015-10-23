using UnityEngine;
using System.Collections;

public class SnowEmitter : MonoBehaviour {

    public ParticleSystem m_EmitterInstance;
    public float m_LastSign = 1;

    void Awake() {
        m_EmitterInstance.Stop();
        m_EmitterInstance.Clear();
    }

    void Update () {
        float cameraShake = Input.GetAxis("CameraShake");

        if(cameraShake != 0 && Mathf.Sign(cameraShake) != m_LastSign) {
            //m_EmitterInstance.time = 0;
            m_EmitterInstance.Emit(10);
            m_LastSign = Mathf.Sign(cameraShake);
        } else if(m_EmitterInstance != null)  {
            m_EmitterInstance.Stop();
        }
	}
}

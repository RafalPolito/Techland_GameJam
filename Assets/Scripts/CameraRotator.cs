using UnityEngine;
using System.Collections;

public class CameraRotator : MonoBehaviour {

    public float m_CameraClampX = 10;
    public float m_ShakePower = 10;
    public float m_Speed = 0.5f;

	void Update () {
        float rotationX = transform.eulerAngles.x + Input.GetAxis("CameraMoveVertical") * m_Speed;
        float rotationY = transform.eulerAngles.y + Input.GetAxis("CameraMoveHorizontal") * m_Speed;

        if(rotationX < 90 - m_CameraClampX || rotationX > 270 + m_CameraClampX) {
          transform.eulerAngles = new Vector3(rotationX, rotationY, Input.GetAxis("CameraShake") * m_ShakePower);
        }
    }

}

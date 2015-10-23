using UnityEngine;
using System.Collections;

public class CameraRotator : MonoBehaviour {

    public float m_CameraClampX = 10;

	void Update () {
        float rotationX = transform.eulerAngles.x + Input.GetAxis("CameraMoveVertical");
        float rotationY = transform.eulerAngles.y + Input.GetAxis("CameraMoveHorizontal");

        if(rotationX < 90 - m_CameraClampX || rotationX > 270 + m_CameraClampX) {
          transform.eulerAngles = new Vector3(rotationX, rotationY, transform.eulerAngles.z);
        }
    }

}

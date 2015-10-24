﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraRotator : MonoBehaviour {

    public float m_CameraClampX = 10;
    public float m_ShakePower = 10;
    public float m_Speed = 0.5f;
    public float m_FOV = 60;
    public float m_ZoomSpeed = 5;
    public Camera m_Camera;
    public Image m_FadeScreen;
    public float m_StartDelay = 3;

    private Vector3 m_StartTransformPosition;
    private Vector3 m_StartTransformRotation;
    private bool isStarting = true;
    private bool isZoomed = false;

    void Awake() {
        m_StartTransformPosition = m_Camera.transform.position;
        m_StartTransformRotation = m_Camera.transform.eulerAngles;

        m_Camera.transform.position = Vector3.forward * -10000;
        m_Camera.transform.eulerAngles = Vector3.zero;
    }

    void Update () {
        if(m_StartDelay <= 0) {
            if(!isStarting && !GameController.isPaused) {
                float rotationX = transform.eulerAngles.x + Input.GetAxis("CameraMoveVertical") * m_Speed;
                float rotationY = transform.eulerAngles.y + Input.GetAxis("CameraMoveHorizontal") * m_Speed;

                if(rotationX < 90 - m_CameraClampX || rotationX > 360 - m_CameraClampX*2) {
                    transform.eulerAngles = new Vector3(rotationX, rotationY, Input.GetAxis("CameraShake") * m_ShakePower);
                }

                if(Input.GetButtonDown("CameraZoom")) {
                    isZoomed = !isZoomed;
                }

                if(m_Camera.transform.localEulerAngles.x > 0) {
                    m_Camera.transform.localEulerAngles = new Vector3(transform.eulerAngles.x * 0.1875f, 0, 0);
                    m_Camera.transform.localPosition = new Vector3(m_StartTransformPosition.x, m_StartTransformPosition.y, m_StartTransformPosition.z - transform.eulerAngles.x * 0.125f);
                }

                if(isZoomed) {
                    m_Camera.fieldOfView = Mathf.Lerp(m_Camera.fieldOfView, m_FOV / 2, Time.deltaTime * m_ZoomSpeed);
                } else {
                    m_Camera.fieldOfView = Mathf.Lerp(m_Camera.fieldOfView, m_FOV, Time.deltaTime * m_ZoomSpeed);
                }
            } else {
                m_Camera.transform.position = Vector3.Lerp(m_Camera.transform.position, m_StartTransformPosition, Time.deltaTime * m_ZoomSpeed / 2);
                m_Camera.transform.eulerAngles = Vector3.Lerp(m_Camera.transform.eulerAngles, m_StartTransformRotation, Time.deltaTime * m_ZoomSpeed / 2);
                m_FadeScreen.color = Color.Lerp(m_FadeScreen.color, Color.clear, Time.deltaTime);

                if(Vector3.Distance(m_Camera.transform.position, m_StartTransformPosition) < 0.05f
                    && Vector3.Distance(m_Camera.transform.eulerAngles, m_StartTransformRotation) < 0.05f) {
                    isStarting = false;
                }
            }
        } else {
            m_StartDelay -= Time.deltaTime;
        }
    }

}

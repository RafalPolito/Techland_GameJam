using UnityEngine;
using System.Collections;

public class EndPortal : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
        if(other.GetComponent<Player>()) {
            GameController.m_Win = true;
        }
    }

}

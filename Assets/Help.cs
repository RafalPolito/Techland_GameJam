using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Help : MonoBehaviour {

    public Text m_Help;

	void Update () {
	    if(Input.GetButtonDown("Help")) {
            m_Help.enabled = !m_Help.enabled;
        }
	}
}

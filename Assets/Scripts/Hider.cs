using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hider : MonoBehaviour {

    public float m_Timer = 3;
    private Text m_Text;

	void Start () {
        m_Text = GetComponent<Text>();
    }

    void Update() {
        if(m_Timer <= 0) {
            m_Text.color = Color.Lerp(m_Text.color, Color.clear, Time.deltaTime * 2);
        } else {
            m_Timer -= Time.deltaTime;
        }
    }
	
}

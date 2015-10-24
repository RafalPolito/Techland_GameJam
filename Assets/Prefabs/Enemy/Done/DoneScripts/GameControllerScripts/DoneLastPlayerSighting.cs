using UnityEngine;
using System.Collections;

public class DoneLastPlayerSighting : MonoBehaviour
{
    public Vector3 position = new Vector3(1000f, 1000f, 1000f);			// The last global sighting of the player.
	public Vector3 resetPosition = new Vector3(1000f, 1000f, 1000f);	// The default position if the player is not in sight.
	public float lightHighIntensity = 0.25f;							// The directional light's intensity when the alarms are off.
	public float lightLowIntensity = 0f;								// The directional light's intensity when the alarms are on.
	public float fadeSpeed = 7f;										// How fast the light fades between low and high intensity.
	public float musicFadeSpeed = 1f;									// The speed at which the 

}

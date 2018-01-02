using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	public Texture onDay;
	public Texture onEvening;
	public Texture onNight;
	public new Renderer renderer;

	private int hour;

	void Update () {
		
		checkHour ();
	}

	void checkHour(){
	
		hour = System.DateTime.Now.Hour;

		if (hour >= 8 && hour < 16) {
			renderer.material.SetTexture ("_MainTex", onDay);
		} else if (hour >= 16 && hour < 22) {
			renderer.material.SetTexture ("_MainTex", onEvening);
		} else {
			renderer.material.SetTexture ("_MainTex", onNight);
		}
	}
}

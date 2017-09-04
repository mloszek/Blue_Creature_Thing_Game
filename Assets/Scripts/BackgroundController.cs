using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	//public Material material;
	public Texture onDay;
	public Texture onEvening;
	public Texture onNight;
	public Renderer renderer;

	private Texture[] textures;
	private int index = 0;

	void Start () {
		textures = new Texture[3];
		textures [0] = onDay;
		textures [1] = onEvening;
		textures [2] = onNight;
		//renderer = this.GetComponent<MeshRenderer>();
	}

	void Update () {

		if (Input.GetKeyUp ("b")) {
			Debug.Log("kazam!");
			index++;
			if (index > 2) {
				index = 0;
			}
			renderer.material.SetTexture ("_MainTex", textures[index]);
		}
	}
}

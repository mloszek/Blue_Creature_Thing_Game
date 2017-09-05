using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMenuScript : MonoBehaviour {

	public GameObject buttons;

	public void showOrHideMenu () {

		if (buttons.activeInHierarchy) {
			buttons.SetActive (false);
		} else {
			buttons.SetActive (true);
		}

	}
}

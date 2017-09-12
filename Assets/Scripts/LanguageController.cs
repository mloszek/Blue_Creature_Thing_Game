using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageController : MonoBehaviour {

	public Text playText;
	public Text optionsText;
	public Text quitText;
	public Text langSelText;
	public Text langNameText;
	public Text volumeText;
	public Text superModeText;
	public Text actionText;
	public Text statusText;
	public Text mainMenuText;
	public Text hideMenu;
	public Text menuText;
	public Text levelText;
	public Text comfortText;
	public Text happyText;
	public Text hungerText;

	private string[][] languages = new string[2][];
	private int index = 0;


	private string[] wordsEN = {
		"English",
		"PLAY",
		"OPTIONS",
		"QUIT",
		"Language",
		"Volume",
		"Super mode",
		"ACTION",
		"CONDITION",
		"MAIN MENU",
		"BACK",
		"M",
		"LEVEL",
		"ENTERTAINMENT",
		"HAPPINESS",
		"HUNGER"
	};

	private string[] wordsPL = {
		"Polski",
		"GRAJ",
		"OPCJE",
		"WYJŚCIE",
		"Język",
		"Głośność",
		"Tryb :o",
		"AKCJA",
		"KONDYCJA",
		"MENU GŁÓWNE",
		"WRÓĆ",
		"M",
		"POZIOM",
		"ROZRYWKA",
		"SZCZĘŚCIE",
		"GŁÓD"
	};

	void Awake (){
		
		Application.runInBackground = true;

		languages[0] = wordsEN;
		languages [1] = wordsPL;
		refreshWords ();
	}

	public void switchLang (){

		index = index == 0 ? 1 : 0;
		refreshWords ();
	}

	void refreshWords (){
		playText.text = languages [index] [1];
		optionsText.text = languages [index] [2];
		quitText.text = languages [index] [3];
		langNameText.text = languages [index] [0];
		langSelText.text = languages [index] [4];
		volumeText.text = languages [index] [5];
		superModeText.text = languages [index] [6];
		actionText.text = languages [index] [7];
		statusText.text = languages [index] [8];
		mainMenuText.text = languages [index] [9];
		hideMenu.text = languages [index] [10];
		menuText.text = languages [index] [11];
		levelText.text = languages [index] [12];
		comfortText.text = languages [index] [13];
		happyText.text = languages [index] [14];
		hungerText.text = languages [index] [15];
	}
}

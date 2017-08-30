﻿using System.Collections;
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

	private string[][] languages = new string[2][];
	private int index = 0;


	private string[] wordsEN = {
		"English",
		"PLAY",
		"OPTIONS",
		"QUIT",
		"Language",
		"Volume",
		"Super mode"
	};

	private string[] wordsPL = {
		"Polski",
		"GRAJ",
		"OPCJE",
		"WYJŚCIE",
		"Język",
		"Głośność",
		"Tryb :o"
	};

	void Awake (){
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
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
	
	public int allowedLvl = 1;
	private int lvlComplete = 1;
	private Sonic _sonic;
	private int rings;
	[SerializeField] private UIManager _uiManager;

	public UIManager UIManager => _uiManager;


	private void Start()
	{
		lvlComplete = PlayerPrefs.GetInt("lvlComplete");
		if (allowedLvl > lvlComplete) return;
		for (int i = allowedLvl; i < lvlComplete; i++)
			UnlockOneLvl();
		if (GameObject.FindWithTag("Player") != null)
			_sonic = GameObject.FindWithTag("Player").GetComponent<Sonic>();
	}

	public void Save()
	{
		// PlayerPrefs.Save();
		PlayerPrefs.SetInt("lvlComplete", allowedLvl);
	}

	public void UnlockOneLvl()
	{
		allowedLvl++;
		Save();
	}
	
	public void ResetPlayer()
	{
		allowedLvl = 1;
		lvlComplete = 1;
		PlayerPrefs.DeleteKey("lvlComplete");
	}

	public void Winlvl()
	{
		_uiManager.SetWinScore();
		UnlockOneLvl();
		Invoke("GoToDataLvl", 4f);
	}

	public void GoToDataLvl()
	{
		SceneManager.LoadScene(1);
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LvlButtonController : MonoBehaviour
{
    [SerializeField] private GameObject _lock;
    [SerializeField] private int openLvl;
    public gameManager _GameManager;
    private int mem;


    private void Start()
    {
	    if (openLvl <= _GameManager.allowedLvl)
		    UnlockLvl(openLvl);
	    mem = _GameManager.allowedLvl;
    }

    private void FixedUpdate()
    {
	    if (_GameManager.allowedLvl > mem)
	    {
		    mem = _GameManager.allowedLvl;
		    for (int i = 0; i <= mem; i++)
			    UnlockLvl(i);
	    }
	    else if (_GameManager.allowedLvl < mem)
	    {
		    int i = mem;
		    mem = _GameManager.allowedLvl;
		    while (i >= mem && i > 1)
			    LockLvl(i--);
	    }
    }


    public void OpenLvl()
    {
	    // Debug.Log(_GameManager.allowedLvl + " - " + openLvl + " --- " + _lock.activeSelf);
	    if (openLvl > 0 && openLvl <= _GameManager.allowedLvl && !_lock.activeSelf)
	    {
		    Debug.Log("Lvl is open: " + openLvl);
		    SceneManager.LoadScene(openLvl + 1);
	    }
	    else
			Debug.Log("Lvl is not available");
    }

    public void UnlockLvl(int lvl)
    {
	    if (openLvl == lvl)
		    _lock.SetActive(false);
    }
    public void LockLvl(int lvl)
    {
	    Debug.Log(("wtf"));
	    if (openLvl == lvl)
		    _lock.SetActive(true);
    }
}

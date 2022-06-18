using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    public static void LoadData() => SceneManager.LoadScene(1);

    public void ResetPlayer()
    {
        PlayerPrefs.DeleteAll();
    }

    public void UnlockLvl()
    {
        GameObject.FindWithTag("GameController").GetComponent<gameManager>().allowedLvl++;
    }
}


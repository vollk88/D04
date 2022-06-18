using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class FinishBoard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("FIfiif");
        if (col.gameObject.tag == "Player")
            GetComponent<Animator>().SetBool("isFinish", true);
    }

    public void IsFinish()
    {
        GetComponent<Animator>().SetBool("isFinish", true);
    }
}

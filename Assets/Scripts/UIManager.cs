using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _oldScore;
    [SerializeField] private TextMeshProUGUI _time;
    [SerializeField] private TextMeshProUGUI _winScore;
    private float gameTime;
    private Sonic _sonic;
    private int second1, second2, minute1, minute2, hour, timeInSeconds = 0;
    public bool isFinish = false;
    void Start()
    {
        if (GameObject.FindWithTag("Player") != null)
            _sonic = GameObject.FindWithTag("Player").GetComponent<Sonic>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isFinish || _time == null) return;
        _time.text = "Time: " + minute1 + minute2 + ":" + second1 + second2;
        gameTime += 1 * Time.deltaTime;
        if (gameTime > 1)
        {
            gameTime = 0;
            timeInSeconds++;
            second2 += 1;
        }
        else if (second2 == 10)
        {
            second2 = 0;
            second1 += 1;
        }
        else if (second1 == 6)
        {
            second1 = 0;
            second2 = 0;
            minute1 += 1;
        }
        else if (minute1 == 10)
        {
            second1 = 0;
            second2 = 0;
            minute1 = 0;
            minute2 += 1;
        }
        SetScore();
    }

    public void SetScore()
    {
        _score.text = "Score: " + _sonic.rings;
    }

    public void SetWinScore()
    {
        _winScore.gameObject.SetActive(true);
        _winScore.text = "Score: " + (_sonic.rings * 100 - (timeInSeconds * 100));
    }

    public int ReturnScore()
    {
        return _sonic.rings * 100 - timeInSeconds * 100;
    }

    public void SetOldScore(int score)
    {
        if (_oldScore != null)
        {
            _oldScore.text = "Score: " + score;
        }
    }
}

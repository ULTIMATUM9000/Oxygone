using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerCounter;
    float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;
        timerCounter.text = timer.ToString("0");
        PlayerPrefs.SetFloat("Timer", timer);
    }
}
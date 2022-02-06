using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timeValue = 20f;
    public Text timerText;
    // Update is called once per frame
    void Update()
    {
        timeValue -= Time.deltaTime;
        DisplayTime();
    }
    void DisplayTime()
    {
        timerText.text = timeValue.ToString();
    }
}

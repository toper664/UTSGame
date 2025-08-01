using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float timeLimit = 60f;

    // Update is called once per frame
    void Update()
    {
        if (timeLimit > 0)
        {
            timeLimit -= Time.deltaTime;
        }
        else
        {
            timeLimit = 0;
            // GameOver();
        }
        timerText.text = "\nTime: " + Mathf.FloorToInt(timeLimit).ToString();

    }
}

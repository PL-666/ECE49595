using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    public TMP_Text timerText;
    public float gameTime;
    public bool stopTimer;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopTimer){
            // Debug.Log("startTimer");
            time -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(time/60);
            int seconds = Mathf.FloorToInt(time - minutes * 60f);

            string textTime = string.Format("{0:0}:{1:00}",minutes, seconds);

            if(time <= 0)
            {
                stopTimer = true;
            }

            if (stopTimer == false)
            {
                timerText.text = textTime;
                timerSlider.value = time;
            }
        }
    }

    public void StartTimer(){
        stopTimer = false;
        // time  = gameTime;
    }
    public void ResetTimer(){
        stopTimer = false;
        time = gameTime;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
    }
}

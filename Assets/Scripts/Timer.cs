using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    // public TMP_Text timerText;
    public float gameTime = 1000f;
    public bool stopTimer = true;
    public float time;
    public bool generate = false;
    // public string spawnTarget;

    // Start is called before the first frame update
    // void Start()
    void OnEnable()
    {

        Debug.Log("timer enables");
        ResetTimer();
       
    }

    private void Start()
    {
        stopTimer = true;
        generate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopTimer)
        {

            // Debug.Log("startTimer");
            time -= Time.deltaTime;


            // string textTime = string.Format("{0:0}:{1:00}",minutes, seconds);

            if(time <= 0)
            {
                stopTimer = true;
                timerSlider.gameObject.SetActive(false);
                generate = true;
            }

            if (stopTimer == false)
            {
                // timerText.text = textTime;
                timerSlider.value = time;
            }
        }
    }

    public void StartTimer(){
        stopTimer = false;
        // time  = gameTime;
    }
    public void ResetTimer(){
        time = gameTime;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        stopTimer = false;
    }
}

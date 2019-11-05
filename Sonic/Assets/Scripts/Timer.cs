using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timer;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        this.startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - this.startTime;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timer.text = "TIME" + " : " + seconds;
    }
}

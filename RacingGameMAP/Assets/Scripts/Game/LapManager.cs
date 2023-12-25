using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LapManager : MonoBehaviour
{
    public float startTime = 0;
    public float lapTime;
    public int currentLap = 0;
    bool lapStarted = false;
    bool sector2Started = false;
    bool sector3Started = false;
    public TMP_Text lapTimeFunctionText;
    public TMP_Text lapCounterText;
    void Start()
    {
        
    }

    
    void Update()
    {
        lapCounterText.text = currentLap.ToString();
        lapTimeFunctionText.text = lapTime.ToString("0:00");
        if (lapStarted == true)
        {
            lapTime += startTime + Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "LapStartCollider")
        {
            if (lapStarted == true && sector2Started == true && sector3Started == true)
            {
                lapStarted = false;
                sector2Started = false;
                sector3Started = false;
                lapTime = 0;
            }
            if (lapStarted == false)
            {
                currentLap++;
                lapStarted = true;
                Debug.Log("Lap Started");
                Debug.Log(currentLap);
            }

        }
        if (other.gameObject.name == "Sector2Collider")
        {
            if (sector2Started == false)
            {
                sector2Started = true;
                Debug.Log("Sector 2 started");
            }

        }
        if (other.gameObject.name == "Sector3Collider")
        {
            if (sector3Started == false)
            {
                sector3Started = true;
                Debug.Log("Sector 3 started");
            }

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class KartLapManager : MonoBehaviour
{



    public float startTimeKart = 0;
    public float lapTimeKart;
    public int currentLapKart = 0;
    bool lapStarted = false;
    bool sector2Started = false;
    bool sector3Started = false;
    public TMP_Text lapTimeFunctionKartText;
    public TMP_Text lapCounterKartText;

    void Start()
    {
        PlayerPrefs.SetInt("BeenInGame", 1);
    }


    void Update()
    {
          if (Input.GetKeyDown(KeyCode.Escape))   SceneManager.LoadScene(1);
        
         lapCounterKartText.text = currentLapKart.ToString();
         lapTimeFunctionKartText.text = lapTimeKart.ToString("0:00");

         if (lapStarted == true)
         {
            lapTimeKart += startTimeKart + Time.deltaTime; 
         }
         
        
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.name == "LapStartCollider")
         {
            
         if (lapStarted == true && sector2Started == true && sector3Started == true){
            lapStarted = false;
            sector2Started = false;
            sector3Started = false;
            if (lapTimeKart < 25)
            {
                PlayerPrefs.SetInt("LicenceLevel", PlayerPrefs.GetInt("LicenceLevel") + 1);
                SceneManager.LoadScene(1);
            }
            lapTimeKart = 0;
         }
         if (lapStarted == false)
         {
            currentLapKart++;
            lapStarted = true;
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

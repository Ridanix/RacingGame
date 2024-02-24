using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class dragRaceScript : MonoBehaviour
{
    public TMP_Text dragTimeText;
    public float dragTime;
    float startTime = 0;
   bool dragStarted = false;
    void Start()
    {
        PlayerPrefs.SetInt("BeenInGame", 1);
    }

    
    void Update()
    {
        dragTimeText.text = dragTime.ToString("0:00");
        if (Input.GetKeyDown(KeyCode.Escape))   SceneManager.LoadScene(1);
        if (dragStarted == true)
        {
            dragTime += startTime + Time.deltaTime;
        }
    }
    void OnTriggerEnter(Collider other){
        if (other.gameObject.name == "LapStartCollider")
        {
            if (dragStarted == false)
            {
                dragStarted = true;
            }
        }
        if (other.gameObject.name == "DragEndCollider")
        {
            if (dragStarted == true)
            {
                dragStarted = false;
                if (dragTime < 20f)
                {
                    PlayerPrefs.SetInt("LicenceLevel", PlayerPrefs.GetInt("LicenceLevel") + 1);
                    SceneManager.LoadScene(1);
                }
                else SceneManager.LoadScene(4);
            }
        }
    }
}

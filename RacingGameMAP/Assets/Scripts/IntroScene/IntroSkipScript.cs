using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;
using System;



public class IntroSkipScript : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public TMP_InputField driverNameInputField;
    public TMP_InputField driverSurnameInputField;
    public TMP_Text driverNameText;
    public TMP_Text driverNameBaseText;
    public TMP_Text driverLicenceNameText;
    public GameObject skipText;
    public GameObject canvasIntro;
    public GameObject canvasRestOfScene;
    public GameObject normalHolder;
    public GameObject driverCreatorHolder;
    public GameObject newLicenceLevelHolder;
    public GameObject driverNameTextObject;
    public GameObject driverSavedButtonObject;
    public GameObject LevelSelectorHolder;

    public GameObject LicenceLevelImage1;
    public GameObject LicenceLevelImage2;
    public GameObject LicenceLevelImage3;
    public GameObject LicenceLevelImage4;
    public GameObject newLicenceLevelImage1;
    public GameObject newLicenceLevelImage2;
    public GameObject newLicenceLevelImage3;
    public GameObject newLicenceLevelImage4;

    
    public GameObject level1Unknown;
    public GameObject level1Unlocked;
   
    public GameObject level2Unknown;
    public GameObject level2Unlocked;
    
    public GameObject level3Unknown;
    public GameObject level3Unlocked;
   
    public GameObject level4Unknown;
    public GameObject level4Unlocked;
   
    public GameObject level5Unknown;
    public GameObject level5Unlocked;
    
   
    void Start()
    {
    videoPlayer.loopPointReached += OnIntroFinished;
    driverNameBaseText.text = PlayerPrefs.GetString("DriverNamePref") + " " + PlayerPrefs.GetString("DriverSurnamePref");
    driverNameText.text = PlayerPrefs.GetString("DriverNamePref") + " " + PlayerPrefs.GetString("DriverSurnamePref");
    if (PlayerPrefs.GetInt("LicenceLevel")> 0)
    {
        driverNameTextObject.SetActive(true);
        driverSavedButtonObject.SetActive(true);
    }
    if (PlayerPrefs.GetInt("BeenInGame") == 1) OnIntroFinished(videoPlayer);
   
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.SetInt("LicenceLevel", PlayerPrefs.GetInt("LicenceLevel")+ 1);
        }
        if (Input.anyKeyDown){
            skipText.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnIntroFinished(videoPlayer);
            //SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.P)){
            PlayerPrefs.DeleteAll();
            driverNameTextObject.SetActive(false);
            driverSavedButtonObject.SetActive(false);
        }
      
    }
    void OnIntroFinished(VideoPlayer vp){
        canvasIntro.SetActive(false);
        canvasRestOfScene.SetActive(true);
        //SceneManager.LoadScene(2);

    }
    public void CreateNewDriverButtonClicked(){
        normalHolder.SetActive(false);
        driverCreatorHolder.SetActive(true);
        PlayerPrefs.SetInt("BeenInGame", 0);
    }
    public void DriverCreatedButtonClicked(){
        PlayerPrefs.SetString("DriverNamePref", driverNameInputField.text);
        PlayerPrefs.SetString("DriverSurnamePref", driverSurnameInputField.text);
        PlayerPrefs.SetInt("LicenceLevel",1);
        newLicenceLevelImage1.SetActive(true);
        newLicenceLevelImage2.SetActive(false);
        newLicenceLevelImage3.SetActive(false);
        newLicenceLevelImage4.SetActive(false);
        driverLicenceNameText.text = "C LICENSE(BRONZE)";
        driverLicenceNameText.color = new Color32(206,128,49, 255);
        driverNameText.text = PlayerPrefs.GetString("DriverNamePref") + " " + PlayerPrefs.GetString("DriverSurnamePref");
        driverNameBaseText.text = PlayerPrefs.GetString("DriverNamePref") + " " + PlayerPrefs.GetString("DriverSurnamePref");
        driverCreatorHolder.SetActive(false);
        newLicenceLevelHolder.SetActive(true);

        level1Unknown.SetActive(false);
        level1Unlocked.SetActive(true);
        level2Unknown.SetActive(true);
        level2Unlocked.SetActive(false);
        level3Unknown.SetActive(true);
        level3Unlocked.SetActive(false);
        level4Unknown.SetActive(true);
        level4Unlocked.SetActive(false);
        level5Unknown.SetActive(true);
        level5Unlocked.SetActive(false); 
        
    }
    public void licenceGrantedClicked(){
        switch (PlayerPrefs.GetInt("LicenceLevel"))
        {
            case 1:
            LicenceLevelImage1.SetActive(true);
            LicenceLevelImage2.SetActive(false);
            LicenceLevelImage3.SetActive(false);
            LicenceLevelImage4.SetActive(false);
            break;
            case 2:
            LicenceLevelImage1.SetActive(false);
            LicenceLevelImage2.SetActive(true);
            LicenceLevelImage3.SetActive(false);
            LicenceLevelImage4.SetActive(false);
            break;
            case 3:
            LicenceLevelImage1.SetActive(false);
            LicenceLevelImage2.SetActive(false);
            LicenceLevelImage3.SetActive(true);
            LicenceLevelImage4.SetActive(false);
            break;
            case 4:
            LicenceLevelImage1.SetActive(false);
            LicenceLevelImage2.SetActive(false);
            LicenceLevelImage3.SetActive(false);
            LicenceLevelImage4.SetActive(true);
            break;

        }
        PlayerPrefs.SetInt("LastLicenseLevel", PlayerPrefs.GetInt("LicenceLevel"));
        LevelSelectorHolder.SetActive(true);
        newLicenceLevelHolder.SetActive(false);
        
    }
    public void GoBackButtonClicked(){
        driverCreatorHolder.SetActive(false);
        normalHolder.SetActive(true);
        LevelSelectorHolder.SetActive(false);
         if (PlayerPrefs.GetInt("LicenceLevel")> 0)
    {
        driverNameTextObject.SetActive(true);
        driverSavedButtonObject.SetActive(true);
    }
    }
    public void SavedDriverButtonClicked(){
        PlayerPrefs.SetInt("BeenInGame", 0);
        if (PlayerPrefs.GetInt("LicenceLevel")> PlayerPrefs.GetInt("LastLicenseLevel"))
        {
            normalHolder.SetActive(false);
            newLicenceLevelHolder.SetActive(true);
        }
        else{
            normalHolder.SetActive(false);
            LevelSelectorHolder.SetActive(true);
        }
        
        
          switch (PlayerPrefs.GetInt("LicenceLevel"))
        {
            case 1:
            LicenceLevelImage1.SetActive(true);
            LicenceLevelImage2.SetActive(false);
            LicenceLevelImage3.SetActive(false);
            LicenceLevelImage4.SetActive(false);
            newLicenceLevelImage1.SetActive(true);
            newLicenceLevelImage2.SetActive(false);
            newLicenceLevelImage3.SetActive(false);
            newLicenceLevelImage4.SetActive(false);
            driverLicenceNameText.text = "C LICENSE(BRONZE)";
            driverLicenceNameText.color = new Color32(206,128,49, 255);

            level1Unknown.SetActive(false);
            level1Unlocked.SetActive(true);
            level2Unknown.SetActive(true);
            level2Unlocked.SetActive(false);
            level3Unknown.SetActive(true);
            level3Unlocked.SetActive(false);
            level4Unknown.SetActive(true);
            level4Unlocked.SetActive(false);
            level5Unknown.SetActive(true);
            level5Unlocked.SetActive(false);            
            break;
            case 2:
            LicenceLevelImage1.SetActive(false);
            LicenceLevelImage2.SetActive(true);
            LicenceLevelImage3.SetActive(false);
            LicenceLevelImage4.SetActive(false);
            newLicenceLevelImage1.SetActive(false);
            newLicenceLevelImage2.SetActive(true);
            newLicenceLevelImage3.SetActive(false);
            newLicenceLevelImage4.SetActive(false);
            driverLicenceNameText.text = "B LICENSE(SILVER)";
            driverLicenceNameText.color = new Color32(192,192,192, 255);

            level1Unknown.SetActive(false);
            level1Unlocked.SetActive(true);
            level2Unknown.SetActive(false);
            level2Unlocked.SetActive(true);
            level3Unknown.SetActive(true);
            level3Unlocked.SetActive(false);
            level4Unknown.SetActive(true);
            level4Unlocked.SetActive(false);
            level5Unknown.SetActive(true);
            level5Unlocked.SetActive(false);  
            break;
            case 3:
            LicenceLevelImage1.SetActive(false);
            LicenceLevelImage2.SetActive(false);
            LicenceLevelImage3.SetActive(true);
            LicenceLevelImage4.SetActive(false);
            newLicenceLevelImage1.SetActive(false);
            newLicenceLevelImage2.SetActive(false);
            newLicenceLevelImage3.SetActive(true);
            newLicenceLevelImage4.SetActive(false);
            driverLicenceNameText.text = "A LICENSE(GOLD)";
            driverLicenceNameText.color = new Color32(255,215,0, 255);

            level1Unknown.SetActive(false);
            level1Unlocked.SetActive(true);
            level2Unknown.SetActive(false);
            level2Unlocked.SetActive(true);
            level3Unknown.SetActive(false);
            level3Unlocked.SetActive(true);
            level4Unknown.SetActive(true);
            level4Unlocked.SetActive(false);
            level5Unknown.SetActive(true);
            level5Unlocked.SetActive(false);  
            break;
            case 4:
            LicenceLevelImage1.SetActive(false);
            LicenceLevelImage2.SetActive(false);
            LicenceLevelImage3.SetActive(false);
            LicenceLevelImage4.SetActive(true);
            newLicenceLevelImage1.SetActive(false);
            newLicenceLevelImage2.SetActive(false);
            newLicenceLevelImage3.SetActive(false);
            newLicenceLevelImage4.SetActive(true);
            driverLicenceNameText.text = "S LICENSE(AMETHYST)";
            driverLicenceNameText.color = new Color32(118,0,129, 255);

            level1Unknown.SetActive(false);
            level1Unlocked.SetActive(true);
            level2Unknown.SetActive(false);
            level2Unlocked.SetActive(true);
            level3Unknown.SetActive(false);
            level3Unlocked.SetActive(true);
            level4Unknown.SetActive(false);
            level4Unlocked.SetActive(true);
            level5Unknown.SetActive(false);
            level5Unlocked.SetActive(true); 
            break;
            default:
            LicenceLevelImage1.SetActive(false);
            LicenceLevelImage2.SetActive(false);
            LicenceLevelImage3.SetActive(false);
            LicenceLevelImage4.SetActive(true);
            newLicenceLevelImage1.SetActive(true);
            newLicenceLevelImage2.SetActive(false);
            newLicenceLevelImage3.SetActive(false);
            newLicenceLevelImage4.SetActive(true);
            driverLicenceNameText.text = "S LICENSE(AMETHYST)";
            driverLicenceNameText.color = new Color32(118,0,129, 255);

            level1Unknown.SetActive(false);
            level1Unlocked.SetActive(true);
            level2Unknown.SetActive(false);
            level2Unlocked.SetActive(true);
            level3Unknown.SetActive(false);
            level3Unlocked.SetActive(true);
            level4Unknown.SetActive(false);
            level4Unlocked.SetActive(true);
            level5Unknown.SetActive(false);
            level5Unlocked.SetActive(true); 
            break;

        }
    }
    public void SandBoxButtonClicked(){
        SceneManager.LoadScene(2);
    }
    public void QuitGame(){
        PlayerPrefs.SetInt("BeenInGame", 0);
        Application.Quit();
    }
    public void Level1Clicked(){
        SceneManager.LoadScene(3);
    }
    public void Level2Clicked(){
        SceneManager.LoadScene(4);
    }
    public void Level3Clicked(){
        SceneManager.LoadScene(5);
    }
    public void Level4Clicked(){
        
    }
    public void Level5Clicked(){
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(6);
    }
}

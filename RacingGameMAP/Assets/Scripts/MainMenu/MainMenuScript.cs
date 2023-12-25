using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{

    public GameObject normalImage;
    public GameObject secretImage;
    public AudioSource normalSound;
    public AudioSource secretSound;
   public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OnSecretClicked()
    {
        normalImage.SetActive(false);
        secretImage.SetActive(true);
        normalSound.Pause();
        secretSound.Play();
    }
}

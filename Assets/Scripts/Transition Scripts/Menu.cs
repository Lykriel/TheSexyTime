using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    //public Canvas MainCanvas;
    //public Canvas OptionsCanvas;

    void Awake()
    {
        //if (OptionsCanvas == null)
        //    return;
        //OptionsCanvas.enabled = false;
    }

    //public void OptionsOn()
    //{
    //    OptionsCanvas.enabled = true;
    //    MainCanvas.enabled = false;
    //}

    //public void ReturnOn()
    //{
    //    OptionsCanvas.enabled = false;
    //    MainCanvas.enabled = true;
    //}

    public void ReturnToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level01");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level02");
    }
    public void Pause()
    {
        SceneManager.LoadScene("Pause");
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelection");
    }
}

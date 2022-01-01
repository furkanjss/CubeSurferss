using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{
    public bool DidYouReturnPanel;
    public bool DidYouNextLevelPanel;

    private int levelsIndexCount;

    
    #region Singleton

    public static LevelSystem Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log("EXTRA : " + this + "  SCRIPT DETECTED RELATED GAME OBJ DESTROYED");
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    #endregion
    

    private void Start()
    {
        //level kayit ayarlandı
        Debug.Log("kayıtlı olan level"+PlayerPrefs.GetInt("kacincilevel"));
        DontDestroyOnLoad(this.gameObject);
        levelsIndexCount = SceneManager.sceneCountInBuildSettings-1;
        Debug.Log(levelsIndexCount);
    }

    private void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("kacincilevel", SceneManager.GetActiveScene().buildIndex));
        
        if (DidYouReturnPanel == true)
        {
            ReturnPanelOpen();    
        }
        else if(DidYouReturnPanel==false)
        {
            ReturnPanelClosed();
        }

        if (DidYouNextLevelPanel == true) 
        {
            NextLevelPanelOpen();
        }
        else if(DidYouNextLevelPanel==false)
        {
            NextLevelPanelClosed();
        }
    }

    /// <summary>
    /// Panel acma-kapama metodları ayarlandi
    /// </summary>
    public void ReturnPanelOpen()
    {
        
        transform.GetChild(0).gameObject.SetActive(true);
    } 
    public void ReturnPanelClosed()
    {
        
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void NextLevelPanelOpen()
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }
    public void NextLevelPanelClosed()
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }
    
    
    // <summary>
    /// Buton click ayarları yapıldı
    /// </summary>

    public void ReturnBtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DidYouReturnPanel = false;
        ReturnPanelClosed();

    }
 
    public void NextBtnClick()
    {
        if (SceneManager.GetActiveScene().buildIndex ==levelsIndexCount )
        {
            SceneManager.LoadScene(1);
            DidYouNextLevelPanel = false;
            NextLevelPanelClosed();
        }
        else
        {
            //PlayerPrefs.SetInt("kacincilevel", SceneManager.GetActiveScene().buildIndex);

            PlayerPrefs.SetInt("kacincilevel", SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(PlayerPrefs.GetInt("kacincilevel"));
            DidYouNextLevelPanel = false;
            NextLevelPanelClosed();


        }
    }
    
}

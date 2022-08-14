using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance = null;
    int sceneIndex;
    int levelComplete;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
    }

    public void isEndGame()
    {
        if (sceneIndex == 5)
        {
            Invoke("Menu", 1f);

        }
        else
        if (levelComplete < sceneIndex)
        {
            
            
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
               
            
        }
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 6);
    }
    void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}

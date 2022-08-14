using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start : MonoBehaviour
{
    public GameObject pan;
  
    void start()
    {
        
        pan.SetActive(false);
        
    }
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void OnClick()
    {
        pan.SetActive(true);
    }
}

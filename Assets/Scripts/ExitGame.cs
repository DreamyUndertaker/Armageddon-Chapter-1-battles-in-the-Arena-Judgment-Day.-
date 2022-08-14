using UnityEngine;
using System.Collections;

// Quits the player when the user hits escape

public class ExitGame : MonoBehaviour
{
    public void OnClick()
    {
        Application.Quit();
    }
}
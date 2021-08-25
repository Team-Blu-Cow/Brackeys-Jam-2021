using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFlags : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        if (PlayerPrefs.GetInt("FirstLoad", 0) == 0)
        {
            Debug.Log("First Load");
            //todo @jay want to be rotated 180 degrees on first launch, seems to be an issue with player controller
            PlayerPrefs.SetInt("FirstLoad", 1);
            PlayerPrefs.Save();
        }
        else
            Debug.Log("Not First Load");
    }
}
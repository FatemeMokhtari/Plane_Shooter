using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Debug;

public class GameController : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject PauseButton;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pauseGame()
    {
        UnityEngine.Debug.Log("salam");
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseButton.SetActive(false);
    }
}

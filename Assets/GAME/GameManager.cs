using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {
    
    public bool recording = true;

    private float fixedDT;
    private bool isPause = false;
    private void Start()
    {
        PlayerPrefManager.UnlockLevel(2);
        print(PlayerPrefManager.IsLevelUnlocked(1));
        print(PlayerPrefManager.IsLevelUnlocked(2));
        fixedDT = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update () {
        if (CrossPlatformInputManager.GetButton("Fire1")){
            recording = false;
        } else {
            recording = true;
        }

        if (Input.GetKeyDown(KeyCode.P) && isPause){
            PauseGame();
            isPause = true;
        } else if (Input.GetKeyDown(KeyCode.P) && !isPause)
        {
            ResumeGame();
            isPause = false;
        }
	}

    void PauseGame(){
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    void ResumeGame(){
        Time.timeScale = 1f;
        Time.fixedDeltaTime = fixedDT;
    }
}

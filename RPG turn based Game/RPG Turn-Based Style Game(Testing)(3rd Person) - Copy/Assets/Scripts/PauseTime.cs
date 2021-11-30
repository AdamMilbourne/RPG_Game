using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseTime : MonoBehaviour
{
   // [SerializeField] GameObject mainGameUI;
    [SerializeField] GameObject fightSceneUI;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] bool mainGamePaused = false;
    [SerializeField] bool fightScenePaused = true;
    // Start is called before the first frame update
  

    public void playFightScene()
    {
        mainGamePaused = true;
        pauseMenuUI.SetActive(false);

        Time.timeScale = 0f;

        fightSceneUI.SetActive(true);
        fightScenePaused = false;
    }

    public void playMainGame()
    {

    }

    public void Pause()
    {

    }
    
}

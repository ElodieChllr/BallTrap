using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public GameObject pnl_Pause;
    private bool isPaused;

    public PlayerInput playerInputRef;
    public GameObject player;

    public Animator settingsAnimator;

    void Start()
    {
        pnl_Pause.SetActive(false);
        playerInputRef = player.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInputRef.actions["Pause"].WasReleasedThisFrame())
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            OpenPause();
        }
        else
        {
            ClosePause();
        }
    }

    public void MyLoadScene(int idScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(idScene);
    }

    void OpenPause()
    {
        Time.timeScale = 0f;
        pnl_Pause.SetActive(true);

    }

    public void ClosePause()
    {
        Time.timeScale = 1f;
        pnl_Pause.SetActive(false);
    }


    public void OpenSettings()
    {
        settingsAnimator.SetTrigger("openSettings");
    }
}

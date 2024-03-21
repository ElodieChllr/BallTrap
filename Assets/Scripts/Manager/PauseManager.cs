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
        Debug.Log("open");
        Time.timeScale = 0f;
        pnl_Pause.SetActive(true);
    }

    public void ClosePause()
    {
        pnl_Pause.SetActive(false);
        Debug.Log("close");
        CloseSettings();
        Time.timeScale = 1f;

    }


    public void OpenSettings()
    {
        StartCoroutine(AnimSettings());
    }

    public void CloseSettings()
    {
        settingsAnimator.SetTrigger("closeSettings");
    }

    IEnumerator AnimSettings()
    {
        settingsAnimator.SetTrigger("openSettings");
        yield return new WaitForSeconds(1f);
        settingsAnimator.SetTrigger("idleSettings");

    }
}

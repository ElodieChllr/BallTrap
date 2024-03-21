using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public GameObject pnl_Pause;
    private bool isPaused;

    private PlayerInput playerInputRef;
    public GameObject player;

    public Animator settingsAnimator;
    public AudioSource chanson;
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
            if (isPaused)
            {
                OpenPause();
            }
            else
            {
                ClosePause();
            }
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
        chanson.Pause();
        pnl_Pause.SetActive(true);
        settingsAnimator.SetTrigger("openSettings");
    }

    public void ClosePause()
    {
       // StartCoroutine(sdfs());
        pnl_Pause.SetActive(false);
        Debug.Log("close");
        chanson.UnPause();
        Time.timeScale = 1f;

    }


    public void OpenSettings()
    {
        //StartCoroutine(AnimSettings());
    }

    public void CloseSettings()
    {
        //settingsAnimator.SetTrigger("closeSettings");
    }

    //IEnumerator AnimSettings()
    //{
    //    settingsAnimator.SetTrigger("openSettings");
    //    //yield return new WaitForSeconds(5f);
    //    //settingsAnimator.SetTrigger("idleSettings");

    //}

    IEnumerator sdfs()
    {
        yield return new WaitForSeconds(1f);
        settingsAnimator.SetTrigger("closeSettings");
        yield return new WaitForSeconds(2f); // Attendez un peu plus longtemps
        pnl_Pause.SetActive(false);
        Debug.Log("close");
        CloseSettings();
        Time.timeScale = 1f;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void LoadScene(int loadscene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(loadscene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

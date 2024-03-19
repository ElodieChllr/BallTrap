using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void LoadScene(int loadscene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(loadscene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

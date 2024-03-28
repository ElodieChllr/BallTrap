using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public GameObject pnl_OldPanel;
    public GameObject pnl_Selections;

    public GameObject Bt_FirstSelection;
    public GameObject Bt_OldSelect;

    
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

    public void OpenSelections()
    {
        pnl_OldPanel.SetActive(false);
        pnl_Selections.SetActive(true);
        EventSystem.current.SetSelectedGameObject(Bt_FirstSelection/*.gameObject*/);
    }

    public void CloseSelections()
    {
        pnl_OldPanel.SetActive(true);
        pnl_Selections.SetActive(false);
        EventSystem.current.SetSelectedGameObject(Bt_OldSelect/*.gameObject*/);
    }
}

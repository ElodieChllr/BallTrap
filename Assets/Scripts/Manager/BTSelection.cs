using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTSelection : MonoBehaviour
{
    public Button bt_MusiqueSelec;
    public Text txt_MusiqueName;

    
    public Color selectedColor = Color.black;

    
    private Color originalColor;

    void Start()
    {
        
        originalColor = txt_MusiqueName.color;
    }

    private void Update()
    {
        ChangeTextColor(bt_MusiqueSelec);
    }

    public void ChangeTextColor(bool isSelected)
    {
        if (isSelected)
        {
            Debug.Log("Selected");
            txt_MusiqueName.color = selectedColor;
        }
        else
        {
           
            txt_MusiqueName.color = originalColor;
        }
    }
}

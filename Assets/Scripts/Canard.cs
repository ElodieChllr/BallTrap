using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canard : MonoBehaviour
{
    public int points = 10;
    public ScoreManager scoreManager;

    private void OnMouseDown()
    {
        scoreManager.AjouterPoints(points);
        Debug.Log(scoreManager.scoreActuel);

        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canard : MonoBehaviour
{
    public int points = 10;
    public ScoreManager scoreManager;
    public CanardManager canardManagerRef;

    private Vector3 positionCible;
    private float vitesseDeplacement;


    private void Start()
    {
        
    }
    private void OnMouseDown()
    {
        scoreManager.AjouterPoints(points);
        Debug.Log(scoreManager.scoreActuel);

        Destroy(gameObject);
    }

    public void DeplacerVersPosition()
    {
        
    }

    void Update()
    {
      
    }
}

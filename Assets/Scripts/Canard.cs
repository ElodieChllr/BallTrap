using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canard : MonoBehaviour
{
    public int points = 10;
    public ScoreManager scoreManager;
    public CanardManager canardManagerRef;
    public AudioClip QuackClip;
    public AudioSource QuackSource;

    private Vector3 positionCible;
    private float vitesseDeplacement;


    private void Start()
    {
        QuackClip = GetComponent<AudioClip>();  
        QuackSource = GetComponent<AudioSource>();  
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
    public void ShootEm()
    {
        QuackSource.PlayOneShot(QuackClip);
    }
}

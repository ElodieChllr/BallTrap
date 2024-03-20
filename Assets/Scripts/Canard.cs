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

    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        QuackClip = GetComponent<AudioClip>();  
        QuackSource = GetComponent<AudioSource>();  
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown()
    {
        //scoreManager.AjouterPoints(points);
        //Debug.Log(scoreManager.scoreActuel);
        ShootEm();
        StartCoroutine(CoroutineKill());


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
        Debug.Log("ShootEm");
        this.spriteRenderer.enabled = false;
    }
    public IEnumerator CoroutineKill()
    {
        QuackSource.PlayOneShot(QuackClip);
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);    

    }
}

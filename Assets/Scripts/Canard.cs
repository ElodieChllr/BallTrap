using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.UI;

public class Canard : MonoBehaviour
{
    public int points = 10;
    public ScoreManager scoreManager;
    public CanardManager canardManagerRef;
    //public AudioClip QuackClip;
    public AudioSource QuackSource;

    private Vector3 positionCible;
    private float vitesseDeplacement;

    private SpriteRenderer spriteRenderer;
    private VirtualMouseUI virtualMouseUI;
   

    private void Start()
    {
        QuackSource = GetComponent<AudioSource>();  
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        OnShootCanard();
    }


    private void OnMouseDown()
    {
        //scoreManager.AjouterPoints(points);
        //Debug.Log(scoreManager.scoreActuel);
        ShootEm();
        StartCoroutine(CoroutineKill());


    }

    private void OnShootCanard()
    {
        if (virtualMouseUI.ShootController())
        {
            ShootEm();
            StartCoroutine(CoroutineKill());
        }
        else
            Debug.Log("noShoot");
    }

    public void DeplacerVersPosition()
    {
        
    }

    
    public void ShootEm()
    {
        QuackSource.Play();
        //QuackSource.PlayOneShot(QuackClip);
        Debug.Log("ShootEm");
        this.spriteRenderer.enabled = false;
    }
    public IEnumerator CoroutineKill()
    {
        QuackSource.Play();
        //QuackSource.PlayOneShot(QuackClip);
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);    

    }
}

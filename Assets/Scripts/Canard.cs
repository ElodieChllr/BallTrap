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

    private Animator shakeCamAnim;
   

    private void Start()
    {
        QuackSource = GetComponent<AudioSource>();  
        spriteRenderer = GetComponent<SpriteRenderer>();
        shakeCamAnim = GameObject.FindWithTag("MainCamera").GetComponent<Animator>();
    }
    void Update()
    {
        OnShootCanard();
    }


    private void OnMouseDown()
    {
        //scoreManager.AjouterPoints(points);
        //Debug.Log(scoreManager.scoreActuel);
        //shakeCamAnim.SetTrigger("ShakeCam");
        

    }

    public void OnShootCanard()
    {
        if (virtualMouseUI.ShootController() == true)
        {
            ShootEm();
            StartCoroutine(CoroutineKill());
        }
        else
            return;
    }

    public void DeplacerVersPosition()
    {
        
    }

    
    public void ShootEm()
    {
        shakeCamAnim.SetTrigger("ShakeCam");
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

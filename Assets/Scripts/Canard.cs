using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
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
    private Collider2D _collider2D;
    private VirtualMouseUI virtualMouseUI;

    private Animator shakeCamAnim;

    private PlayerInput playerInputRef;
    public GameObject player;
   

    private void Start()
    {
        QuackSource = GetComponent<AudioSource>();  
        spriteRenderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();
        shakeCamAnim = GameObject.FindWithTag("MainCamera").GetComponent<Animator>();
        virtualMouseUI = GetComponent<VirtualMouseUI>();

        player = GameObject.FindWithTag("Player");
        playerInputRef = player.gameObject.GetComponent<PlayerInput>();
    }
    void Update()
    {
        //OnShootCanard();
    }


    private void OnMouseDown()
    {
        //scoreManager.AjouterPoints(points);
        //Debug.Log(scoreManager.scoreActuel);
        //shakeCamAnim.SetTrigger("ShakeCam");
        

    }
    

    //public void OnShootCanard()
    //{
    //    if (virtualMouseUI.ShootController() == true)
    //    {
    //        ShootEm();
    //        StartCoroutine(CoroutineKill());
    //    }
    //    else
    //        return;
    //}

    public void DeplacerVersPosition()
    {
        
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponents<Canard>();
            Debug.Log("on trigger");

            if (playerInputRef.actions["Shoot"].IsPressed())
            {
                Debug.Log("shoot");
                shakeCamAnim.SetTrigger("ShakeCam");
                ShootEm();
            }

        }
    }

    public void ShootEm()
    {
        this._collider2D.enabled = false;
        QuackSource.Play();
        Debug.Log("ShootEm");
        this.spriteRenderer.enabled = false;
        this._collider2D.enabled = false;
    }
    public IEnumerator CoroutineKill()
    {
        QuackSource.Play();
        //QuackSource.PlayOneShot(QuackClip);
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);    

    }
}

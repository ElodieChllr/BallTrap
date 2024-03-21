using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;

public class Canard : MonoBehaviour
{
    public int points = 10;
    private ScoreManager scoreManager;
    public CanardManager canardManagerRef;
    //public AudioClip QuackClip;
    public AudioSource QuackSource;
    public AudioSource explosionQuack;

    private Vector3 positionCible;
    private float vitesseDeplacement;

    private SpriteRenderer spriteRenderer;
    private Collider2D _collider2D;
    private VirtualMouseUI virtualMouseUI;

    private Animator shakeCamAnim;

    private PlayerInput playerInputRef;
    public GameObject player;

    public ParticleSystem particleSystemRef;
   

    private void Start()
    {
        QuackSource = GetComponent<AudioSource>();  
        spriteRenderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();
        shakeCamAnim = GameObject.FindWithTag("MainCamera").GetComponent<Animator>();
        virtualMouseUI = GetComponent<VirtualMouseUI>();

        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();

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
                scoreManager.AjouterPoints(points);
                ShootEm();
            }

        }
    }

    public void ShootEm()
    {
        particleSystemRef.Play();
        this._collider2D.enabled = false;
        QuackSource.Play();
        explosionQuack.Play();
        Debug.Log("ShootEm");
        this.spriteRenderer.enabled = false;
        this._collider2D.enabled = false;
    }
    public IEnumerator CoroutineKill()
    {
        QuackSource.Play();
        explosionQuack.Play();
        //QuackSource.PlayOneShot(QuackClip);
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);    

    }
}

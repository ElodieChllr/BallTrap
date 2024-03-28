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
    private ScoreManager scoreManagerRef;
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

    public ParticleSystem shootCanard;
    public ParticleSystem perfectShoot;
    public ParticleSystem missShoot;
    
    private BarManager barManager;

    private Gamepad gamepad;
    public bool canardKilled = false;

    private void Start()
    {
        QuackSource = GetComponent<AudioSource>();  
        spriteRenderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();
        shakeCamAnim = GameObject.FindWithTag("MainCamera").GetComponent<Animator>();
        virtualMouseUI = GetComponent<VirtualMouseUI>();

        scoreManagerRef = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        barManager = GameObject.FindGameObjectWithTag("Dead").GetComponent<BarManager>();

        player = GameObject.FindWithTag("Player");
        playerInputRef = player.gameObject.GetComponent<PlayerInput>();


        //if (Gamepad.current != null)
        //{
        //    gamepad = Gamepad.current;
        //}
        //else
        //{
        //    Debug.LogWarning("No gamepad found.");
        //}
    }

    public void StartVibration(float duration, float amplitude)
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(amplitude, amplitude);
            Invoke("StopVibration", duration);
        }
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

            if (barManager.barreTrigger == true)
            {
                Debug.Log("BARRRE");
                if (playerInputRef.actions["Shoot"].WasPerformedThisFrame())
                {
                    Debug.Log("Perfect");
                    ShootEm();
                    this.perfectShoot.Play();
                    scoreManagerRef.StartCoroutine(scoreManagerRef.PerfectScoreColor());
                    scoreManagerRef.AjouterPointPerfect(1000);
                }

                Debug.Log("OnBARRE");
            }
            else
            {
                if (playerInputRef.actions["Shoot"].WasPerformedThisFrame())
                {
                    Debug.Log("Normal");
                    this.missShoot.Play();
                    scoreManagerRef.StartCoroutine(scoreManagerRef.ShootScoreColor());
                    ShootEm();
                    scoreManagerRef.AjouterPoints(100);
                }
            }

        }     
    }

    public void ShootEm()
    {
        shakeCamAnim.SetTrigger("ShakeCam");
        shootCanard.Play();
        this._collider2D.enabled = false;
        QuackSource.Play();
        explosionQuack.Play();
        StartVibration(5f, 1f);
        Debug.Log("ShootEm");
        this.spriteRenderer.enabled = false;
        this._collider2D.enabled = false;
        this.gameObject.tag = "Dead";
        this.canardKilled = true;
    }
    public IEnumerator CoroutineKill()
    {
        QuackSource.Play();
        explosionQuack.Play();
        //QuackSource.PlayOneShot(QuackClip);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);    

    }

    //public void OnCollisionEnter2D(Collision2D collision)      
    //{
    //    if (collision.gameObject.CompareTag("DeathZone"))
    //    {
    //        Debug.Log("deathZone");
    //        StartVibration(0.1f, 0.5f);
    //    }
    //}
}

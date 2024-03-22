using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //public Color EnemyDamaged;
    //private Renderer _renderer;
    //private Color OriginalColor;
    //private float FlashDuration = 0.5f;


    //[SerializeField] private bool rotateContinuously = false;
    //[SerializeField] private float rotationSpeed = 800f;

    //public GameObject EffetDeDamage;
    private Gamepad gamepad;
    public float moveSpeed = 5f;

    //public AudioSource EnemyDeathSound;

    //public GameObject[] bossBullet;

    //public GameObject boss;
    //private Animator bossAnimator;

    //private Animator BossPaternAnimation;


    //BOSS
    //[SerializeField] private float fireInterval = 2.0f; // Interval in seconds between each shot
    //[SerializeField] private GameObject bulletPrefab; // Prefab of the bullet to shoot
    //[SerializeField] private Transform firePoint; // Transform representing the point where the bullet will be fired
    //private float nextFireTime; // The time when the boss can fire again




    //public int scoreEnemy;

    //public static readonly Dictionary<string, int> enemyScores = new Dictionary<string, int>
    //{
    //    {"Ennemy1(Clone)", 500 },
    //    {"Ennemy2(Clone)", 1000 },
    //    {"Boss(Clone)" , 30000 }
    //};
    
    
    //LIFE
    //private int currentHealth;
    //public int life;
    
    private PlayerController playerController;
    //private Bullet BulletScript;
    //private WaveManager waveSpawner;
    void Start()
    {

        if (Gamepad.current != null)
        {
            gamepad = Gamepad.current;
        }
        else
        {
            Debug.LogWarning("No gamepad found.");
        }
        //BOSS
        //nextFireTime = Time.time + fireInterval;
        //

        //waveSpawner= GetComponentInParent<WaveManager>();
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
       // bossAnimator = boss.GetComponent<Animator>();
    }

    private void Update()
    {
        //if (rotateContinuously)
        //{
        //    transform.Rotate(Vector2.up * rotationSpeed * Time.deltaTime);
        //}

        ////BOSS
        //if (Time.time >= nextFireTime)
        //{
        //    Fire();
        //    nextFireTime = Time.time + fireInterval;
        //}
        //
    }

    public void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.y += moveSpeed * Time.deltaTime;

        if (pos.y >= 6.9f)
        {
            StartVibration(0.1f, 0.5f);
           gameObject.SetActive(false);
        }

        //waveSpawner.waves[waveSpawner.currentWaveIndex].enemiesLeft--;

        transform.position = pos;
    }

    //public void SetDamage(int degat)
    //{
    //    life -= degat;
    //    //EffetDeDamage.SetActive(true);//peut pas tirer sur l'enemy apres par contre genre bizarre

    //    if (life <= 0)
    //    {
    //        EnemyDeathSound.Play();
    //        //LootEnemy loot = this.GetComponent<LootEnemy>();
    //        //loot.Loot();

    //        //Destroy(gameObject);
    //        gameObject.SetActive(false);
    //        //EnemyDeath();



    //        string enemyName = gameObject.name;
    //        int enemyScore = enemyScores[enemyName];
    //        //playerController.UptadeScore(enemyScore);
    //    }
    //    else if (life <= 0 && gameObject.CompareTag("Boss"))
    //        Destroy(gameObject);
    //}

    /*void BossQuiApparait()
    {
        BossPaternAnimation = GameObject.Find("Boss").GetComponent<Animator>();

    }*/


    //public static IEnumerator BossTirIntervalles()
    //{
    //    yield return new WaitForSeconds(1f);

    //    //tir

    //    yield break;
    //}

    //BOSS
    //private void Fire()
    //{
    //    Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    //}
    //

    public void StartVibration(float duration, float amplitude)
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(amplitude, amplitude);
            Invoke("StopVibration", duration);
        }
    }
    private void StopVibration()
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(0f, 0f);
        }
    }
}

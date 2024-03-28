using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BarManager : MonoBehaviour
{
    public PlayerController playerControllerRef;
    Canard Canard;
    ScoreManager scoreManager;

    public bool barreTrigger;
    //public bool canardShoot;

    private Canard canardRef;
    void Start()
    {
        barreTrigger = false;
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // BarreTrigger();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") )
            barreTrigger = true;
        canardRef = collision.gameObject.GetComponent<Canard>();
        //Debug.Log("canard Pris");
        //canardRef.QuackSource.Play();

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            barreTrigger = false;
        }
    }

    //public void BarreTrigger()
    //{
    //    if (barreTrigger && playerControllerRef.playerInput.actions["Shoot"].WasPerformedThisFrame())
    //    {
    //        Debug.Log("Barrrrrre");
    //        canardRef.perfectShoot.Play();
    //        scoreManager.AjouterPointPerfect(1000);
    //    }
    //    else
    //        Debug.Log("U Miss noob");
    //}
}

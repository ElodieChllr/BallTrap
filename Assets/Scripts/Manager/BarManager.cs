using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager : MonoBehaviour
{
    public PlayerController playerControllerRef;
    Canard Canard;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player")&& other.CompareTag("Enemy") && playerControllerRef.playerControls.actions["Shoot"].WasPerformedThisFrame())
        {
            Debug.Log("shoot");
            Canard.ShootEm();
            //other.gameObject.GetComponent<Canard>();
            Debug.Log("take script");
        }
    }
}

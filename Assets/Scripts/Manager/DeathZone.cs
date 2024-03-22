using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeathZone : MonoBehaviour
{
    //private Gamepad gamepad;

    //private Canard canardRef;


    //void Start()
    //{
    //    if (Gamepad.current != null)
    //    {
    //        gamepad = Gamepad.current;
    //    }
    //    else
    //    {
    //        Debug.LogWarning("No gamepad found.");
    //    }
    //}

    //public void StartVibration(float duration, float amplitude)
    //{
    //    if (gamepad != null)
    //    {
    //        gamepad.SetMotorSpeeds(amplitude, amplitude);
    //        Invoke("StopVibration", duration);
    //    }
    //}

    //private void StopVibration()
    //{
    //    if (gamepad != null)
    //    {
    //        gamepad.SetMotorSpeeds(0f, 0f);
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    //public void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //        this.canardRef.GetComponent<Canard>();
    //        if(this.canardRef.canardKilled == true)
    //        {
    //            Debug.Log("deathZone");
    //            StartVibration(0.1f, 0.5f);
    //        }
            
    //    }
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float vitesseDeSuivi = 15f;

    public float minX = -7f;
    public float maxX = 7f;

    //public PlayerControls playerControls;
    //public PlayerInput playerInput;

    //private void OnEnable()
    //{
    //    playerControls.Enable();
    //}
    //private void OnDisable()
    //{
    //    playerControls.Disable();
    //}

    private void Start()
    {
        
    }

    void Update()
    {

        Vector3 positionSouris = Input.mousePosition;
       // Vector3 positionSouris = playerControls.PlayerMap.MoveAim.ReadValue<Vector3>();


        Vector3 positionDansLeMonde = Camera.main.ScreenToWorldPoint(positionSouris);


        positionDansLeMonde.x = Mathf.Clamp(positionDansLeMonde.x, minX, maxX);


        positionDansLeMonde.y = transform.position.y;
        positionDansLeMonde.z = transform.position.z;


        transform.position = Vector3.Lerp(transform.position, positionDansLeMonde, vitesseDeSuivi * Time.deltaTime);
    }



}

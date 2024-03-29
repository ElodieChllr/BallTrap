using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class PlayerController : MonoBehaviour
{
    public float vitesseDeSuivi = 15f;

    public float minX = -7f;
    public float maxX = 7f;

    public bool onCanard = false;

    private Gamepad gamepad;

    //private VirtualMouseUI virtualMouse;

    public PlayerInput playerControls;
    public PlayerInput playerInput;
    private Canard canard;

    public float speedMove;
    private Rigidbody2D rb2D;
    InputAction moveAction;

    private Canard canardRef;

    public AudioSource fusil;

    public GameObject fusilTir;

    private void Awake()
    {
        moveAction = playerInput.actions["MoveAim"];
        playerControls = GetComponent<PlayerInput>();
        fusilTir.SetActive(false);
    }
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);


        if (Gamepad.current != null)
        {
            gamepad = Gamepad.current;
        }
        else
        {
            Debug.LogWarning("No gamepad found.");
        }

    }

    void Update()
    {

       // Vector3 positionSouris = Input.mousePosition;
       //// Vector3 positionSouris = playerControls.PlayerMap.MoveAim.ReadValue<Vector3>();


       // Vector3 positionDansLeMonde = Camera.main.ScreenToWorldPoint(positionSouris);


       // positionDansLeMonde.x = Mathf.Clamp(positionDansLeMonde.x, minX, maxX);


       // positionDansLeMonde.y = transform.position.y;
       // positionDansLeMonde.z = transform.position.z;


       // transform.position = Vector3.Lerp(transform.position, positionDansLeMonde, vitesseDeSuivi * Time.deltaTime);

        //Move();
        Vector2 movement = moveAction.ReadValue<Vector2>();
        Vector2 move = new Vector2(movement.x, movement.y);
        rb2D.velocity = new Vector2(move.x * speedMove, move.y * speedMove);

        SonFusil();
    }

    public void SonFusil()
    {
        if (playerInput.actions["Shoot"].WasPerformedThisFrame())
        {
            if(onCanard == true)
            {
                fusil.Play();
                fusilTir.SetActive(true);
                StartVibration(0.1f, 1f);
            }
            else if(onCanard == false)
            {
                fusil.Play();
                fusilTir.SetActive(true);
                StartVibration(0.1f, 0.5f);
            }
            
        }
        else
            fusilTir.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            onCanard = true;
            Debug.Log("on Canard");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            onCanard = false;
            Debug.Log("plus on Canard");
        }        
    }



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

    //private void Move()
    //{
    //    Vector2 movement = moveAction.ReadValue<Vector2>();
    //    Vector2 move = new Vector2(movement.x, movement.y);
    //    rb2D.velocity = new Vector2(move.x * speedMove, move.y * speedMove);
    //}


    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //        other.gameObject.GetComponents<Canard>();
    //        Debug.Log("on trigger");

    //        if (playerControls.actions["Shoot"].IsPressed())
    //        {
    //            Debug.Log("shoot");
    //            canardRef.ShootEm();
    //        }           

    //    }        
    //}




}

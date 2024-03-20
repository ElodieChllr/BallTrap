using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanardManager : MonoBehaviour
{
    public GameObject ennemiPrefab;

    public GameObject spawnEnnemy;

    public float delaiSpawn = 2f;


    public float moveSpeed = 5f;



    private float tempsEcouleDepuisSpawn = 0f;

    
    void Start()
    {

    }

    
    void Update()
    {
        
        tempsEcouleDepuisSpawn += Time.deltaTime;

        
        if (tempsEcouleDepuisSpawn >= delaiSpawn)
        {
            //Instantiate(ennemiPrefab,spawnEnnemy.position);
            ennemiPrefab.GetComponent<Canard>().DeplacerVersPosition();
        }
    }
}

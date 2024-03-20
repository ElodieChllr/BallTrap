using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particule : MonoBehaviour
{
    public GameObject canard;

    private void Start()
    {
        canard.GetComponent<ParticleSystem>();
    }

    IEnumerator PlayParticle()
    {
        yield return new WaitForSeconds(2);

        yield break; 
    }
}

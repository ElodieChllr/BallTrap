using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class MoveSin : MonoBehaviour
{
    float sinCenterX;
    public float amplitude = 1f;
    public float frequency = 1f;

    public bool inverted;
    public bool sinMovement;
    public bool otherMovement;
    //public bool bossMovement;

    //public Animator animator;

    void Start()
    {
        sinCenterX = transform.position.x;
        //animator.SetBool("IsPatternReady", false);
    }

    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        if (MovementSin() == true)
        {
            MovementSin();
        }
        else
            return;

        //if(MovementOther() == true)
        //{
        //    MovementOther();
        //}
        //else
        //    return;

        //if(BossMovement() == true)
        //{
        //    BossMovement();
        //}
        //else
        //    return;
    }


    private bool MovementSin()
    {
        if(sinMovement == true)
        {
            Vector2 pos = transform.position;

            float sin = Mathf.Sin(pos.y * frequency) * amplitude;
            if (inverted)
            {
                sin *= -1;
            }
            pos.x = sinCenterX + sin;

            transform.position = pos;

            return true;
        }
       return false;
    }

    //private bool MovementOther()
    //{
    //    if(otherMovement == true)
    //    {

    //        return true;
    //    }
    //    return false;
    //}

    //private bool BossMovement()
    //{
    //    if(bossMovement == true)
    //    {
    //        Debug.Log("Animator marche?");
    //        animator.SetTrigger("IsPatternReady");
    //        Enemy.BossTirIntervalles();
    //        return true;
    //    }
    //    return false;
    //}
}

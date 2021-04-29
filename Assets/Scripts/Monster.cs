using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isDirectCollision(collision))
        {
            onSpotDeath();
        }
    }

    private bool isDirectCollision(Collision2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();

        //get by bird
        if(bird != null)
        {
            return true;
        }
        
        //hit by vertical falling crate
        if(collision.contacts[0].normal.y < -0.5)
        {
            return true;
        }

        return false;
    }

    private void onSpotDeath()
    {
        gameObject.SetActive(false); //disappear from gameplay
    }


}

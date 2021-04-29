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

        if(bird != null)
        {
            return true;
        }
        return false;
    }

    private void onSpotDeath()
    {
        gameObject.SetActive(false);
    }


}

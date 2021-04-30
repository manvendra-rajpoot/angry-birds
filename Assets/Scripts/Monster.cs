using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Monster : MonoBehaviour
{
    [SerializeField]
    private Sprite _deadSprite;

    [SerializeField]
    private ParticleSystem _particleSystem;
    
    private bool _hasDied;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDirectCollision(collision))
        {
            Death();
        }
    }

    private bool isDirectCollision(Collision2D collision)
    {
        if (_hasDied)
        {
            return false;
        }
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

    private void Death()
    {
        _hasDied = true;

        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _particleSystem.Play();
        StartCoroutine(DieAfterDelay());
    }

    private IEnumerator DieAfterDelay()
    {
        yield return new WaitForSeconds(2f);

        //_particleSystem.Play();

        gameObject.SetActive(false); //disappear from gameplay
    }

}

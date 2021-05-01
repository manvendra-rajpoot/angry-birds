using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    Monster[] _monsters;
    
    [SerializeField]
    public string _nextLevelName;

    private void OnEnable()
    {
        _monsters = FindObjectsOfType<Monster>(); //array of all monsters in particular level scene
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AllMonstersDead())
        {
            GoToNextLevel();
        }
        
    }

    private void GoToNextLevel()
    {
        Debug.Log("Go to =>" + _nextLevelName);
        SceneManager.LoadScene(_nextLevelName);
    }

    private bool AllMonstersDead()
    {
        foreach (var monster in _monsters)
        {
            //if any monster is alive return false
            if (monster.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }
}

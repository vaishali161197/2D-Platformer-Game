﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOverController : MonoBehaviour
{
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    //void Update()
    //{

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
     // if(collision.gameObject.CompareTag("Player"))
        if(collision.gameObject.GetComponent<PlayerController>())
        {   

            Debug.Log("level finished by the player");

        }
    }
}

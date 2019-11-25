﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObatScript : MonoBehaviour
{
    public float timer;
    public AudioSource obat;

    // Update is called once per frame
    void Update()
    {
         if(timer>0){
            timer -= Time.deltaTime;
        }else{
            timer = 0;
            if (GameManager.instance.gamestatus == GameManager.GameStatus.Play && GameManager.instance.score >= 70) {
                    
                    transform.Translate(0, -0.03f, 0);
                        
                    //if exit the screen
                    if (gameObject.transform.localPosition.y < -4.5f) {
                        gameObject.transform.localPosition = new Vector3 (Random.Range(-2.32f, 2.32f), 5.5f, 0);
                        timer=3;
                    }
                    
            } else {
                transform.Translate(0, 0, 0);
            }
        }       
    }

        private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            GameManager.instance.pusing = false;
            obat.PlayOneShot(obat.clip);
            gameObject.transform.localPosition = new Vector3 (Random.Range(-2.32f, 2.32f), 5.5f, 0);
            timer=10;
        }
    }
}
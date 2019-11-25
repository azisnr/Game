using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    public AudioSource coin;
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gamestatus == GameManager.GameStatus.Play) {
				
            transform.Translate(0, -0.03f, 0);
				    
			//if exit the screen
			if (gameObject.transform.localPosition.y < -3) {
				gameObject.transform.localPosition = new Vector3 (Random.Range(-2.32f, 2.32f), 5.5f, 0);
			}
				
		} else {
            transform.Translate(0, 0, 0);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            GameManager.instance.NambahScore(); 
            coin.PlayOneShot(coin.clip);
            gameObject.transform.localPosition = new Vector3 (Random.Range(-2.32f, 2.32f), 5.5f, 0);
        }
    }
}

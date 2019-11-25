using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{

    void Update()
    {
		if (GameManager.instance.gamestatus == GameManager.GameStatus.Play && !GameManager.instance.isFreze) {
				
            if(GameManager.instance.flash == true) {
                transform.Translate(0, -0.04f, 0);
                    
                if (gameObject.transform.localPosition.y < -4.5f) {
                    gameObject.transform.localPosition = new Vector3 (Random.Range(-2.32f, 2.32f), 5.5f, 0);
                } 

            }else{

                transform.Translate(0, -0.02f, 0);
                    
                if (gameObject.transform.localPosition.y < -4.5f) {
                    gameObject.transform.localPosition = new Vector3 (Random.Range(-2.32f, 2.32f), 5.5f, 0);
                }
            }		
	    }else {
            transform.Translate(0, 0, 0);
        }
    }
}

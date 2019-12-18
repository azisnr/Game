using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
	private Rigidbody2D _rigidbody2D;
	public Vector3 playerPos;
	public float posY;	
	public KeyCode atas,kanan, kiri, space;
	public AudioSource jump, die, back;

	
	void Start ()
	{
		//todo get rigidbody component	
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	
	void Update ()
	{				
		if (GameManager.instance.gamestatus == GameManager.GameStatus.Wait) {
			_rigidbody2D.gravityScale = 0;
				
		}
		else {
			//todo gravity scale change physic of the bird in game
			_rigidbody2D.gravityScale = 2;
		}			
		
		//input for game keyboard or mouse tap
		if (Input.GetKeyDown(atas)) {
            if (GameManager.instance.gamestatus == GameManager.GameStatus.Wait)
            {
                GameManager.instance.gamestatus = GameManager.GameStatus.Play;
				back.PlayOneShot(back.clip);
            }

            if (GameManager.instance.gamestatus == GameManager.GameStatus.Play)
            {
                Jump();
            }
        }

		if (Input.GetKeyDown(space)) {
			if (GameManager.instance.gamestatus == GameManager.GameStatus.GameOver){
				SceneManager.LoadScene("EmotJump");
        	} 
		}

		if (Input.GetKeyDown(kanan)) {
            if (GameManager.instance.gamestatus == GameManager.GameStatus.Play)
            {
                keKanan();
            }
        }

		if (Input.GetKeyDown(kiri)) {
            if (GameManager.instance.gamestatus == GameManager.GameStatus.Play)
            {
                keKiri();
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
	{
		if(GameManager.instance.gamestatus != GameManager.GameStatus.GameOver){
			if(collision.gameObject.tag == "tile")
			{
				_rigidbody2D.velocity = new Vector2(0, -5);
				GameManager.instance.gamestatus = GameManager.GameStatus.GameOver;
				back.Stop();
				die.PlayOneShot(die.clip);
			}if(collision.gameObject.tag == "batasan")
			{
				_rigidbody2D.velocity = new Vector2(0, -5);
				GameManager.instance.gamestatus = GameManager.GameStatus.GameOver;
				back.Stop();
				die.PlayOneShot(die.clip);
			}	
		}
	}
    

	/// <summary>
	/// use for touch call
	/// </summary>
	public void Jump ()
	{
		playerPos = transform.position;
		posY = transform.position.y;
            _rigidbody2D.velocity = new Vector2 (0, 4);
			jump.PlayOneShot(jump.clip);
		
	}

	public void keKanan ()
	{
		playerPos = transform.position;
		posY = transform.position.y;
		if(GameManager.instance.pusing){
        	_rigidbody2D.velocity = new Vector2 (-2, 0);
		}else{
			_rigidbody2D.velocity = new Vector2 (2, 0);
		}
		
	}

	public void keKiri ()
	{
		playerPos = transform.position;
		posY = transform.position.y;
        if(GameManager.instance.pusing){
        	_rigidbody2D.velocity = new Vector2 (2, 0);
		}else{
			_rigidbody2D.velocity = new Vector2 (-2, 0);
		}
		
	}
}



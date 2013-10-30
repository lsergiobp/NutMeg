using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	private Sprite sprite;
	public bool right;
	private Vector3 initialPosition;
	private Vector3 enemyPosition;
	private float limit;
	private float intervalBetweenFrames = 0.2f;
	private float enemyVelocity = 0.15f;
	private bool isPlaying;
	
	void Start () {
		initSprite();
		handleGameEvents();
		
		initialPosition = transform.localPosition;
		limit = initialPosition.y + 35.0f;
		right = true;
		isPlaying = false;
		
		if( GameEventController.playNumber == 0 )
		{
			renderer.enabled = false;
		}
	}
	
	void Update () {
	
		if ( transform.localPosition.x >= limit )
		{
			right = false;
			sprite.Stop();
			isPlaying = false;
		}
		
		if ( transform.localPosition.x <= initialPosition.x )
		{
			right = true;
			sprite.Stop();
			isPlaying = false;
		}
		
		if( right ) 
		{	
			if( !isPlaying )
			{
				sprite.Play( Sprite.PlayMode.WalkRight, intervalBetweenFrames );
				isPlaying = true;
			}
			
			enemyPosition = transform.localPosition;
			enemyPosition.x = enemyPosition.x + enemyVelocity;
			transform.localPosition = enemyPosition;
		}
		
		else if( !right ) 
		{
			if( !isPlaying )
			{
				sprite.Play( Sprite.PlayMode.WalkLeft, intervalBetweenFrames );
				isPlaying = true;
			}
			
			enemyPosition = transform.localPosition;
			enemyPosition.x = enemyPosition.x - enemyVelocity;
			transform.localPosition = enemyPosition;
		}
		
	}
	
	//Metodo que inicializa com a sprite parado
	void initSprite()
	{
		sprite = GetComponent<Sprite>();
		sprite.Create( SpriteSet.GetSprite( "Enemy" ) );
		sprite.SetFrame( "stopRight" );
	}
	
	void handleGameEvents()
	{
		GameEventController.GameStart += GameStart; 
		
	}
	
	void GameStart() 
	{
		renderer.enabled = true;
	}
}

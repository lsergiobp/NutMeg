using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	private Sprite sprite;
	private bool right;
	public bool initialMovRight;
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
		initialPosition.x = initialPosition.x - 1.0f;
		
		if( initialMovRight )
			limit = initialPosition.x + 20.0f;
		else
			limit = initialPosition.x - 20.0f;
		
		isPlaying = false;
		
		if( GameEventController.playNumber == 0 )
		{
			renderer.enabled = false;
		}
	}
	
	void Update () {
	
		if( initialMovRight )
			movRight();
		else
			movLeft();
		
	}
	
	void movRight()
	{
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
			
			if( right && !GameEventController.paused ) 
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
			
			else if( !right && !GameEventController.paused ) 
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
	
	void movLeft()
	{
		if ( transform.localPosition.x <= limit )
			{
				right = true;
				sprite.Stop();
				isPlaying = false;
			}
			
			if ( transform.localPosition.x >= initialPosition.x )
			{
				right = false;
				sprite.Stop();
				isPlaying = false;
			}
			
			if( right && !GameEventController.paused ) 
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
			
			else if( !right && !GameEventController.paused ) 
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
		GameEventController.GamePause += GamePause;
	}
	
	void GameStart() 
	{
		renderer.enabled = true;
	}
	
	void GamePause()
	{
		if ( !GameEventController.paused )
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}
}

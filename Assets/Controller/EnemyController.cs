using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	private Sprite sprite;
	public bool right;
	private Vector3 initialPosition;
	private Vector3 enemyPosition;
	private float limit;
	
	void Start () {
		initSprite();
		handleGameEvents();
		
		initialPosition = transform.localPosition;
		limit = initialPosition.y + 35.0f;
		right = true;
	}
	
	void Update () {
	
		if ( transform.localPosition.x >= limit )
			right = false;
		
		if ( transform.localPosition.x <= initialPosition.x )
			right = true;
		
		if( right ) 
		{
			enemyPosition = transform.localPosition;
			enemyPosition.x = enemyPosition.x + 0.2f;
			transform.localPosition = enemyPosition;
		}
		
		else if( !right ) 
		{
			enemyPosition = transform.localPosition;
			enemyPosition.x = enemyPosition.x - 0.2f;
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
		
	}
}

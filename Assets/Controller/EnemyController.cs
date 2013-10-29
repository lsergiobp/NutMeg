using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	private Sprite sprite;
	
	void Start () {
		
		initSprite();
	}
	
	void Update () {
	
	}
	
	//Metodo que inicializa com a sprite parado
	void initSprite()
	{
		sprite = GetComponent<Sprite>();
		sprite.Create( SpriteSet.GetSprite( "Enemy" ) );
		sprite.SetFrame( "stopRight" );
	}
}

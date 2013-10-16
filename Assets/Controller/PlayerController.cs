using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Sprite sprite;
	
	void Start () {
		sprite = GetComponent<Sprite>();
		sprite.Create( SpriteSet.GetSprite( "Player" ) );
		sprite.SetFrame( "parado" );
	}
	
	
	void Update () {
	
	}
}

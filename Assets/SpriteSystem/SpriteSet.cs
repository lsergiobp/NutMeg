using UnityEngine;
using System.Collections.Generic;

/**
 * 
 * Classe Responsavel por carregar as sprites
 * 
**/ 
public class SpriteSet : MonoBehaviour {
	
	private static List<SpriteSheetInfo> sprites;
	public TextAsset dadosSprite;
	
	
	void Awake() 
	{
	
		sprites = XMLParser.Parse( dadosSprite );
		
	}
	
	public static SpriteSheetInfo getSprite( string name ) 
	{
		
		foreach( SpriteSheetInfo sprite in sprites )
		{
		
			if( sprite.SpriteName == name )
				return sprite;
			
		}
		return null;
	}
}

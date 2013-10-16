using UnityEngine;
using System.Collections.Generic;

/**
 * 
 * Classe Responsavel por carregar as sprites
 * 
**/ 
public class SpriteSet : MonoBehaviour {
	
	private static List<SpriteSheetInfo> sprites;
	public TextAsset spriteData;
	
	
	void Awake() 
	{
	
		sprites = XMLParser.Parse( spriteData );
		
	}
	
	public static SpriteSheetInfo GetSprite( string name ) 
	{
		
		foreach( SpriteSheetInfo sprite in sprites )
		{

			if( sprite.SpriteName == name )
				return sprite;
			
		}
		return null;
	}
}

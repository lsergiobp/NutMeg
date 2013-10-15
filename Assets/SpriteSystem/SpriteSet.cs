/*using UnityEngine;
using System.Collections.Generic;

public class SpriteSet : MonoBehaviour {
	
	private static List<SpriteSheetInfo> sprites;
	public TextAsset dadosSprite;
	
	
	void Awake() 
	{
	
		sprites = XmlParser.parse( dadosSprite );
		
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
}*/

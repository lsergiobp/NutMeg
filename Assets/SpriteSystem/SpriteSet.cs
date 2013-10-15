using UnityEngine;
using System.Collections.Generic;

public class SpriteSet : MonoBehaviour {
	
	private static List<SpriteSheetInfo> sprites;
	public TextAsset dadosSprite;
	
	
	void Awake() {
	
		sprites = XmlParser.parse( dadosSprite );
		
	}
	
	public static SpriteSheetInfo getSprite( string nome ) {
		
		foreach( SpriteSheetInfo sprite in sprites ) {
		
			if( sprite.NomeSprite == nome )
				return sprite;
			
		}
		return null;
	}
}

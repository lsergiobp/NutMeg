using UnityEngine;
using System.Collections.Generic;

/**
 * 
 * Classe que ira conter as infromaçoes das sprites
 * 
**/
public class SpriteSheetInfo {
	
	private SortedDictionary<string, SpriteRect> _spriteInfo;
	private string _spriteName;
	
	public SpriteSheetInfo( SortedDictionary<string, SpriteRect> SpriteInfo, string SpriteName ) 
	{
		_spriteInfo = SpriteInfo;
		_spriteName = SpriteName;
	}
	
	//Retorna uma sprite de acordo com o nome(chave) passado
	public SpriteRect GetSprite( string name ) 
	{
		return _spriteInfo[ name ];	
	}
	
	//Retorna um vetor com o nome das sprites
	public string[] GetSpriteNames()
	{
		string[] names = new string[ _spriteInfo.Count ];
		_spriteInfo.Keys.CopyTo( names, 0 );
		return names;
	}

}

﻿using UnityEngine;
using System.Collections.Generic;

/**
 * 
 * Classe que ira conter as informacoes das sprites
 * 
**/
public class SpriteSheetInfo {
	
	private Dictionary<string, SpriteRect> _spriteInfo;
	private string _spriteName;

	public Dictionary<string, SpriteRect> SpriteInfo
	{
		get { return _spriteInfo; }	
	}
	
	public string SpriteName
	{
		get { return _spriteName; }	
	}
	
	public SpriteSheetInfo( Dictionary<string, SpriteRect> SpriteInfo, string SpriteName ) 
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
	
	//Retorna uma textura
	public Texture2D GetTexture() 
	{
		Texture2D texture = ( Texture2D ) Resources.Load( "Images/" + _spriteName );	
		return texture;
	}

}

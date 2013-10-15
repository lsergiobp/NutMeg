using UnityEngine;
using System.Collections;

/**
 * 
 * Classe que representa cada retangulo de uma sprite
 * 
**/

public class SpriteRect : MonoBehaviour {

	private int _x, _y, _w, _h;
	
	//Coordenada x
	public int x 
	{
		get { return _x; }
		set { _x = value; }
	}
	
	//Coordenada y
	public int y
	{
		get { return _y; }
		set { _y = value; }
	}
	
	//Largura
	public int w
	{
		get { return _w; }
		set { _w = value; }
	}
	
	//Altura
	public int h
	{
		get { return _h; }
		set { _h = value; }
	}
	
	//Construtor
	public SpriteRect( int x, int y, int w, int h ) 
	{
		_x = x;
		_y = y;
		_w = w;
		_h = h;
	}
	
	//Retorna a escala
	public Vector2 GetScale( Vector2 imageDimensions ) 
	{
		float x = _w / imageDimensions.x;
		float y = _h / imageDimensions.y;
		
		return new Vector2( x, y );
	}
	
	//Retorna o tamanho 
	public Vector2 GetOffset( Vector2 imageDimensions ) 
	{
		Vector2 scale = GetScale( imageDimensions );
		float x = _x / imageDimensions.x;
		float y = 1 - ( _y / imageDimensions.y + scale.y );
		
		return new Vector2( x, y );
	}
}

using UnityEngine;
using System.Collections;

public class SpriteRect : MonoBehaviour {

	private int _x, _y, _w, _h;
	
	public int x 
	{
		get { return _x; }
	}
	
	public SpriteRect( int x, int y, int w, int h ) 
	{
		_x = x;
		_y = y;
		_w = w;
		_h = h;
	}
}

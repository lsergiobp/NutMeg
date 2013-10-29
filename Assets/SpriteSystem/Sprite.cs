using UnityEngine;
using System.Collections;

public class Sprite : MonoBehaviour 
{
	
	private Texture2D _spriteTexture;
	private SpriteSheetInfo _spriteInfo;
	private float _interval;
	private bool _isPlaying;
	
	public Texture2D SpriteTexture
	{
		get { return _spriteTexture; }	
	}
	
	public SpriteSheetInfo SpriteInfo 
	{
		get { return _spriteInfo; }	
	}
	
	public float Interval 
	{
		get { return _interval; }
		set { _interval = value; }
	}
	
	public bool IsPlaying
	{
		get { return _isPlaying; }	
	}

	public enum PlayMode
	{
		Loop,
		Once,
		PingPong,
		WalkRight,
		WalkLeft
	}
	
	public void Create( SpriteSheetInfo SpriteInfo ) 
	{
		if( IsPlaying ) 
			Stop();	
	
		_spriteInfo = SpriteInfo;
		_spriteTexture = _spriteInfo.GetTexture();
	}
	
 	public void Play ( PlayMode playMode, float interval, bool forceStop = true ) 
	{
		_interval = interval;
		
		if( !forceStop ) 
		{
			switch( playMode )
			{
				case PlayMode.Loop:
					StartCoroutine("Loop");
					break;
				
				case PlayMode.Once:
					StartCoroutine("Once");
					break;
				
				case PlayMode.PingPong:
					StartCoroutine("PingPong");
					break;
				
				case PlayMode.WalkRight:
					StartCoroutine("WalkRight");
					break;
				
				case PlayMode.WalkLeft:
					StartCoroutine("WalkLeft");
					break;
			}
		} else {
			Stop();
			Play( playMode, interval, false );
		}
	}
	
	private IEnumerator Loop()
	{
		string[] spriteNames = _spriteInfo.GetSpriteNames();
		renderer.material.mainTexture = _spriteTexture;
		_isPlaying = true;
		
		while( true )
		{
			for( int i = 0; i < spriteNames.Length; i++)
			{
				SpriteRect rect = _spriteInfo.GetSprite( spriteNames[i] );
				Vector2 imageDimensions = new Vector2( _spriteTexture.width, _spriteTexture.height );
				renderer.material.mainTextureOffset = rect.GetOffset( imageDimensions );
				renderer.material.mainTextureScale = rect.GetScale( imageDimensions );
				yield return new WaitForSeconds( _interval );
			}
		}
	}
	
	private IEnumerator Once()
	{
		print("teste");
		string[] spriteNames = _spriteInfo.GetSpriteNames();
		renderer.material.mainTexture = _spriteTexture;
		_isPlaying = true;
		print("aeeee");
		for( int i = 0; i < spriteNames.Length; i++)
		{
			SpriteRect rect = _spriteInfo.GetSprite( spriteNames[i] );
			print(rect);
			Vector2 imageDimensions = new Vector2( _spriteTexture.width, _spriteTexture.height );
			renderer.material.mainTextureOffset = rect.GetOffset( imageDimensions );
			renderer.material.mainTextureScale = rect.GetScale( imageDimensions );
			yield return new WaitForSeconds( _interval );
		}
	}
	
	private IEnumerator PingPong()
	{
		string[] spriteNames = _spriteInfo.GetSpriteNames();
		renderer.material.mainTexture = _spriteTexture;
		_isPlaying = true;
		
		while( true )
		{
			for( int i = -( spriteNames.Length -1 ) ; i < spriteNames.Length - 1; i++)
			{
				SpriteRect rect = _spriteInfo.GetSprite( spriteNames[i] );
				Vector2 imageDimensions = new Vector2( _spriteTexture.width, _spriteTexture.height );
				renderer.material.mainTextureOffset = rect.GetOffset( imageDimensions );
				renderer.material.mainTextureScale = rect.GetScale( imageDimensions );
				yield return new WaitForSeconds( _interval );
			}
		}
	}
	
	private IEnumerator WalkRight()
	{
		string[] spriteNames = _spriteInfo.GetSpriteNames();
		renderer.material.mainTexture = _spriteTexture;
		_isPlaying = true;
		
		while( true )
		{
			for( int i = 0; i < spriteNames.Length; i++)
			{
				if( spriteNames[i].Equals("walkRight") || spriteNames[i].Equals("stopRight") )
				{
				SpriteRect rect = _spriteInfo.GetSprite( spriteNames[i] );
				Vector2 imageDimensions = new Vector2( _spriteTexture.width, _spriteTexture.height );
				renderer.material.mainTextureOffset = rect.GetOffset( imageDimensions );
				renderer.material.mainTextureScale = rect.GetScale( imageDimensions );
				yield return new WaitForSeconds( _interval );
				}
			}
		}
	}
	
	private IEnumerator WalkLeft()
	{
		string[] spriteNames = _spriteInfo.GetSpriteNames();
		renderer.material.mainTexture = _spriteTexture;
		_isPlaying = true;
		
		while( true )
		{
			for( int i = 0; i < spriteNames.Length; i++)
			{
				if( spriteNames[i].Equals("walkLeft") || spriteNames[i].Equals("stopLeft") )
				{
				SpriteRect rect = _spriteInfo.GetSprite( spriteNames[i] );
				Vector2 imageDimensions = new Vector2( _spriteTexture.width, _spriteTexture.height );
				renderer.material.mainTextureOffset = rect.GetOffset( imageDimensions );
				renderer.material.mainTextureScale = rect.GetScale( imageDimensions );
				yield return new WaitForSeconds( _interval );
				}
			}
		}
	}
	
	public void Stop()
	{
		_isPlaying = false;
		StopAllCoroutines();	
	}
	
	public void SetFrame( string name )
	{
		SpriteRect rect = _spriteInfo.GetSprite( name );
		Vector2 imgDimensions = new Vector2( _spriteTexture.width, _spriteTexture.height );
		renderer.material.mainTextureOffset = rect.GetOffset( imgDimensions );
		renderer.material.mainTextureScale = rect.GetScale( imgDimensions );
	}
}

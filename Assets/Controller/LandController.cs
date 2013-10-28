using UnityEngine;
using System.Collections;

public class LandController : MonoBehaviour {
	
	private Vector3 startPosition;
	private Vector3 nextPosition;
	private Vector3 flowerPosition;
	
	public Transform landPrefab;
	public Transform flowerPrefab;
	public Transform waterPrefab;

	void Start () 
	{
		nextPosition = landPrefab.localPosition;
		handleGameEvents();
		
		if( GameEventController.playNumber > 0 )
			instantiateObjects();	

		
	}
	
	void handleGameEvents()
	{
		GameEventController.GameStart += GameStart; 
		
	}
	
	void instantiateObjects()
	{
		if( Application.loadedLevelName.Equals( "nutmeg" ) )
		{
			instantiateLand( 25 );
			instantiateWater( 3 );
			instantiateLand( 10 );		
		}
		
		if( Application.loadedLevelName.Equals( "nutmeg2" ) )
		{
			instantiateLand( 10 );
			instantiateWater( 5 );
			instantiateLand( 15 );	
			instantiateWater( 2 );
			instantiateLand( 5 );	
		}
	}
	
	void GameStart() 
	{
		instantiateObjects();	
	}
	
	void instantiateLand( int numObjects )
	{
		for (int i = 0; i < numObjects; i++) 
		{
			
			Transform l = (Transform)Instantiate( landPrefab );
			l.localPosition = nextPosition;
			
			if( i != 0 && i % 5 == 0 && this.flowerPrefab != null )
			{
				flowerPosition = nextPosition;
				flowerPosition.y = -14.5f;
				Transform f = (Transform)Instantiate( flowerPrefab );
				f.localPosition = flowerPosition;
			}
			
			nextPosition.x += l.localScale.x * 10;
			
		}	
	}
	
	void instantiateWater( int numObjects )
	{
		for ( int i = 0; i < numObjects; i++ ) 
		{
			
			Transform w = (Transform)Instantiate( waterPrefab );
			nextPosition.x = nextPosition.x + 3.2f;
			w.localPosition = nextPosition;
			nextPosition.x += w.localScale.x * 10.0f - 3.2f;	
		
		}
	}	
	
}
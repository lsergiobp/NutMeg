using UnityEngine;
using System.Collections;

public class GenericController : MonoBehaviour {

	public Transform genericPrefab;
	
	void Start () {
		
		handleGameEvents();

		if( GameEventController.playNumber > 0 )
			instantiateObject();		
	}
	
	void instantiateObject()
	{
		Transform g = ( Transform ) Instantiate( genericPrefab );
		g.localPosition = transform.localPosition;
		
		if( g.name.Equals( "starPrefab(Clone)" ) ) 
		{
			PlayerController.totalStars++;
		}
	}
	
	void handleGameEvents()
	{
		GameEventController.GameStart += GameStart; 
		
	}
	
	void GameStart() 
	{
		instantiateObject();
	}
	
}

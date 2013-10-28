using UnityEngine;
using System.Collections;

public class GenericController : MonoBehaviour {

	public Transform genericPrefab;
	
	void Start () {
		
		handleGameEvents();
		
	}
	
	void handleGameEvents()
	{
		GameEventManager.GameStart += GameStart; 
		GameEventManager.GameOver += GameOver; 
	}
	
	void GameStart() 
	{
		enabled = true;
		Transform g = ( Transform ) Instantiate( genericPrefab );
		g.localPosition = transform.localPosition;
		
		if( g.name.Equals( "starPrefab(Clone)" ) ) 
		{
			PlayerController.totalStars++;
		}
	}
	
	void GameOver()
	{
		enabled = false;	
	}
	
}

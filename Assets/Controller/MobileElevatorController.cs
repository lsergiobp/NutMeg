using UnityEngine;
using System.Collections;

public class MobileElevatorController : MonoBehaviour {

	public Transform mobileElevatorPrefab;
	private Vector3 initialPosition;
	private Vector3 mobilePosition;
	private float limit;
	private bool up;
	private Transform m;
	
	void Start () {
		
		handleGameEvents();
		
		initialPosition = transform.localPosition;
		limit = initialPosition.y + 35.0f;
		up = true;

		if( GameEventController.playNumber > 0 )
			instantiateObject();		
	}
	
	void Update()
	{
		if ( m != null && m.localPosition.y >= limit )
			up = false;
		
		if ( m != null && m.localPosition.y <= initialPosition.y )
			up = true;
		
		if( m != null && up ) 
		{
			mobilePosition = m.localPosition;
			mobilePosition.y = mobilePosition.y + 0.2f;
			m.localPosition = mobilePosition;
		}
		
		else if( m != null && !up ) 
		{
			mobilePosition = m.localPosition;
			mobilePosition.y = mobilePosition.y - 0.2f;
			m.localPosition = mobilePosition;
		}
		
	}
	
	void instantiateObject()
	{
		m = ( Transform ) Instantiate( mobileElevatorPrefab );
		m.localPosition = initialPosition;
	
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
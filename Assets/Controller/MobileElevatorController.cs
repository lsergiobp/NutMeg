using UnityEngine;
using System.Collections;

public class MobileElevatorController : MonoBehaviour {

	private Vector3 initialPosition;
	private Vector3 mobilePosition;
	private float limit;
	private bool maxDistance = true;
	private Transform m;
	
	public Transform mobileElevatorPrefab;
	public bool vertical = true;
	public bool upOrRight = true;
	
	void Start () {
		
		handleGameEvents();
		
		initialPosition = transform.localPosition;
		if( upOrRight )
		{
			if( vertical )
			{
				limit = initialPosition.y + 35.0f;
			}
			else
			{
				limit = initialPosition.x + 35.0f;
			}		
		}
		else
		{
			if( vertical )
			{
				limit = initialPosition.y - 35.0f;
			}
			else
			{
				limit = initialPosition.x - 35.0f;
			}	
		}

		if( GameEventController.playNumber > 0 )
			instantiateObject();		
	}
	
	void Update()
	{
		if( vertical )
		{
			verticalMove();
		}
		else
		{
			horizontalMove();	
		}
	}
	
	void verticalMove()
	{
		if ( m != null && m.localPosition.y >= limit )
			maxDistance = false;
		
		if ( m != null && m.localPosition.y <= initialPosition.y )
			maxDistance = true;
		
		if( m != null && maxDistance && !GameEventController.paused ) 
		{
			mobilePosition = m.localPosition;
			mobilePosition.y = mobilePosition.y + 0.2f;
			m.localPosition = mobilePosition;
		}
		
		else if( m != null && !maxDistance && !GameEventController.paused ) 
		{
			mobilePosition = m.localPosition;
			mobilePosition.y = mobilePosition.y - 0.1f;
			m.localPosition = mobilePosition;
		}	
	}
	
	void horizontalMove()
	{
		if ( ( m != null && m.localPosition.x >= limit && upOrRight ) ||
				m != null && m.localPosition.x <= limit && !upOrRight)
			maxDistance = false;
		
		if ( ( m != null && m.localPosition.x <= initialPosition.x && upOrRight ) ||
				m != null && m.localPosition.x >= initialPosition.x && !upOrRight )
			maxDistance = true;
		
		if( m != null && maxDistance && !GameEventController.paused ) 
		{
			mobilePosition = m.localPosition;
			if( upOrRight )
			{
				mobilePosition.x = mobilePosition.x + 0.2f;
				m.name = "MobileRight";
			}
			else
			{
				mobilePosition.x = mobilePosition.x - 0.2f;
				m.name = "MobileLeft";
			}
			
			m.localPosition = mobilePosition;
		}
		
		else if( m != null && !maxDistance && !GameEventController.paused ) 
		{
			mobilePosition = m.localPosition;
			if( upOrRight )
			{
				mobilePosition.x = mobilePosition.x - 0.2f;
				m.name = "MobileLeft";		
			}
			else
			{
				mobilePosition.x = mobilePosition.x + 0.2f;
				m.name = "MobileRight";
			}
			
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
		GameEventController.GamePause += GamePause;
		
	}

	void GamePause()
	{
		if ( !GameEventController.paused )
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}
	
	void GameStart() 
	{
		instantiateObject();
	}
	
}
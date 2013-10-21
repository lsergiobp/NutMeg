using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private Vector3 initialPosition;
	private Vector3 playerPosition;
	
	void Start () {
		playerPosition = transform.localPosition;
	}
	
	void Update () {
		
		
		if( PlayerController.playerPosition.x  >= 10.0f )
		{
			playerPosition.x = PlayerController.playerPosition.x + 74.0f;
			transform.localPosition = playerPosition;	
		}
		
	}
}

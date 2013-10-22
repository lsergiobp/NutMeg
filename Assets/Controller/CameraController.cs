using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private Vector3 playerPosition;
	private float initialCameraPosition;
	private float initialPlayerPosition;
	
	public float finalPosition;
	
	void Start () {
		playerPosition = transform.localPosition;
		initialPlayerPosition = PlayerController.playerPosition.x * 2;
		initialCameraPosition = transform.localPosition.x - initialPlayerPosition;
	}
	
	void Update () {
		
		
		if( PlayerController.playerPosition.x  >= initialPlayerPosition &&  PlayerController.playerPosition.x  <= finalPosition )
		{
			playerPosition.x = PlayerController.playerPosition.x + initialCameraPosition;
			transform.localPosition = playerPosition;	
		}
		
	}
}

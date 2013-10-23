using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {
	
	public GUIText starsText;
		
	void Start () 
	{
		handleGameEvents();
		starsText.enabled = true;
	}

	void Update ()
	{
		updatePoints();
	}
	
	void updatePoints()
	{
		starsText.text = PlayerController.starsCollected + "/" + PlayerController.totalStars;
	}
	
	void handleGameEvents()
	{
		GameEventManager.GameStart += GameStart; 
		GameEventManager.GameOver += GameOver; 
	}
	
	void GameStart()
	{
		starsText.enabled = true;
	}
	
	void GameOver()
	{
		starsText.enabled = false;
	}	
	
	void OnGUI()
	{
		
	}
}

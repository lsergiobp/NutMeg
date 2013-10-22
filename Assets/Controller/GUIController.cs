using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {
	
	public GUIText starsText;
	
	void Start () 
	{
		handleGameEvents();
		this.starsText.enabled = false;
	}

	void Update ()
	{
	
	}
	
	void handleGameEvents()
	{
		GameEventManager.GameStart += GameStart; 
		GameEventManager.GameOver += GameOver; 
	}
	
	void GameStart()
	{
		this.starsText.enabled = true;
	}
	
	void GameOver()
	{
		this.starsText.enabled = false;
	}	
	
	void OnGUI()
	{
		
	}
}

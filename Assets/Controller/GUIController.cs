using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {
	
	public GUIText starsText;
	public GUITexture starTexture;
	public GUITexture nutMegTexture;
	public GUIText nutMegText;
			
	void Start () 
	{
		handleGameEvents();
	
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
		GameEventController.GameStart += GameStart; 
		GameEventController.GameOver += GameOver; 
	}
	
	void GameStart()
	{
		
	}
	
	void GameOver()	
	{
		Application.LoadLevel( Application.loadedLevel );
		GameEventController.playNumber++;
		PlayerController.starsCollected = 0;
		PlayerController.totalStars = 0;
	}	
	
	void OnGUI()
	{
		if ( GameEventController.playNumber > 0 )
		{
			starsText.enabled = true;
			starTexture.enabled = true;
			nutMegText.enabled = false;
			nutMegTexture.enabled = false;
		}
		
		else
		{
			starsText.enabled = false;
			starTexture.enabled = false;
			nutMegText.enabled = true;
			nutMegTexture.enabled = true;
		}
	}
}

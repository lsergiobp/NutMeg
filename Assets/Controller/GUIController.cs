using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {
	
	public GUIText starsText;
	public GUITexture starTexture;
	public GUITexture nutMegTexture;
	public GUIText nutMegText;
	public GUIText winText;
	private bool gameWin;
			
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
		GameEventController.GameWin += GameWin; 
		GameEventController.GameOver += GameOver; 
		GameEventController.GameStart += GameStart; 
	}
	
	void GameWin()
	{
		gameWin = true;
	}
	
	void GameStart()
	{
		gameWin = false;	
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
			winText.enabled = false;
		}
		
		else if ( GameEventController.playNumber == 0 && !gameWin )
		{
			starsText.enabled = false;
			starTexture.enabled = false;
			nutMegText.enabled = true;
			nutMegTexture.enabled = true;
			winText.enabled = false;
		}
		
		else if( gameWin )
		{
			starsText.enabled = false;
			starTexture.enabled = false;
			nutMegText.enabled = false;
			nutMegTexture.enabled = true;
			winText.enabled = true;
			
			if ( Input.GetKey( KeyCode.Return ) || Input.GetKey( KeyCode.KeypadEnter ) )
				Application.Quit();
		}
	}
}

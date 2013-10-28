using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {
	
	public GUIText starsText;
	public GUITexture starTexture;
	public GUITexture nutMegTexture;
	public GUIText nutMegText;
	public GUIText gameOverText;
		
	void Start () 
	{
		handleGameEvents();
		starsText.enabled = false;
		starTexture.enabled = false;
		nutMegText.enabled = true;
		nutMegTexture.enabled = true;
		gameOverText.enabled = false;
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
		starTexture.enabled = true;
		nutMegText.enabled = false;
		nutMegTexture.enabled = false;
		gameOverText.enabled = false;
	}
	
	void GameOver()
	{
		starsText.enabled = false;
		starTexture.enabled = false;
		nutMegText.enabled = true;
		nutMegTexture.enabled = true;
		gameOverText.enabled = true;
	}	
	
	void OnGUI()
	{
		
	}
}

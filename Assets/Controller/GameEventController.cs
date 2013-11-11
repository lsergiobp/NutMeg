public static class GameEventController {

	public delegate void GameEvent();

	public static event GameEvent GameStart, GameOver, GamePause;
	
	public static int playNumber = 0;
	
	public static bool paused = false;

	public static void TriggerGameStart(){
		if(GameStart != null){
			GameStart();
			playNumber++;
		}
	}

	public static void TriggerGameOver(){
		if(GameOver != null){
			GameOver();
		}
	}
	
	public static void TriggerGamePause()
	{
		if( GamePause != null ) 
		{
			GamePause();
			
			paused = !paused;
		}
	}
}
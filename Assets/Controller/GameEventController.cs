public static class GameEventController {

	public delegate void GameEvent();

	public static event GameEvent GameStart, GameOver;
	
	public static int playNumber = 0;

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
}
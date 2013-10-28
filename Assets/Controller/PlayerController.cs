using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private float gravityForce = 25f;	 //força da gravidade
	private float maxVelocityGravity = 20f;	//força maxima adquirida pela gravidade
	private float jumpSpeed = 20f; //Velocidade do pulo
	private float moveSpeed = 20f; //Velocidade de movimento
	private float intervalBetweenFrames = 0.2f;
	private bool turnRight;
		
	private Vector3 moveVector {get; set;} //Vetor de movimento
	private float verticalVelocity {get; set;} //Velocidade vertical
	private bool isPlaying;
	
	private CharacterController charController; //Controlador
	private Sprite sprite; //Sprite
	public static int starsCollected = 0; //Quantidade de estrelas ja coletadas
	public static int totalStars = 0; //Numero de estrelas na fase
	
	public float initialLimit; //Limite inicial da camera
	public float finalLimit; //Limite final da camera
	public static Vector3 playerPosition; //Posiçao do player
	
	// Metodo chamado antes de iniciar o jogo
	void Awake () 
	{
		charController = ( CharacterController ) gameObject.GetComponent("CharacterController");
		turnRight = true;
		playerPosition = transform.localPosition;
		charController.enabled = false;
	}
	
	// Metodo chamado ao iniciar o jogo
	void Start () 
	{
		initSprite(); // Inicializa as configuraçoes de sprite
		handleGameEvents(); //Inicializa os eventos do jogo
		renderer.enabled = false;
		isPlaying = false;
	}
	
	// Metodo que e chamado a cada frame
	void Update () 
	{
		playerPosition = transform.localPosition; //Captura a posiçao atual do player
		waitForMovement(); //Espera algum comando de movimento
		waitForJump(); //Espera algum comando de pulo
		
		if( charController.enabled )
			handleMovement(); //Realiza o movimento
		
		handleSprites(); //Gerencia a troca de sprites
		lockZAxis(); //Nao deixa o player se movimentar no eixo Z
		waitForGameOver(); //Verifica se o player perdeu
		waitForWin(); //Verifica se o player ja pegou todas as estrelas
		waitForGameStart(); //Espera apertar a tecla enter para começar o jogo
	}
	
	void handleGameEvents()
	{
		GameEventManager.GameStart += GameStart; 
		GameEventManager.GameOver += GameOver; 
	}
	
	void waitForGameStart()
	{
		if( Input.GetKeyDown( KeyCode.Return ) || Input.GetKeyDown( KeyCode.KeypadEnter ) )
			GameEventManager.TriggerGameStart();
	}
	
	void waitForMovement()
	{
		float deadZone = 0.1f;
		verticalVelocity = moveVector.y;
		moveVector = Vector3.zero;
		if( Input.GetAxis("Horizontal") > deadZone || Input.GetAxis("Horizontal") < -deadZone ){
			if ( ( playerPosition.x >= initialLimit && Input.GetKey( KeyCode.LeftArrow ) )
				|| ( playerPosition.x <= finalLimit && Input.GetKey( KeyCode.RightArrow ) ) )
			{
				moveVector += new Vector3( Input.GetAxis("Horizontal"),0,0 );
			}
		}
	}
	
	void handleSprites()
	{
		if( Input.GetKeyDown( KeyCode.RightArrow ) ) 
		{
			sprite.Play( Sprite.PlayMode.WalkRight, intervalBetweenFrames );
			turnRight = true;
		}
		
		if( Input.GetKeyUp( KeyCode.RightArrow ) ) 
		{
			sprite.Stop();
			sprite.SetFrame( "stopRight" );
		}
		
		if( Input.GetKeyDown( KeyCode.LeftArrow ) ) 
		{
			turnRight = false;
			sprite.Play( Sprite.PlayMode.WalkLeft, intervalBetweenFrames );
		}
		
		if( Input.GetKeyUp( KeyCode.LeftArrow ) ) 
		{
			sprite.Stop();
			sprite.SetFrame( "stopLeft" );
		}
		
	}
	
	void waitForJump(){
		//Se apertar a tecla espaço
		if( Input.GetButton( "Jump" ) )
		{
			jump();
		}
	}
	
	void handleMovement()
	{
		moveVector = transform.TransformDirection( moveVector );
		
		//Normaliza o vetor para tamanho 1
		if( moveVector.magnitude > 1 )
		{
			moveVector = Vector3.Normalize( moveVector );
		}

		moveVector *= moveSpeed;
		
		//Reaplica a velocidade vertical
		moveVector = new Vector3(-moveVector.x, verticalVelocity, moveVector.z);
		
		//Aplica gravidade
		applyGravity();
		
		//Movimenta o player pelo world-space
		charController.Move(moveVector * Time.deltaTime);
	}
	
	void applyGravity()
	{
		//Nao deixa passar da velocidade maxima vertical
		if(moveVector.y > -maxVelocityGravity)
		{
			moveVector = new Vector3( moveVector.x, ( moveVector.y - gravityForce * Time.deltaTime ) ,moveVector.z );
		}
		//Se tocar no chao, volta pra velocidade vertical de começo
		if( charController.isGrounded && moveVector.y < -1 )
		{
			moveVector = new Vector3(moveVector.x, (-1), moveVector.z);
		}
	}
	
	//Metodo que, caso esteja tocando no chao, faz o player pular
	public void jump()
	{
		if(charController.isGrounded)
		{
			verticalVelocity = jumpSpeed;
			
			if( turnRight ) 
			{
				sprite.SetFrame( "jumpRight" );
			}
			else if ( !turnRight )
			{
				sprite.SetFrame( "jumpLeft" );
			}
		}
	}
	
	//Metodo que inicializa com a sprite parado
	void initSprite()
	{
		sprite = GetComponent<Sprite>();
		sprite.Create( SpriteSet.GetSprite( "Player" ) );
		sprite.SetFrame( "stopRight" );
	}
	
	void lockZAxis() 
	{
		Vector3 pos = transform.position;
     	pos.z = 0;
     	transform.position = pos;	
	}
	
	void waitForGameOver()
	{
		if( playerPosition.y < -35 ) 
		{
			GameEventManager.TriggerGameOver();
		}
	}
	
	void waitForWin()
	{
		if( starsCollected == totalStars && isPlaying )
		{
			Application.LoadLevel("nutmeg");	
		}
	}
	
	void GameStart()
	{
		
		renderer.enabled = true;
		charController.enabled = true;
		isPlaying = true;
	}
	
	void GameOver()
	{
		
		renderer.enabled = false;
		charController.enabled = false;
		isPlaying = false;

	}
	
	void OnTriggerEnter( Collider collider )
	{

		if( collider.gameObject.name.Equals( "starPrefab(Clone)" ) )
		{
			Destroy( collider.gameObject );
			starsCollected++;
		}
	}

}
using TMPro;

using UnityEngine;
public class GameManager : Singleton<GameManager>
{
	#region SERIALIZED_FIELDS
	public static GameManager instance;
	// UI CANVAS VARIABLES
	[SerializeField] GameObject titleUI;
	[SerializeField] GameObject hudUI;
	[SerializeField] GameObject tutorialUI;
	[SerializeField] GameObject deathUI;
	[SerializeField] GameObject victoryUI;

	// UI VALUE VARIABLES
	[SerializeField] public TMP_Text timerUI;
	[SerializeField] TMP_Text pointsUI;

	// EVENTS
	[Header("Events")]
	[SerializeField] IntEvent scoreEvent;
	[SerializeField] VoidEvent gameStartState;
	#endregion
	#region VARIALBES
	public enum State
	{
		TITLE,
		TUTORIAL,
		MAIN_SETUP,
		MAIN_GAME,
		VICTORY,
		GAME_OVER
	}
	public State state = State.TITLE;
	public float timer = 0;
	public int points = 0;
	public int Points
	{
		get { return points; }
		set { points = value; pointsUI.text = "Points: " + points.ToString(); }
	}
	public float Timer
	{
		get { return timer; }
		set { timer = value; timerUI.text = "Timer: " + $"{Mathf.Floor(timer)}s"; }
	}
	#endregion
	#region EVENT_METHODS
	private void OnEnable()
	{
		scoreEvent.Subscribe(OnAddPoints);
	}
	private void OnDisable()
	{
		scoreEvent.UnSubscribe(OnAddPoints);
	}
	void Start()
	{
		scoreEvent.Subscribe(OnAddPoints);
	}
	#endregion

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha3)) Timer = 4;

		switch (state)
		{
			case State.TITLE:
				OnTitleScreen();
				break;
			case State.TUTORIAL:
				//OnTutorialScreen();
				break;
			case State.MAIN_SETUP:
				state = State.MAIN_GAME;
				break;
			case State.MAIN_GAME:
				OnMainGame();
				break;
			case State.VICTORY:
				OnVictory();
				break;
			case State.GAME_OVER:
				OnEndGame();
				break;
		}
		//healthUI.value = health.value / 100.0f;
	}
	#region ONEVENT_METHODS
	public void OnTitleScreen()
	{
		titleUI.SetActive(true);

		hudUI.SetActive(false);
		deathUI.SetActive(false);
		tutorialUI.SetActive(false);
		victoryUI?.SetActive(false);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
	public void OnTutorialScreen()
	{
		state = State.TUTORIAL;
		tutorialUI?.SetActive(true);

		titleUI?.SetActive(false);
		hudUI?.SetActive(false);
		deathUI?.SetActive(false);
		victoryUI?.SetActive(false);

	}
	public void OnVictory()
	{
		victoryUI?.SetActive(true);

		hudUI?.SetActive(false);
		titleUI?.SetActive(false);
		deathUI?.SetActive(false);
		tutorialUI.SetActive(false);
	}
	public void OnStartGame()
	{
		hudUI.SetActive(true);

		titleUI.SetActive(false);
		deathUI.SetActive(false);
		tutorialUI?.SetActive(false);
		victoryUI?.SetActive(false);
		Timer = 60;
		//Lives = 3;

		state = State.MAIN_SETUP;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	public void OnMainGame()
	{
		Timer -= Time.deltaTime;
		if (Timer <= 1)
		{
			Timer = 0;
			state = State.GAME_OVER;
		}

	}
	public void StartEnd()
	{
		state = State.GAME_OVER;
	}
	public void OnWin()
	{
		state = State.VICTORY;
	}
	public void OnEndGame()
	{
		deathUI?.SetActive(true);

		tutorialUI.SetActive(false);
		titleUI?.SetActive(false);
		hudUI?.SetActive(false);
		victoryUI?.SetActive(false);

		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
	public void OnAddPoints(int points)
	{
		Points += points;
		print(points);
	}
	public void OnQuitButton()
	{
		Application.Quit();
	}
	#endregion
	#region SCRAPPED_CODE
	//[SerializeField] Slider healthUI;
	//[SerializeField] TMP_Text livesUI;
	//[SerializeField] FloatVariable health;
	//public int lives = 0;
	//public int Lives
	//{
	//	get { return lives; }
	//	set { lives = value; livesUI.text = "Lives: " + lives.ToString(); }
	//}
	#endregion
}
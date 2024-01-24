using TMPro;

using UnityEngine;
public class GameManager : Singleton<GameManager>
{
	// UI CANVAS VARIABLES
	[SerializeField] GameObject titleUI;
	[SerializeField] GameObject hudUI;
	[SerializeField] GameObject tutorialUI;
	[SerializeField] GameObject deathUI;

	// UI VALUE VARIABLES
	[SerializeField] TMP_Text timerUI;
	[SerializeField] TMP_Text pointsUI;

	// EVENTS
	[Header("Events")]
	[SerializeField] IntEvent scoreEvent;
	[SerializeField] VoidEvent gameStartState;

	public enum State
	{
		TITLE,
		TUTORIAL,
		MAIN_SETUP,
		MAIN_GAME,
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


	void Update()
	{
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
			case State.GAME_OVER:
				OnEndGame();
				break;
		}
		//healthUI.value = health.value / 100.0f;
	}
	public void OnTitleScreen()
	{
		titleUI.SetActive(true);

		hudUI.SetActive(false);
		deathUI.SetActive(false);
		tutorialUI.SetActive(false);
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

	}
	public void OnStartGame()
	{
		hudUI.SetActive(true);

		titleUI.SetActive(false);
		deathUI.SetActive(false);
		tutorialUI?.SetActive(false);
		Timer = 60;
		//Lives = 3;

		state = State.MAIN_SETUP;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	public void OnMainGame()
	{
		Timer -= Time.deltaTime;
		if (Timer <= 0)
		{
			Timer = 0;
			state = State.GAME_OVER;
		}

	}
	public void OnEndGame()
	{
		deathUI?.SetActive(true);

		tutorialUI.SetActive(false);
		titleUI?.SetActive(false);
		hudUI?.SetActive(false);

		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
	public void OnAddPoints(int points)
	{
		Points += points;
		print(points);
	}
	//[SerializeField] Slider healthUI;
	//[SerializeField] TMP_Text livesUI;
	//[SerializeField] FloatVariable health;
	//public int lives = 0;
	//public int Lives
	//{
	//	get { return lives; }
	//	set { lives = value; livesUI.text = "Lives: " + lives.ToString(); }
	//}
}
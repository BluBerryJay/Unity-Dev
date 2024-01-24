using TMPro;

using UnityEngine;
using UnityEngine.UI;
public class GameManager : Singleton<GameManager>
{
	[SerializeField] GameObject titleUI;
	[SerializeField] GameObject hudUI;
	[SerializeField] TMP_Text livesUI;
	[SerializeField] TMP_Text timerUI;
	[SerializeField] Slider healthUI;

	[SerializeField] FloatVariable health;
	[Header("Events")]
	[SerializeField] IntEvent scoreEvent;
	[SerializeField] VoidEvent gameStartState;

	public enum State
	{
		TITLE,
		MAIN_SETUP,
		MAIN_GAME,
		GAME_OVER
	}
	public State state = State.TITLE;
	public float timer = 0;
	public int lives = 0;
	public int Lives
	{
		get { return lives; }
		set { lives = value; livesUI.text = "Lives: " + lives.ToString(); }
	}
	public float Timer
	{
		get { return timer; }
		set { timer = value; timerUI.text = "Timer: " + string.Format("{0:F2}", timer.ToString()); }
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
			case State.MAIN_SETUP:


				state = State.MAIN_GAME;
				break;
			case State.MAIN_GAME:
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				break;
			case State.GAME_OVER:
				break;
		}
		healthUI.value = health.value / 100.0f;
	}
	public void OnTitleScreen()
	{
		titleUI.SetActive(true);
		hudUI.SetActive(false);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
	public void OnStartGame()
	{
		titleUI.SetActive(false);
		hudUI.SetActive(true);
		timer = 60;
		Lives = 3;
		state = State.MAIN_GAME;
	}
	public void OnMainGame()
	{
		Timer -= Time.deltaTime;
		if (Timer < 0) Timer = 0; state = State.GAME_OVER;
	}
	public void OnAddPoints(int points)
	{
		print(points);
	}
}
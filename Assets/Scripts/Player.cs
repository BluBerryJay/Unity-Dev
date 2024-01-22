using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] TMP_Text scoreText;
	[SerializeField] FloatVariable health;
	[Header("Events")]
	[SerializeField] IntEvent scoreEvent = default;

	private int score = 0;

	public int Score
	{
		get { return score; }
		set { score = value; scoreText.text = score.ToString(); scoreEvent.RaiseEvent(score); }
	}
	public void Start()
	{
		health.value = 50;
	}
	public void AddPoints(int points)
	{
		Score += points;
	}
}
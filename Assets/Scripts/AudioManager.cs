using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public GameObject player = null;
	[SerializeField] AudioSource audioCoin;
	[SerializeField] AudioSource audioClock;
	public static AudioManager instance;
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
	void Start()
	{

	}
	public void PlayClock()
	{
		audioClock.Play();
	}
	public void PlayCoin()
	{
		audioCoin.Play();
	}
	// Update is called once per frame
	void Update()
	{
		gameObject.transform.position = player.transform.position;
	}
}

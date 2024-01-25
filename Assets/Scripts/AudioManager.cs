using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public GameObject player = null;
	[SerializeField] public AudioSource audioCoin = null;
	[SerializeField] public AudioSource audioClock = null;
	
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
	public bool inRange(float min, float max, float value)
	{
		if (value >= min && value <= max)
		{
			return true;
		}
		return false;
	}
	bool threeSec = false;
	bool whiteText = true;
	// Update is called once per frame
	void Update()
	{
		
		if (inRange(0.01f, 4f, GameManager.instance.Timer) && !threeSec && whiteText)
		{
            GameManager.instance.timerUI.color = Color.red;
			PlayClock();
			threeSec = true;
			whiteText = false;

        }
		else if (GameManager.instance.Timer >= 4 && !whiteText)
		{
            GameManager.instance.timerUI.color = Color.white;
			whiteText = true;
			threeSec = false;
			audioClock.Stop();
        }
		
    }
	
}

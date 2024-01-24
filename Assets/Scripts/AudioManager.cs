using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public GameObject player = null;
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		gameObject.transform.position = player.transform.position;
	}
}

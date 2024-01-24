using UnityEngine;

public class Pickup : MonoBehaviour
{


	[SerializeField][Range(1f, 5f)] float speed = 1f;
	public AudioSource audioSource = null;
	Vector3 liftPos = Vector3.zero;

	private void Start()
	{
		if (audioSource == null)
		{
			audioSource = GetComponent<AudioSource>();
		}


		// Ensure that the audio clip is assigned to the AudioSource
		if (audioSource.clip == null)
		{
			Debug.LogError("Audio clip is not assigned to the AudioSource.");
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		liftPos = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);
		float step = speed * Time.deltaTime;
		if (other.gameObject.CompareTag("Player"))
		{
			if (gameObject.CompareTag("Clock"))
			{
				GameManager.instance.Timer += 5;

			}
			else if (gameObject.CompareTag("Coin"))
			{
				GameManager.instance.Points += 10;

			}
			transform.position = Vector3.MoveTowards(transform.position, liftPos, step);
			audioSource.PlayOneShot(audioSource.clip);
			Invoke("DestroyGameObject", audioSource.clip.length);
		}
		print(other.gameObject.name);

	}
	void DestroyGameObject()
	{

		gameObject.SetActive(false);
	}



}

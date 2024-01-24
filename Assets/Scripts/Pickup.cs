using UnityEngine;

public class Pickup : MonoBehaviour
{
	[SerializeField] GameObject pickupPrefab = null;
	[SerializeField] AudioSource audioSource = null;

	// Start is called before the first frame update
	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		pickupPrefab = GetComponent<GameObject>();
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (pickupPrefab.gameObject.tag == "Player" && audioSource.clip != null)
		{
			audioSource.Play();
			Destroy(gameObject);
		}
		print(collision.gameObject.name);
	}

}

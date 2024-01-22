using UnityEngine;

public class Pickup : MonoBehaviour
{
	[SerializeField] GameObject pickupPrefab = null;
	// Start is called before the first frame update

	private void OnCollisionEnter(Collision collision)
	{
		print(collision.gameObject.name);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent(out Player player))
		{
			//var player = other.gameObject.GetComponent<Player>();
			player.AddPoints(10);
		}


		print(other.gameObject.name);
		Instantiate(pickupPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}

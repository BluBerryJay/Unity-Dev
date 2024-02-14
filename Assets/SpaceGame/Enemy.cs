using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
	public float health;
	public int points;
	public IntEvent scoreEvent;
	public GameObject hitPrefab;
	public GameObject destroyPrefab;
	public void ApplyDamage(float damage)
	{
		health -= damage;
		if (health <= 0)
		{
			scoreEvent?.RaiseEvent(points);
			if (destroyPrefab != null) Instantiate(destroyPrefab, gameObject.transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
		else
		{
			if (hitPrefab != null) Instantiate(hitPrefab, gameObject.transform.position, Quaternion.identity);
			Destroy(gameObject);
		}

	}




}

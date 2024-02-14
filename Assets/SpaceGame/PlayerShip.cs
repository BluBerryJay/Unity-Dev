using System;
using UnityEngine;

public class PlayerShip : MonoBehaviour, IDamagable
{
	[SerializeField] private Action action;
	[SerializeField] private Inventory inventory;
	[SerializeField] private GameObject target;
	[SerializeField] public FloatVariable score;
	[SerializeField] private IntEvent scoreEvent;

	public GameObject hitPrefab;
	public GameObject destroyPrefab;

	FloatVariable health;
	// Update is called once per frame
	private void Start()
	{
		scoreEvent.Subscribe(AddPoints);
		health.value = 100;
		//scoreEvent.Subscribe(AddPoints(score.value));
		//if (action != null)
		//{
		//	//action.onEnter += OnInteractStart;
		//	//action.onStay += OnInteractActive;
		//}
	}
	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			inventory.Use();
		}
		if (Input.GetButtonUp("Fire1"))
		{
			inventory.StopUse();
		}
	}
	public void AddPoints(int points)
	{
		score.value += points;
		Debug.Log(score);
	}

	public void OnEnter()
	{

	}

	public void OnExit()
	{

	}

	public void ApplyDamage(float damage)
	{
		health.value -= damage;
		if (health.value <= 0)
		{

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

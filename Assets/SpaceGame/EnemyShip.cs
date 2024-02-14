
using System.Collections;
using UnityEngine;

public class EnemyShip : Enemy
{

	public Weapon weapon;
	public float minFireRate;
	public float maxFireRate;
	private void Start()
	{
		weapon.Equip();
		StartCoroutine(FireTimerCR());
	}
	IEnumerator FireTimerCR()
	{
		while (true)
		{
			float time = Random.Range(minFireRate, maxFireRate);
			yield return new WaitForSeconds(time);
			weapon.Use();
		}

	}
}

using System;
using UnityEngine;

public class Pickup : MonoBehaviour
{


	//[SerializeField][Range(1f, 5f)] float speed = 1f;
	public static Pickup instance;
	//Vector3 liftPos = Vector3.zero;

	[NonSerialized] public Vector3 origin = Vector3.zero;
	
	private void Start()
	{
		origin = transform.position;
		
	}
	private void OnTriggerEnter(Collider other)
	{
		//liftPos = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);
		//float step = speed * Time.deltaTime;
		if (other.gameObject.CompareTag("Player"))
		{
			if (gameObject.CompareTag("Clock"))
			{
				GameManager.instance.Timer += 5;
				AudioManager.instance.PlayClock();
                ParticleManager.instance.PlayAtPos(origin);

            }
			else if (gameObject.CompareTag("Coin"))
			{
				GameManager.instance.Points += 10;
				AudioManager.instance.PlayCoin();
				ParticleManager.instance.PlayAtPos(origin);

            }
			//transform.position = Vector3.MoveTowards(transform.position, liftPos, step);

			DestroyGameObject();
		}
		print(other.gameObject.name);

	}
	void DestroyGameObject()
	{

		gameObject.SetActive(false);
	}



}

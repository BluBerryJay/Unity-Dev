using System.Collections;
using UnityEngine;

public class COR : MonoBehaviour
{
	[SerializeField] float time = 3;
	[SerializeField] bool go = false;
	Coroutine timerCoroutine;
	void Start()
	{
		//timerCoroutine = StartCoroutine(StoryTime());
		//StartCoroutine(Timer(time));
		//StartCoroutine("StoryTime");
		StartCoroutine("Action");
	}

	// Update is called once per frame
	void Update()
	{
		//time -= Time.deltaTime;
		//if (time < 0)
		//{
		//	time = 3;
		//	print("Bababooey");
		//}
	}
	IEnumerator Timer(float time)
	{
		while (true)
		{
			yield return new WaitForSeconds(time);
			print("baba i am baba");
		}


		//yield return null;
	}
	IEnumerator StoryTime()
	{

		print("Hello");
		yield return new WaitForSeconds(1);
		print("What");
		yield return new WaitForSeconds(1);
		print("Good bye!");
		yield return new WaitForSeconds(1);
		StopCoroutine("StoryTime");
		yield return null;
	}
	IEnumerator Action()
	{
		yield return new WaitUntil(() => go);
		print("go");
		yield return null;
	}
}

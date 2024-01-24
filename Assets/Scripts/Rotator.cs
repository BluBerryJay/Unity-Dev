using UnityEngine;

public class Rotator : MonoBehaviour
{
	[SerializeField]
	[Range(-360, 360)] float angle = 60;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.rotation *= Quaternion.AngleAxis(angle * Time.deltaTime, Vector3.up);
	}
}

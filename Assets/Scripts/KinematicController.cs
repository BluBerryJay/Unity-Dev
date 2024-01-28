using UnityEngine;

public class KinematicController : MonoBehaviour
{
	[SerializeField, Range(0, 40)]
	float speed = 1.0f;
	[SerializeField] float maxDistance = 5;

	void Update()
	{
		float distance = transform.localPosition.magnitude;
		if (distance > maxDistance)
		{
			return;
		}
		Vector3 direction = Vector3.zero;
		direction.x = Input.GetAxis("Horizontal");
		direction.y = Input.GetAxis("Vertical");
		Vector3 force = direction * speed * Time.deltaTime;
		transform.localPosition += force;
		transform.localPosition = Vector3.ClampMagnitude(transform.localPosition, maxDistance);
	}
}

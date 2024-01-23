using UnityEngine;


public class OrbitCamera : MonoBehaviour
{
	[SerializeField] Transform target = null;
	[SerializeField]
	[Range(20f, 90f)] float defaultPitch = 40f;
	[SerializeField]
	[Range(0.001f, 2f)]
	float sensitivy = 1.0f;
	[SerializeField]
	[Range(0.1f, 2f)] float collOffset;
	[SerializeField]
	[Range(1f, 10f)] float smoothSpeed;
	float yaw = 0;
	float pitch = 0;
	RaycastHit hit;
	Vector3 offDir = Vector3.zero;
	void Start()
	{
		offDir = target.position - transform.position;
		pitch = defaultPitch;

	}

	// Citation: Chat GPT for wall detection and adjustion
	void Update()
	{

		yaw += Input.GetAxis("Mouse X") * sensitivy;
		pitch += Input.GetAxis("Mouse Y") * sensitivy;
		Quaternion qyaw = Quaternion.AngleAxis(yaw, Vector3.up);
		Quaternion qpitch = Quaternion.AngleAxis(pitch, Vector3.right);
		Quaternion rotation = qyaw * qpitch;
		Vector3 desiredPosition = target.position + (qpitch * Vector3.back * 5);
		RaycastHit hit;
		Vector3 offDir = desiredPosition - target.position;

		if (Physics.Raycast(target.position, offDir, out hit, offDir.magnitude))
		{
			// Adjust the position if there is an obstacle
			Vector3 newPos = hit.point + hit.normal * collOffset;
			transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed * Time.deltaTime);
		}
		else
		{
			// Smoothly interpolate to the desired position if no obstacle
			transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		}

		transform.rotation = rotation;
		transform.LookAt(target);
	}
}

using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PhysicsCharacterController : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField]
	[Range(1f, 10f)]
	float maxForce;
	[SerializeField]
	[Range(1f, 5f)]
	float maxJump;
	[SerializeField]
	Transform view;

	[Header("Collision")]
	[SerializeField][Range(0, 5)] float rayLength = 1;
	[SerializeField] LayerMask groundLayerMask;

	Rigidbody rb;
	Vector3 force = Vector3.zero;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 direction = Vector3.zero;
		direction.x = Input.GetAxis("Horizontal");
		direction.z = Input.GetAxis("Vertical");
		Quaternion yrotation = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up);
		force = yrotation * direction * maxForce;

		Debug.DrawRay(transform.position, Vector3.down * rayLength);
		if (Input.GetButtonDown("Jump") && checkGround())
		{
			rb.AddForce(Vector3.up * maxJump, ForceMode.Impulse);
			
		}

	}
	private void FixedUpdate()
	{
		rb.AddForce(force, ForceMode.Force);
	}
	private bool checkGround()
	{
		return Physics.Raycast(transform.position, Vector3.down, rayLength, groundLayerMask);
	}
}

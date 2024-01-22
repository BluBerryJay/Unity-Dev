using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] Transform target = null;
    [SerializeField]
    [Range(20f, 90f)] float defaultPitch = 40f;
    [SerializeField]
    [Range(0.001f, 2f)]
    float sensitivy = 1.0f;
    float yaw = 0;
    float pitch = 0;
    void Start()
    {
        pitch = defaultPitch;
    }

    // Update is called once per frame
    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivy;
        pitch += Input.GetAxis("Mouse Y") * sensitivy;

        Quaternion qyaw = Quaternion.AngleAxis(yaw, Vector3.up);
        Quaternion qpitch = Quaternion.AngleAxis(pitch, Vector3.right);
        Quaternion rotation = qyaw * qpitch;
        transform.position = target.position + (qpitch * Vector3.back * 5);
        transform.rotation = rotation;
    }
}

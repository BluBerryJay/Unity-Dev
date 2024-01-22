using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baller : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField][Range(1, 20)][Tooltip("Force to move object.")] float force;

    Rigidbody rb;
    
    private void Awake() 
    {
        print("awake");
    }
    // Start is called before the first frame update
    void Start()
    {
        print("start");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.AddForce(Vector3.up * force, ForceMode.VelocityChange);
        }
    }
}

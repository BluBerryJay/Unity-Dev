using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    // Citation Chat GPT for collision elevator
    [SerializeField]
    [Range(1f, 5f)] float speed;

    [SerializeField]
    [Range(1f, 20f)] float maxHeight;
    private bool hasCollided = false;
    private bool hasLeft = false;
    
    Vector3 origin = Vector3.zero;
    Vector3 tarPos = Vector3.zero;
    // Start is called before the first frame update
    private void Update()
    {
        if (hasCollided) {
            MoveToPosition();
        }
        else if (hasLeft)
        {
            ResetPosition();
        }
        
    }
    void Start()
    {
        origin = transform.position;
        tarPos = new Vector3(transform.position.x, transform.position.y + maxHeight, transform.position.z);

    }
    private void MoveToPosition()
    {
        float step = speed * Time.deltaTime;
        
        transform.position = Vector3.MoveTowards(transform.position, tarPos, step);
        if (transform.position.y >= tarPos.y) 
        {
            hasCollided = false;
        }
    }
    private void ResetPosition()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, origin, step);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasCollided)
        {
            hasCollided = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        hasLeft = true;  
    }


}

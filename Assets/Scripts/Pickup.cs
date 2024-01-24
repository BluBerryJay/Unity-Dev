using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class Pickup : MonoBehaviour
{
	

    public AudioSource audioSource = null;
    [SerializeField][Range(1f, 5f)] float speed;
    Vector3 liftPos = Vector3.zero;
    // Start is called before the first frame update
    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Ensure that the audio clip is assigned to the AudioSource
        if (audioSource.clip == null)
        {
            Debug.LogError("Audio clip is not assigned to the AudioSource.");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        liftPos = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);
        float step = speed * Time.deltaTime;
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(audioSource.clip);
            transform.position = Vector3.MoveTowards(transform.position, liftPos, step);
            
            Invoke("DestroyGameObject", audioSource.clip.length);
        }
        print(other.gameObject.name);
       
    }
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    


}

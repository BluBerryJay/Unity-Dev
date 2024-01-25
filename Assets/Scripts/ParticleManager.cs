using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ParticleManager instance;
    public ParticleSystem partSys;
    // Update is called once per frame
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayAtPos(Vector3 position)
    {
        
        transform.position = position;

     
        partSys.Play();
    }
}

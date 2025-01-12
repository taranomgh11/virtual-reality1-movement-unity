using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider other)  
    {  
        if (other.CompareTag("Player")) 
        {  
            
            Vector3 newDirection = new Vector3(-other.transform.forward.x, 0, -other.transform.forward.z).normalized;
            other.transform.position += newDirection * 2;  
        }  
    }  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

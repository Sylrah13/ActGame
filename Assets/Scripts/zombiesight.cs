using UnityEngine;

public class zombiesight : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        { 
            transform.parent.GetComponent<zombiemove>().zombieState = zombiemove.zombie.chase;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(transform.parent.GetComponent<zombiemove>().zombieState == zombiemove.zombie.chase)
        {
            if (other.gameObject.name == "Player")
            {
                transform.parent.GetComponent<zombiemove>().zombieState = zombiemove.zombie.wait;
            }
        }
    }
}

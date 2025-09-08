using UnityEngine;

public class anitest : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            GetComponent<Animator>().SetInteger("next", 22);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            GetComponent<Animator>().SetInteger("next", 11);
        }
    }
}

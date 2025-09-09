using UnityEngine;

public class zombiemove : MonoBehaviour
{
    //public int zombieState = 0;  //0 - x, 1 - ���, 2 - Ÿ��, 3 - �̵�
   
    public Vector3 tartgetPOS = Vector3.zero; //Ÿ�� ��ǥ
    public float moveSpeed = 0.0f; //�̵� ��

    public float randomPosX = 0.0f; //Ÿ�� ��ǥ ���� �� x
    public float randomPosZ = 0.0f; //Ÿ�� ��ǥ ���� �� z
    public float valuePosX = 0.0f; // �̵� ���� ���� �� x
    public float valuePosZ = 0.0f; // �̵� ���� ���� �� z

    public float timeCheck = 0.0f; // Ÿ�̸� �� �ð� ��
    public float waitTime = 0.0f; // ��� �ð� �� 
    
    public float distance = 0.0f;
    public enum zombie
    {
        none, wait, targeting, patrol, chase, attack,
    }
    public zombie zombieState = zombie.none;
    
    void Start()
    {
        
    }

    void Update()
    {
        //distance = Vector3.Distance(��ǥ1, ��ǥ2);
        //distance = Vector3.Distance(transform.position, GameObject.Find("Player").transform.position);
        /*
        switch (����)
        {
            case �񱳰�
        }*/
        switch (zombieState)
        {
            case zombie.none:
                //�ƹ���� ����
                break;
            case zombie.wait:
                Wait();
                break;
            case zombie.targeting:
                Targeting();
                break;
            case zombie.patrol:
                Patrol();
                break;
            case zombie.chase:
                Chase();
                break;
            case zombie.attack:
                Attack();
            break;
        }
    }

    void Wait()
    {
        GetComponent<Animator>().SetBool("walk", false);
        GetComponent<Animator>().SetBool("run", false);

        timeCheck = timeCheck + Time.deltaTime;
        if (timeCheck > waitTime)
        {
            zombieState = zombie.targeting;
            timeCheck = 0.0f;
        }
    }

    void Targeting()
    {
        randomPosX = Random.Range(-valuePosX, valuePosX);
        randomPosZ = Random.Range(-valuePosZ, valuePosZ);

        tartgetPOS = new Vector3(randomPosX, transform.position.y, randomPosZ);
        
        zombieState = zombie.patrol;
    }
    void Patrol()
    {
        moveSpeed = 1.0f;

        GetComponent<Animator>().SetBool("walk", true);

        transform.position = Vector3.MoveTowards(transform.position, tartgetPOS, moveSpeed * Time.deltaTime);
        transform.LookAt(tartgetPOS);
        
        distance = Vector3.Distance(transform.position, tartgetPOS);
        if (distance <= 0.5f)
        {
            zombieState = zombie.wait;
        }
    }

    void Chase()
    {
        moveSpeed = 3.0f;

        GetComponent<Animator>().SetBool("run", true);
        GetComponent<Animator>().SetBool("attack", false);

        tartgetPOS = GameObject.Find("Player").transform.position;
        transform.position = Vector3.MoveTowards(transform.position, tartgetPOS, moveSpeed * Time.deltaTime);
        transform.LookAt(tartgetPOS);

        distance = Vector3.Distance(transform.position, tartgetPOS);
        if(distance <= 1.0f)
        {
            zombieState = zombie.attack;
        }
    }

    void Attack()
    {
        GetComponent<Animator>().SetBool("run", false);
        GetComponent<Animator>().SetBool("attack", true);

        tartgetPOS = GameObject.Find("Player").transform.position;
        transform.LookAt(tartgetPOS);

        distance = Vector3.Distance(transform.position, tartgetPOS);
        if (distance >= 2.0f)
        {
            zombieState = zombie.chase;
        }
    }
}

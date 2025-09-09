using UnityEngine;

public class playermove : MonoBehaviour
{
    public float moveSpeed = 0.0f;
    public float hMove = 0.0f;
    public float vMove = 0.0f;
    public float attack = 0.0f;
    
    public int charState = 0;
    public bool attackANi = false;

    public float spinSpeed = 0.0f;
    public float mouseX = 0.0f;
    void Start()
    {
        
    }

    void Update()
    {
        Keyinput();
        Move();
        AniSetting();

        //Debug.Log(Input.mousePosition);
    }

    void Keyinput()
    {
        if (charState == 0)
        {
            hMove = Input.GetAxis("Horizontal");
            vMove = Input.GetAxis("Vertical");

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                GetComponent<playervalue>().staAddDel = playervalue.StaONOFF.on;
                moveSpeed = 2.0f * 3.0f;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                GetComponent<playervalue>().staAddDel = playervalue.StaONOFF.off;
                moveSpeed = 2.0f;
            }
        }

        attack = Input.GetAxis("Fire1");
        if(attack == 1)
        {
            attackANi = true;
            hMove = 0.0f;
            vMove = 0.0f;
            charState = 1;
        }
        
        if (Input.GetMouseButton(1))
        {
            mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up * mouseX * spinSpeed * Time.deltaTime);
        }

    }
    void Move()
    {
        transform.Translate(Vector3.right * hMove * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * vMove * moveSpeed * Time.deltaTime);
    }

    void AniSetting()
    {
        if (hMove != 0 || vMove != 0) // WASD 키 누르면
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                GetComponent<Animator>().SetBool("run", true);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                GetComponent<Animator>().SetBool("run", false);
            }
            GetComponent<Animator>().SetBool("walk", true);
        }
        else if (hMove == 0 || vMove == 0) // WASD 안 누르면
        {
            GetComponent<Animator>().SetBool("walk", false);
        }

        GetComponent<Animator>().SetBool("attack", attackANi);

    }
    void AttackStart()
    {
        attackANi = false;
    }
    void AttackEnd()
    {
        if(attackANi == false)
        {
            charState = 0;
        }
        //Debug.Log("잘되나");
    }
    void AttackFinish()
    {
        attackANi = false;
        charState = 0;
    }

}

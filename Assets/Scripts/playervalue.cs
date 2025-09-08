using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playervalue : MonoBehaviour
{
    public TextMeshProUGUI playerHpValue;
    public float playerHP = 0.0f;
    //public string testString = string.Empty;
    public float playerStamina = 0.0f;

    public Image playerHPImage;
    public Image playerSTAImange;

    public float timeCheck = 0.0f;
    void Start()
    {
        playerHP = 100;
        playerHpValue.text = playerHP.ToString();
        //testString = "���� ������ ��";
        //playerHpValue.text = testString;

        //playerHPImage.GetComponent<Image>().fillAmount = 0.5f;
        //�÷��̾� ����¿� ���缭 playerHPImage UI�� fillAmout �� �������°� �����ϼ���.
        playerSTAImange.GetComponent<Image>().fillAmount = 1.0f;
    }

    void Update()
    {
        timeCheck = timeCheck + Time.deltaTime;

        if (timeCheck >= 0.001f)
        {
            playerSTAImange.GetComponent<Image>().fillAmount -= 0.001f;
            timeCheck = 0.0f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Zombie")
        {
            playerHP = playerHP - 10;
            playerHpValue.text = playerHP.ToString();
            
            playerHPImage.GetComponent<Image>().fillAmount = playerHP / 100;
        }
    }
}

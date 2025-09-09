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
<<<<<<< HEAD
    public float staChange = 0.0f;
    public enum StaONOFF
    {
        none, on, off
    }
    public StaONOFF staAddDel = StaONOFF.none;
    void Start()
    {
        playerHP = 100.0f;
        playerHpValue.text = playerHP.ToString();

        playerStamina = 100.0f;
        staChange = 1.0f;
=======
    void Start()
    {
        playerHP = 100;
        playerHpValue.text = playerHP.ToString();
        //testString = "글을 적으면 됨";
        //playerHpValue.text = testString;

        //playerHPImage.GetComponent<Image>().fillAmount = 0.5f;
        //플레이어 생명력에 맞춰서 playerHPImage UI의 fillAmout 값 낮아지는것 구현하세요.
        playerSTAImange.GetComponent<Image>().fillAmount = 1.0f;
>>>>>>> d8fab39c3acf802cb9839525349aef2ccdd6326b
    }

    void Update()
    {
<<<<<<< HEAD
        StaADD();
        StaDEL();
    }
    void StaADD()
    {
        if (staAddDel == StaONOFF.off)
        {
            timeCheck = timeCheck + Time.deltaTime;

            if (timeCheck >= 0.001f)
            {
                playerStamina = playerStamina + staChange;
                playerSTAImange.GetComponent<Image>().fillAmount = playerStamina / 100;
                timeCheck = 0.0f;
            }
        }
    }
    public void StaDEL()
    {
        if(staAddDel == StaONOFF.on)
        {
            timeCheck = timeCheck + Time.deltaTime;
            if (timeCheck >= 0.001f)
            {
                playerStamina = playerStamina - staChange;
                playerSTAImange.GetComponent<Image>().fillAmount = playerStamina / 100;
                timeCheck = 0.0f;
            }
=======
        timeCheck = timeCheck + Time.deltaTime;

        if (timeCheck >= 0.001f)
        {
            playerSTAImange.GetComponent<Image>().fillAmount -= 0.001f;
            timeCheck = 0.0f;
>>>>>>> d8fab39c3acf802cb9839525349aef2ccdd6326b
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
<<<<<<< HEAD
    

=======
>>>>>>> d8fab39c3acf802cb9839525349aef2ccdd6326b
}

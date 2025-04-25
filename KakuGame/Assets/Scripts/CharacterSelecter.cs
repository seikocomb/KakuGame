using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelecter : MonoBehaviour
{
    int characterNum1;
    int characterNum2;

    [SerializeField]GameObject[] cursor;

    public static string character1;
    public static string character2;

    bool isSelected1;
    bool isSelected2;

    AudioSource audioSource;
    [SerializeField]AudioClip[] sounds;

    TextMeshProUGUI character1Txt;
    TextMeshProUGUI character2Txt;

    [SerializeField]Sprite[] characterImgs;

    Image character1ImgObj;
    Image character2ImgObj;

    GameObject status;
    Image[,] statusesImg1 = new Image[4, 10];
    Image[,] statusesImg2 = new Image[4, 10];
    TextMeshProUGUI skill1;
    TextMeshProUGUI skill2;

    TextMeshProUGUI timer;
    [SerializeField]GameObject[] decides;

    [SerializeField]GameObject[] canvases;

    void Start()
    {
        characterNum1 = 0;
        characterNum2 = 7;

        isSelected1 = false;
        isSelected2 = false;

        audioSource = GetComponent<AudioSource>();

        character1Txt = GameObject.Find("character1").GetComponent<TextMeshProUGUI>();
        character2Txt = GameObject.Find("character2").GetComponent<TextMeshProUGUI>();

        character1ImgObj = GameObject.Find("Character1Img").GetComponent<Image>();
        character2ImgObj = GameObject.Find("Character2Img").GetComponent<Image>();

        status = GameObject.Find("status");
        skill1 = GameObject.Find("skill1").GetComponent<TextMeshProUGUI>();
        skill2 = GameObject.Find("skill2").GetComponent<TextMeshProUGUI>();

        timer = GameObject.Find("timer").GetComponent<TextMeshProUGUI>();

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject newStatus1 = Instantiate(status);
                newStatus1.transform.SetParent(GameObject.Find($"Statuses1-{i}").transform);
                statusesImg1[i, j] = newStatus1.GetComponent<Image>();
                statusesImg1[i, j].color = new Color(220, 220, 220);

                GameObject newStatus2 = Instantiate(status);
                newStatus2.transform.SetParent(GameObject.Find($"Statuses2-{i}").transform);
                statusesImg2[i, j] = newStatus2.GetComponent<Image>();
                statusesImg2[i, j].color = new Color(220, 220, 220);
            }
        }

        status.SetActive(false);
        decides[0].SetActive(false);
        decides[1].SetActive(false);
        canvases[0].SetActive(true);
        canvases[1].SetActive(false);

        StartCoroutine(Timer(30));
    }

    void Update()
    {
        if(isSelected1 == false)
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                characterNum1 --;
                if(characterNum1 == -1)
                {
                    characterNum1 = 3;
                }

                audioSource.volume = 0.5f;
                audioSource.PlayOneShot(sounds[0]);
            }
            if(Input.GetKeyDown(KeyCode.D))
            {
                characterNum1 ++;
                if(characterNum1 == 4)
                {
                    characterNum1 = 0;
                }

                audioSource.volume = 0.5f;
                audioSource.PlayOneShot(sounds[0]);
            }
        }

        if(isSelected2 == false)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                characterNum2 --;
                if(characterNum2 == 3)
                {
                    characterNum2 = 7;
                }

                audioSource.volume = 0.5f;
                audioSource.PlayOneShot(sounds[0]);
            }
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                characterNum2 ++;
                if(characterNum2 == 8)
                {
                    characterNum2 = 4;
                }

                audioSource.volume = 0.3f;
                audioSource.PlayOneShot(sounds[0]);
            }
        }

        character1Txt.text = cursor[characterNum1].name;
        character2Txt.text = cursor[characterNum2].name;

        character1ImgObj.sprite = characterImgs[characterNum1];
        character2ImgObj.sprite = characterImgs[characterNum2];

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                statusesImg1[i, j].color = new Color(220, 220, 220);
                statusesImg2[i, j].color = new Color(220, 220, 220);
            }
        }

        switch(characterNum1)
        {
            case 0:
                for(int i = 0; i < 8; i++)
                {
                    statusesImg1[0, i].color = Color.red;
                }
                for(int i = 0; i < 8; i++)
                {
                    statusesImg1[1, i].color = Color.red;
                }
                for(int i = 0; i < 10; i++)
                {
                    statusesImg1[2, i].color = Color.red;
                }
                for(int i = 0; i < 8; i++)
                {
                    statusesImg1[3, i].color = Color.red;
                }
                skill1.text = "吹き飛ばし";
                break;
            case 1:
                for(int i = 0; i < 10; i++)
                {
                    statusesImg1[0, i].color = Color.red;
                }
                for(int i = 0; i < 6; i++)
                {
                    statusesImg1[1, i].color = Color.red;
                }
                for(int i = 0; i < 4; i++)
                {
                    statusesImg1[2, i].color = Color.red;
                }
                for(int i = 0; i < 6; i++)
                {
                    statusesImg1[3, i].color = Color.red;
                }
                skill1.text = "波動砲";
                break;
            case 2:
                for(int i = 0; i < 7; i++)
                {
                    statusesImg1[0, i].color = Color.red;
                }
                for(int i = 0; i < 10; i++)
                {
                    statusesImg1[1, i].color = Color.red;
                }
                for(int i = 0; i < 7; i++)
                {
                    statusesImg1[2, i].color = Color.red;
                }
                for(int i = 0; i < 10; i++)
                {
                    statusesImg1[3, i].color = Color.red;
                }
                skill1.text = "ピストル";
                break;
            case 3:
                for(int i = 0; i < 9; i++)
                {
                    statusesImg1[0, i].color = Color.red;
                }
                for(int i = 0; i < 7; i++)
                {
                    statusesImg1[1, i].color = Color.red;
                }
                for(int i = 0; i < 7; i++)
                {
                    statusesImg1[2, i].color = Color.red;
                }
                for(int i = 0; i < 8; i++)
                {
                    statusesImg1[3, i].color = Color.red;
                }
                skill1.text = "ワープ";
                break;
        }

        switch(characterNum2)
        {
            case 7:
                for(int i = 0; i < 8; i++)
                {
                    statusesImg2[0, i].color = Color.blue;
                }
                for(int i = 0; i < 8; i++)
                {
                    statusesImg2[1, i].color = Color.blue;
                }
                for(int i = 0; i < 10; i++)
                {
                    statusesImg2[2, i].color = Color.blue;
                }
                for(int i = 0; i < 8; i++)
                {
                    statusesImg2[3, i].color = Color.blue;
                }
                skill2.text = "吹き飛ばし";
                break;
            case 6:
                for(int i = 0; i < 10; i++)
                {
                    statusesImg2[0, i].color = Color.blue;
                }
                for(int i = 0; i < 6; i++)
                {
                    statusesImg2[1, i].color = Color.blue;
                }
                for(int i = 0; i < 4; i++)
                {
                    statusesImg2[2, i].color = Color.blue;
                }
                for(int i = 0; i < 6; i++)
                {
                    statusesImg2[3, i].color = Color.blue;
                }
                skill2.text = "波動砲";
                break;
            case 5:
                for(int i = 0; i < 7; i++)
                {
                    statusesImg2[0, i].color = Color.blue;
                }
                for(int i = 0; i < 10; i++)
                {
                    statusesImg2[1, i].color = Color.blue;
                }
                for(int i = 0; i < 7; i++)
                {
                    statusesImg2[2, i].color = Color.blue;
                }
                for(int i = 0; i < 10; i++)
                {
                    statusesImg2[3, i].color = Color.blue;
                }
                skill2.text = "ピストル";
                break;
            case 4:
                for(int i = 0; i < 9; i++)
                {
                    statusesImg2[0, i].color = Color.blue;
                }
                for(int i = 0; i < 7; i++)
                {
                    statusesImg2[1, i].color = Color.blue;
                }
                for(int i = 0; i < 7; i++)
                {
                    statusesImg2[2, i].color = Color.blue;
                }
                for(int i = 0; i < 8; i++)
                {
                    statusesImg2[3, i].color = Color.blue;
                }
                skill2.text = "ワープ";
                break;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Decide1();
            
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            Decide2();
        }

        if(isSelected1 && isSelected2)
        {
            Invoke(nameof(DeleteSelect), 1);
        }

        for(int i = 0; i < 8; i++)
        {
            cursor[i].SetActive(false);
        }
        cursor[characterNum1].SetActive(true);
        cursor[characterNum2].SetActive(true);
    }

    void DeleteSelect()
    {
        canvases[0].SetActive(false);
        canvases[1].SetActive(true);
        Invoke(nameof(LoadScene), 1);
    }

    void LoadScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    void Decide1()
    {
        switch(characterNum1)
        {
            case 0:
                character1 = "kimono";
                break;
            case 1:
                character1 = "macho";
                break;
            case 2:
                character1 = "speed";
                break;
            case 3:
                character1 = "butler";
                break;
        }
        isSelected1 = true;

        decides[0].SetActive(true);
        Vector3 pos = cursor[characterNum1].transform.position;
        decides[0].transform.position = new Vector3(pos.x, pos.y + 80, pos.z);

        audioSource.volume = 1;
        audioSource.PlayOneShot(sounds[1]);
    }

    void Decide2()
    {
        switch(characterNum2)
        {
            case 4:
                character2 = "butler";
                break;
            case 5:
                character2 = "speed";
                break;
            case 6:
                character2 = "macho";
                break;
            case 7:
                character2 = "kimono";
                break;
        }
        isSelected2 = true;

        decides[1].SetActive(true);
        Vector3 pos = cursor[characterNum2].transform.position;
        decides[1].transform.position = new Vector3(pos.x, pos.y + 80, pos.z);

        audioSource.volume = 1;
        audioSource.PlayOneShot(sounds[1]);
    }

    IEnumerator Timer(float time)
    {
        while(time > 0)
        {
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            timer.text = string.Format("{0}:{1:00}", minutes, seconds);
            yield return new WaitForSeconds(1);
            time --;
        }

        Decide1();
        Decide2();
    }
}
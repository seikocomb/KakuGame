using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Starter : MonoBehaviour
{
    [SerializeField]GameObject[] canvases;
    [SerializeField]Button[] buttons;

    TMP_InputField nameInputField1;
    TMP_InputField nameInputField2;

    public static string name1;
    public static string name2;

    AudioSource audioSource;
    [SerializeField]AudioClip[] audioClips;

    float lastInputTime;

    void Start()
    {
        nameInputField1 = GameObject.Find("NameInputField1").GetComponent<TMP_InputField>();
        nameInputField2 = GameObject.Find("NameInputField2").GetComponent<TMP_InputField>();

        buttons[0].onClick.AddListener(OnNameSetButtonClick);
        buttons[1].onClick.AddListener(OnMainClick);
        buttons[2].onClick.AddListener(OnOperationClick);
        buttons[3].onClick.AddListener(OnSkillClick);
        buttons[4].onClick.AddListener(OnStartClick);
        buttons[5].onClick.AddListener(OnBackClick);
        buttons[6].onClick.AddListener(OnBacksClick);
        buttons[7].onClick.AddListener(OnBacksClick);
        buttons[8].onClick.AddListener(OnBacksClick);

        audioSource = GetComponent<AudioSource>();

        canvases[0].SetActive(true);
        canvases[1].SetActive(false);
        canvases[2].SetActive(false);
        canvases[3].SetActive(false);
        canvases[4].SetActive(false);
        canvases[5].SetActive(false);

        lastInputTime = Time.time;
    }

    void Update()
    {
        if(IsAnyKeyboardKeyDown())
        {
            if(canvases[0].activeInHierarchy)
            {
                canvases[0].SetActive(false);
                canvases[1].SetActive(true);
            }
        }

        if (Input.anyKey || Input.anyKeyDown || Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            lastInputTime = Time.time;
        }

        if (Time.time - lastInputTime >= 20)
        {
            if(canvases[1].activeInHierarchy)
            {
                canvases[1].SetActive(false);
                canvases[0].SetActive(true);
            }
        }
    }

    bool IsAnyKeyboardKeyDown()
    {
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if ((int)keyCode >= (int)KeyCode.Alpha0 && (int)keyCode <= (int)KeyCode.Menu)
            {
                if (Input.GetKeyDown(keyCode))
                    return true;
            }
        }
        return false;
    }

    void OnNameSetButtonClick()
    {
        if (string.IsNullOrWhiteSpace(nameInputField1.text) || string.IsNullOrWhiteSpace(nameInputField2.text))
        {
            return;
        }
        
        canvases[1].SetActive(false);
        canvases[2].SetActive(true);

        name1 = nameInputField1.text;
        name2 = nameInputField2.text;

        audioSource.PlayOneShot(audioClips[0]);
    }

    void OnMainClick()
    {
        canvases[2].SetActive(false);
        canvases[3].SetActive(true);

        audioSource.PlayOneShot(audioClips[0]);
    }

    void OnOperationClick()
    {
        canvases[2].SetActive(false);
        canvases[4].SetActive(true);

        audioSource.PlayOneShot(audioClips[0]);
    }

    void OnSkillClick()
    {
        canvases[2].SetActive(false);
        canvases[5].SetActive(true);

        audioSource.PlayOneShot(audioClips[0]);
    }

    void OnStartClick()
    {
        StartCoroutine(PlayAndLoad());
    }

    IEnumerator PlayAndLoad()
    {
        audioSource.PlayOneShot(audioClips[1]);
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("Select");
    }

    void OnBackClick()
    {
        canvases[2].SetActive(false);
        canvases[1].SetActive(true);

        audioSource.PlayOneShot(audioClips[0]);
    }

    void OnBacksClick()
    {
        canvases[3].SetActive(false);
        canvases[4].SetActive(false);
        canvases[5].SetActive(false);
        canvases[2].SetActive(true);

        audioSource.PlayOneShot(audioClips[0]);
    }
}
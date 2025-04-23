using System;
using System.Diagnostics;
using System.Linq;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField]GameObject kimono;
    [SerializeField]GameObject macho;
    [SerializeField]GameObject speed;
    [SerializeField]GameObject butler;
    [SerializeField]GameObject kimono2;
    [SerializeField]GameObject macho2;
    [SerializeField]GameObject speed2;
    [SerializeField]GameObject butler2;

    AudioSource audioSource;
    public AudioClip[] audioClips;

    public GameObject player1;
    public GameObject player2;

    public GameObject rightArm1;
    public GameObject rightArm2;
    public GameObject leftArm1;
    public GameObject leftArm2;
    public GameObject rightLeg1;
    public GameObject rightLeg2;

    public GameObject head1;
    public GameObject head2;

    CameraBehaviour cameraBehaviour;

    public BehaviourScript player1BS;
    public BehaviourScript player2BS;

    public bool gameOver;
    public static bool isWinner1;
    public static string winnerName;
    public static string loserName;
    public static string player1Name;
    public static string player2Name;
    public static float damageDealt1;
    public static float damageDealt2;
    public int skillCnt1 = 0;
    public int skillCnt2 = 0;
    public static int skillCntSta1;
    public static int skillCntSta2;

    public bool isPractice = true;
    GameObject gameStartCanvas;
    GameObject timerObj;
    TextMeshProUGUI timer;
    [SerializeField]TextMeshProUGUI[] playerNames;
    public Image[] gauges;
    public GameObject[] gaugeBacks;
    public Image[] bulletPools1;
    public Image[] bulletPools2;
    public GameObject[] bulletPoolBacks;
    [SerializeField]GameObject desCanvas;
    [SerializeField]Image[] fadeImages;
    readonly float durationTime = 1.5f;

    Coroutine coroutine;
    public bool isWait = false;

    GameObject bgm;
    ISkill[] skills;

    public GameObject[] effets;

    void Start()
    {
        Application.targetFrameRate = 30;

        audioSource = GetComponent<AudioSource>();

        AllSetUnabled();

        switch(CharacterSelecter.character1)
        {
            case "kimono":
                player1 = kimono;
                break;
            case "macho":
                player1 = macho;
                break;
            case "speed":
                player1 = speed;
                break;
            case "butler":
                player1 = butler;
                break;
        }
        switch(CharacterSelecter.character2)
        {
            case "kimono":
                player2 = kimono2;
                break;
            case "macho":
                player2 = macho2;
                break;
            case "speed":
                player2 = speed2;
                break;
            case "butler":
                player2 = butler2;
                break;
        }

        player1.SetActive(true);
        player2.SetActive(true);

        player1BS = player1.GetComponent<BehaviourScript>();
        player2BS = player2.GetComponent<BehaviourScript>();

        cameraBehaviour = GameObject.Find("Camera").GetComponent<CameraBehaviour>();
        cameraBehaviour.player1 = player1;
        cameraBehaviour.player2 = player2;

        if(player1 == kimono)
        {
            player1BS.body = GameObject.Find("Cube_kb").GetComponent<BoxCollider>();
            player1BS.leg_left = GameObject.Find("Cube_kll").GetComponent<BoxCollider>();
            player1BS.leg_right = GameObject.Find("Cube_krl").GetComponent<BoxCollider>();
            player1BS.arm_left = GameObject.Find("Cube_kla").GetComponent<BoxCollider>();
            player1BS.arm_right = GameObject.Find("Cube_kra").GetComponent<BoxCollider>();
            player1BS.weapon = GameObject.Find("sensu");
            player1BS.moveSpeed = 4;
            player1BS.power = 6;
            player1BS.jumpForce = 6.5f;
            player1BS.attackRate = 3;
            rightArm1 = GameObject.Find("fingertip_kr");
            leftArm1 = GameObject.Find("fingertip_kl");
            rightLeg1 = GameObject.Find("foot_kr");
            head1 = GameObject.Find("head_k");
        }
        else if(player1 == macho)
        {
            player1BS.body = GameObject.Find("Cube_mb").GetComponent<BoxCollider>();
            player1BS.leg_left = GameObject.Find("Cube_mll").GetComponent<BoxCollider>();
            player1BS.leg_right = GameObject.Find("Cube_mrl").GetComponent<BoxCollider>();
            player1BS.arm_left = GameObject.Find("Cube_mla").GetComponent<BoxCollider>();
            player1BS.arm_right = GameObject.Find("Cube_mra").GetComponent<BoxCollider>();
            player1BS.weapon = null;
            player1BS.moveSpeed = 3;
            player1BS.power = 8;
            player1BS.jumpForce = 6;
            player1BS.attackRate = 4;
            rightArm1 = GameObject.Find("fingertip_mr");
            leftArm1 = GameObject.Find("fingertip_ml");
            rightLeg1 = GameObject.Find("foot_mr");
            head1 = GameObject.Find("head_m");
        }
        else if(player1 == speed)
        {
            player1BS.body = GameObject.Find("Cube_sb").GetComponent<BoxCollider>();
            player1BS.leg_left = GameObject.Find("Cube_sll").GetComponent<BoxCollider>();
            player1BS.leg_right = GameObject.Find("Cube_srl").GetComponent<BoxCollider>();
            player1BS.arm_left = GameObject.Find("Cube_sla").GetComponent<BoxCollider>();
            player1BS.arm_right = GameObject.Find("Cube_sra").GetComponent<BoxCollider>();
            player1BS.weapon = GameObject.Find("gun");
            player1BS.moveSpeed = 5;
            player1BS.power = 5;
            player1BS.jumpForce = 6.25f;
            player1BS.attackRate = 2;
            rightArm1 = GameObject.Find("fingertip_sr");
            leftArm1 = GameObject.Find("fingertip_sl");
            rightLeg1 = GameObject.Find("foot_sr");
            head1 = GameObject.Find("head_s");
        }
        else if(player1 == butler)
        {
            player1BS.body = GameObject.Find("Cube_bb").GetComponent<BoxCollider>();
            player1BS.leg_left = GameObject.Find("Cube_bll").GetComponent<BoxCollider>();
            player1BS.leg_right = GameObject.Find("Cube_brl").GetComponent<BoxCollider>();
            player1BS.arm_left = GameObject.Find("Cube_bla").GetComponent<BoxCollider>();
            player1BS.arm_right = GameObject.Find("Cube_bra").GetComponent<BoxCollider>();
            player1BS.moveSpeed = 3.5f;
            player1BS.power = 7;
            player1BS.jumpForce = 6.25f;
            player1BS.attackRate = 3;
            rightArm1 = GameObject.Find("fingertip_br");
            leftArm1 = GameObject.Find("fingertip_bl");
            rightLeg1 = GameObject.Find("foot_br");
            head1 = GameObject.Find("head_b");
        }

        player1BS.body.isTrigger = true;
        player1BS.leg_left.isTrigger = true;
        player1BS.leg_right.isTrigger = true;
        player1BS.arm_left.isTrigger = true;
        player1BS.arm_right.isTrigger = true;

        if(player2 == kimono2)
        {
            player2BS.body = GameObject.Find("Cube_kb2").GetComponent<BoxCollider>();
            player2BS.leg_left = GameObject.Find("Cube_kll2").GetComponent<BoxCollider>();
            player2BS.leg_right = GameObject.Find("Cube_krl2").GetComponent<BoxCollider>();
            player2BS.arm_left = GameObject.Find("Cube_kla2").GetComponent<BoxCollider>();
            player2BS.arm_right = GameObject.Find("Cube_kra2").GetComponent<BoxCollider>();
            player2BS.weapon = GameObject.Find("sensu2");
            player2BS.moveSpeed = 4;
            player2BS.power = 6;
            player2BS.jumpForce = 6.5f;
            player2BS.attackRate = 3;
            rightArm2 = GameObject.Find("fingertip_kr2");
            leftArm2 = GameObject.Find("fingertip_kl2");
            rightLeg2 = GameObject.Find("foot_kr2");
            head2 = GameObject.Find("head_k2");
        }
        else if(player2 == macho2)
        {
            player2BS.body = GameObject.Find("Cube_mb2").GetComponent<BoxCollider>();
            player2BS.leg_left = GameObject.Find("Cube_mll2").GetComponent<BoxCollider>();
            player2BS.leg_right = GameObject.Find("Cube_mrl2").GetComponent<BoxCollider>();
            player2BS.arm_left = GameObject.Find("Cube_mla2").GetComponent<BoxCollider>();
            player2BS.arm_right = GameObject.Find("Cube_mra2").GetComponent<BoxCollider>();
            player2BS.weapon = null;
            player2BS.moveSpeed = 3;
            player2BS.power = 8;
            player2BS.jumpForce = 6;
            player2BS.attackRate = 3.5f;
            rightArm2 = GameObject.Find("fingertip_mr2");
            leftArm2 = GameObject.Find("fingertip_ml2");
            rightLeg2 = GameObject.Find("foot_mr2");
            head2 = GameObject.Find("head_m2");
        }
        else if(player2 == speed2)
        {
            player2BS.body = GameObject.Find("Cube_sb2").GetComponent<BoxCollider>();
            player2BS.leg_left = GameObject.Find("Cube_sll2").GetComponent<BoxCollider>();
            player2BS.leg_right = GameObject.Find("Cube_srl2").GetComponent<BoxCollider>();
            player2BS.arm_left = GameObject.Find("Cube_sla2").GetComponent<BoxCollider>();
            player2BS.arm_right = GameObject.Find("Cube_sra2").GetComponent<BoxCollider>();
            player2BS.weapon = GameObject.Find("gun2");
            player2BS.moveSpeed = 5;
            player2BS.power = 5;
            player2BS.jumpForce = 6.25f;
            player2BS.attackRate = 2.5f;
            rightArm2 = GameObject.Find("fingertip_sr2");
            leftArm2 = GameObject.Find("fingertip_kl2");
            rightLeg2 = GameObject.Find("foot_sr2");
            head2 = GameObject.Find("head_s2");
        }
        else if(player2 == butler2)
        {
            player2BS.body = GameObject.Find("Cube_bb2").GetComponent<BoxCollider>();
            player2BS.leg_left = GameObject.Find("Cube_bll2").GetComponent<BoxCollider>();
            player2BS.leg_right = GameObject.Find("Cube_brl2").GetComponent<BoxCollider>();
            player2BS.arm_left = GameObject.Find("Cube_bla2").GetComponent<BoxCollider>();
            player2BS.arm_right = GameObject.Find("Cube_bra2").GetComponent<BoxCollider>();
            player2BS.moveSpeed = 3.5f;
            player2BS.power = 7;
            player2BS.jumpForce = 7;
            player2BS.attackRate = 3;
            rightArm2 = GameObject.Find("fingertip_br2");
            leftArm2 = GameObject.Find("fingertip_bl2");
            rightLeg2 = GameObject.Find("foot_br2");
            head2 = GameObject.Find("head_b2");
        }

        player2BS.body.isTrigger = false;
        player2BS.leg_left.isTrigger = false;
        player2BS.leg_right.isTrigger = false;
        player2BS.arm_left.isTrigger = false;
        player2BS.arm_right.isTrigger = false;

        GameObject.Find("hadouhou").SetActive(false);
        if(player1 != speed && player2 != speed2)
        {
            GameObject.Find("bullet").SetActive(false);
        }

        player1BS.left = KeyCode.A;
        player1BS.right = KeyCode.D;
        player1BS.up = KeyCode.W;
        player1BS.down = KeyCode.S;
        player1BS.punch = KeyCode.Q;
        player1BS.kick = KeyCode.E;
        player1BS.upper = KeyCode.Z;
        player1BS.special = KeyCode.X;
        player1BS.gard = KeyCode.C;
        player1BS.enemy = player2;

        player2BS.left = KeyCode.LeftArrow;
        player2BS.right = KeyCode.RightArrow;
        player2BS.up = KeyCode.UpArrow;
        player2BS.down = KeyCode.DownArrow;
        player2BS.punch = KeyCode.Space;
        player2BS.kick = KeyCode.RightShift;
        player2BS.upper = KeyCode.RightControl;
        player2BS.special = KeyCode.P;
        player2BS.gard = KeyCode.L;
        player2BS.enemy = player1;

        player1.transform.SetPositionAndRotation(new Vector3(0, 0.5f, 2), Quaternion.Euler(0, 180, 0));
        player2.transform.SetPositionAndRotation(new Vector3(0, 0.5f, -2), Quaternion.Euler(0, 0, 0));

        gameStartCanvas = GameObject.Find("GameStartCanvas");
        gameStartCanvas.SetActive(false);
        timerObj = GameObject.Find("timer");
        timer = timerObj.GetComponent<TextMeshProUGUI>();
        coroutine = StartCoroutine(Timer(90));

        playerNames[0].text = Starter.name1;
        playerNames[1].text = Starter.name2;

        foreach(Image image in bulletPools1)
        {
            image.color = Color.red;
        }
        foreach(Image image in bulletPools2)
        {
            image.color = Color.blue;
        }

        desCanvas.SetActive(true);
        foreach(Image image in fadeImages)
        {
            image.color = new Color(1, 1, 1, 0);
        }

        bgm = GameObject.Find("BGM");
        if(bgm != null)
        {
            Destroy(bgm);
        }

        skills = FindObjectsOfType<MonoBehaviour>().OfType<ISkill>().ToArray();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.G))
        {
            if(isPractice)
            {
                StartCoroutine(PracticeOver());
            }
        }

        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.H))
        {
            if(Application.isEditor)
            {
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #endif
            }
            else
            {
                Process.Start(Application.dataPath.Replace("_Data", ".exe"));
                Application.Quit();
            }
        }
        
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.J))
        {
            SceneManager.LoadScene("Start");
        }

        if(player1BS.gardDmg > 100)
        {
            player1BS.gardDmg = 100;
        }
        if(player2BS.gardDmg == 100)
        {
            player2BS.gardDmg = 100;
        }
        if(player1BS.gardDmg != 0)
        {
            player1BS.gardDmg -= 0.1f;
        }
        if(player2BS.gardDmg != 0)
        {
            player2BS.gardDmg -= 0.1f;
        }
        if(player1BS.isGardCool)
        {
            player1BS.gardDmg = 0;
        }
        if(player2BS.isGardCool)
        {
            player2BS.gardDmg = 0;
        }
        gauges[4].fillAmount = 1 - player1BS.gardDmg / 100;
        gauges[5].fillAmount = 1 - player2BS.gardDmg / 100;
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

        if(isPractice)
        {
            StartCoroutine(PracticeOver());
        }
        else
        {
            if(player1BS.damage >= player2BS.damage)
            {
                GameOver(player1);
            }
            else
            {
                GameOver(player2);
            }
        }
    }

    IEnumerator PracticeOver()
    {
        gameStartCanvas.SetActive(true);
        desCanvas.SetActive(false);
        ACCancel();
        foreach(ISkill skill in skills)
        {
            skill.Reset();
        }
        isPractice = false;
        skillCnt1 = 0;
        skillCnt2 = 0;
        GaugeCancel();
        StopCoroutine(coroutine);
        StartCoroutine(Timer(182));
        isWait = true;
        yield return new WaitForSeconds(2);
        isWait = false;
        gameStartCanvas.SetActive(false);
    }

    public void GameOver(GameObject gameObj)
    {
        ACCancel();

        if(isPractice)
        {
            foreach(ISkill skill in skills)
            {
                skill.Reset();
            }
            GaugeCancel();
        }
        else
        {
            gameOver = true;
            if(gameObj == player1)
            {
                isWinner1 = false;
                winnerName = player2.name;
                loserName = player1.name;
            }
            else
            {
                isWinner1 = true;
                winnerName = player1.name;
                loserName = player2.name;
            }
            player1Name = player1.name;
            player2Name = player2.name;
            damageDealt1 = player1BS.enemyBS.damage;
            skillCntSta1 = skillCnt1;
            damageDealt2 = player2BS.enemyBS.damage;
            skillCntSta2 = skillCnt2;
            StopAllCoroutines();
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        float time = 0;
        Color color = fadeImages[0].color;
        Color color1= fadeImages[0].color;
        while (time < durationTime)
        {
            color.r = Mathf.Lerp(1, (float)167 / 255, time / durationTime);
            color.g = Mathf.Lerp(1, (float)199 / 255, time / durationTime);
            color.b = Mathf.Lerp(1, (float)243 / 255, time / durationTime);
            color.a = Mathf.Lerp(0, 1, time / durationTime);
            color1.a = Mathf.Lerp(0, (float)150 / 255, time / durationTime);
            fadeImages[0].color = color;
            fadeImages[1].color = color1;
            fadeImages[2].color = color1;
            time += Time.deltaTime;
            yield return null;
        }
        color.r = (float)167 / 255;
        color.g = (float)199 / 255;
        color.b = (float)243 / 255;
        color.a = 1;
        color1.a = (float)150 / 255;
        fadeImages[0].color = color;
        fadeImages[1].color = color1;
        fadeImages[2].color = color1;
        SceneManager.LoadScene("GameOver");
    }

    void ACCancel()
    {
        player1BS.AC.IsWalk = false;
        player1BS.AC.IsJump = false;
        player1BS.AC.IsCrouch = false;
        player1BS.AC.IsPunch = false;
        player1BS.AC.IsKick = false;
        player1BS.AC.IsUpper = false;
        player2BS.AC.IsWalk = false;
        player2BS.AC.IsJump = false;
        player2BS.AC.IsCrouch = false;
        player2BS.AC.IsPunch = false;
        player2BS.AC.IsKick = false;
        player2BS.AC.IsUpper = false;
    }

    void AllSetUnabled()
    {
        kimono.SetActive(false);
        macho.SetActive(false);
        speed.SetActive(false);
        butler.SetActive(false);
        kimono2.SetActive(false);
        macho2.SetActive(false);
        speed2.SetActive(false);
        butler2.SetActive(false);
    }

    void GaugeCancel()
    {
        if(player1 == speed)
        {
            foreach(Image image in bulletPools1)
            {
                image.color = Color.red;
                player1BS.isCool = false;
            }
        }
        else
        {
            gauges[0].fillAmount = 0;
            player1BS.time = player1BS.coolSpan;
        }

        if(player2 == speed2)
        {
            foreach(Image image in bulletPools2)
            {
                image.color = Color.blue;
                player2BS.isCool = false;
            }
        }
        else
        {
            gauges[1].fillAmount = 0;
            player2BS.time = player2BS.coolSpan;
        }

        GameObject[] clones = GameObject.FindGameObjectsWithTag("clone");
        foreach(GameObject clone in clones)
        {
            clone.SetActive(false);
        }
    }

    public IEnumerator FalserwB(Action<bool>isCoroutine, Action<bool>setBool, float time)
    {
        isCoroutine(true);
        yield return new WaitForSeconds(time);
        setBool(false);
        isCoroutine(false);
    }

    public void Player(int value, float volume)
    {
        audioSource.volume = volume;
        audioSource.PlayOneShot(audioClips[value]);
    }
}
using UnityEngine;

[DefaultExecutionOrder(4)]
public class ButlerSkill : MonoBehaviour, ISkill
{
    Main main;
    BehaviourScript BS;

    Vector3 pos;
    [SerializeField]GameObject image;
    GameObject imageTmp;
    bool isPlaced;
    public bool useSkill;

    Coroutine coroutine;
    bool isCoroutine;

    void Start()
    {
        main = GameObject.Find("Main").GetComponent<Main>();
        BS = GetComponent<BehaviourScript>();

        image.SetActive(false);

        BS.isCool = false;
        isPlaced = false;
    }

    void Update()
    {
        if(main.gameOver == false)
        {
            if(Input.GetKeyDown(BS.special))
            {
                if(BS.isCool == false)
                {
                    Skill();
                }
            }
        }
    }

    public void Skill()
    {
        if(isPlaced == false)
        {
            pos = transform.position;
            imageTmp = Instantiate(image, new Vector3(1, pos.y + 1, pos.z), image.transform.rotation);
            imageTmp.SetActive(true);
            isPlaced = true;
        }
        else
        {
            transform.position = pos;
            useSkill = true;
            StartCoroutine(BS.Falser(newValue => useSkill = newValue, 0.1f));
            main.Player(6, 1);
            if(BS.isPlayer1)
            {
                main.skillCnt1 += 1;
            }
            else
            {
                main.skillCnt2 += 1;
            }
            BS.isCool = true;
            Destroy(imageTmp);
            StartCoroutine(BS.Falser(newValue => isPlaced = newValue, 0.5f));
            coroutine = StartCoroutine(main.FalserwB(newValue => isCoroutine = newValue, newValue => BS.isCool = newValue, BS.coolSpan));
            BS.power = 10;
            BS.enemyBS.power /= 2;
            Invoke(nameof(BufReset), 3);
        }
    }

    void BufReset()
    {
        BS.power = 7;
        switch(BS.enemy.name)
        {
            case "kimono":
            case "kimono2":
                BS.enemyBS.power = 6;
                break;
            case "macho":
            case "macho2":
                BS.enemyBS.power = 8;
                break;
            case "speed":
            case "speed2":
                BS.enemyBS.power = 5;
                break;
            default:
                BS.enemyBS.power = 7;
                break;    
        }
    }

    public void Reset()
    {
        StopAllCoroutines();
        BufReset();
        isCoroutine = false;
        BS.damage = 0;
        BS.gardDmg = 0;
        BS.isCool = false;
        try
        {
            Destroy(imageTmp);
        }
        catch{}
        isPlaced = false;
        if(BS.isPlayer1)
        {
            transform.SetPositionAndRotation(new Vector3(0, 0.5f, 2), Quaternion.Euler(0, 180, 0));
        }
        else
        {
            transform.SetPositionAndRotation(new Vector3(0, 0.5f, -2), Quaternion.Euler(0, 0, 0));
        }
        BS.CC.center = Vector3.zero;
    }
}

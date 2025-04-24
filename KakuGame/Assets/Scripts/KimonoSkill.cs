using UnityEngine;

[DefaultExecutionOrder(4)]
public class KimonoSkill : MonoBehaviour, ISkill
{
    Main main;
    BehaviourScript BS;
    AnimationController AC;

    float damageTmp;
    float distance;
    Coroutine skill;
    bool isSkill;

    [SerializeField]GameObject wind;
    GameObject Wind;

    Coroutine coroutine;
    bool isCoroutine = false;

    void Start()
    {
        main = GameObject.Find("Main").GetComponent<Main>();
        BS = GetComponent<BehaviourScript>();
        AC = BS.AC;

        BS.isCool = true;
        coroutine = StartCoroutine(BS.Falser(newValue => BS.isCool = newValue, BS.coolSpan));

        wind.SetActive(false);
    }

    void Update()
    {
        if(main.gameOver == false)
        {
            if(Input.GetKeyDown(BS.special))
            {
                if(BS.isCool == false)
                {
                    if(AC.IsPunch == false && AC.IsKick == false && AC.IsUpper == false && AC.IsGard == false)
                    {
                        Skill();
                    }
                }
            }
        }

        if(AC.Special)
        {
            AC.IsPunch = false;
            AC.IsKick = false;
            AC.IsUpper = false;
            AC.IsGard = false;
            BS.damage = damageTmp;

            transform.Rotate(new Vector3(0, 60, 0));
        }

        if(isSkill)
        {
            if(BS.enemy.name == "butler1" || BS.enemy.name == "butler2")
            {
                ButlerSkill butlerSkill = BS.enemy.GetComponent<ButlerSkill>();
                if(butlerSkill.useSkill)
                {
                    StopCoroutine(skill);
                    isSkill = false;
                    StartCoroutine(BS.Destroyer(Wind, 0));
                    coroutine = StartCoroutine(main.FalserwB(newValue => isCoroutine = newValue, newValue => BS.isCool = newValue, BS.coolSpan));
                }
            }
        }
    }

    public void Skill()
    {
        AC.Special = true;
        damageTmp = BS.damage;
        BS.isCool = true;

        distance = Mathf.Clamp(8 - Vector3.Distance(transform.position, BS.enemy.transform.position), 1, 8) / 3;
        Vector3 rawDir = BS.enemy.transform.position - transform.position;
        skill = StartCoroutine(BS.KnockBack(BS.enemy, new Vector3(rawDir.x, 0, rawDir.z).normalized, distance, 0.2f));
        isSkill = true;
        StartCoroutine(BS.Falser(newValue => isSkill = newValue, 0.2f));

        Wind = Instantiate(wind, transform);
        Wind.tag = "clone";
        Wind.SetActive(true);

        main.Player(3, 1);
        if(BS.isPlayer1)
        {
            main.skillCnt1 += 1;
        }
        else
        {
            main.skillCnt2 += 1;
        }

        StartCoroutine(BS.Falser(newValue => AC.Special = newValue, 0.2f));
        StartCoroutine(BS.Destroyer(Wind, 0.2f));
        coroutine = StartCoroutine(main.FalserwB(newValue => isCoroutine = newValue, newValue => BS.isCool = newValue, BS.coolSpan));
    }

    public void Reset()
    {
        StopAllCoroutines();
        isCoroutine = false;
        AC.Special = false;
        BS.damage = 0;
        BS.gardDmg = 0;
        BS.isCool = true;
        isSkill = false;
        try
        {
            Destroy(Wind);
        }
        catch{}
        StartCoroutine(main.FalserwB(newValue => isCoroutine = newValue, newValue => BS.isCool = newValue, BS.coolSpan));
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
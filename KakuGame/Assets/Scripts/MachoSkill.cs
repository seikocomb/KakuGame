using UnityEngine;
using System;
using System.Collections;

[DefaultExecutionOrder(4)]
public class MachoSkill : MonoBehaviour, ISkill
{
    [SerializeField]GameObject hadouhou;
    GameObject Hadouhou;

    Main main;
    BehaviourScript BS;
    AnimationController AC;
    HadouhouScript HS;

    Coroutine coroutine;
    bool isCoroutine = false;

    void Start()
    {
        hadouhou.SetActive(false);

        main = GameObject.Find("Main").GetComponent<Main>();
        BS = GetComponent<BehaviourScript>();
        AC = BS.AC;

        BS.isCool = true;
        StartCoroutine(BS.Falser(newValue => BS.isCool = newValue, BS.coolSpan));
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
                        AC.Special = true;
                        Skill();
                    }
                }
            }
        }
    }

    public void Skill()
    {
        if(main.player1 == gameObject)
        {
            Hadouhou = Instantiate(hadouhou, BS.hand1.transform);
        }
        else if(main.player2 == gameObject)
        {
            Hadouhou = Instantiate(hadouhou, BS.hand2.transform);
        }
        Hadouhou.transform.SetParent(null);
        Hadouhou.tag = "clone";
        Hadouhou.SetActive(true);
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        BS.isHadouhouWait = true;
        HS = Hadouhou.GetComponent<HadouhouScript>();
        HS.Fire(BS, Mathf.Lerp(100, 400, Math.Abs(gameObject.transform.position.z - BS.enemy.transform.position.z) / 10));
        Vector3 rot = transform.forward;
        yield return new WaitForSeconds(0.2f);
        BS.isHadouhouWait = false;
        Hadouhou.GetComponent<Rigidbody>().AddForce(rot * 8, ForceMode.Impulse);
        main.Player(4, 1);
        if(BS.isPlayer1)
        {
            main.skillCnt1 += 1;
        }
        else
        {
            main.skillCnt2 += 1;
        }
        BS.isCool = true;
        AC.Special = false;
        coroutine = StartCoroutine(main.FalserwB(newValue => isCoroutine = newValue, newValue => BS.isCool = newValue, BS.coolSpan));
    }

    public void Reset()
    {
        StopAllCoroutines();
        isCoroutine = false;
        BS.damage = 0;
        BS.gardDmg = 0;
        BS.isCool = true;
        try
        {
            Destroy(Hadouhou);
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
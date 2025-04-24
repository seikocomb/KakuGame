using UnityEngine;

[DefaultExecutionOrder(3)]
public class HitJudge : MonoBehaviour
{
    Main main;
    BehaviourScript BS;
    AnimationController AC;
    BehaviourScript enemyBS;
    AnimationController enemyAC;

    [SerializeField]GameObject effect;

    void Start()
    {
        main = GameObject.Find("Main").GetComponent<Main>();
        BS = transform.root.GetComponent<BehaviourScript>();
        AC = BS.AC;
        enemyBS = BS.enemyBS;
        enemyAC = BS.enemyAC;

        effect.SetActive(false);
    }

    void Update()
    {
        if(enemyBS.isGardCool)
        {
            enemyBS.gardDmg = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other == enemyBS.body || other == enemyBS.arm_left || other == enemyBS.arm_right || other == enemyBS.leg_left || other == enemyBS.leg_right)
        {
            if(AC.IsKick)
            {
                if(gameObject == BS.leg_right.gameObject)
                {
                    if(AC.IsJump)
                    {
                        if(!enemyAC.IsCrouch)
                        {
                            if(enemyAC.IsGard)
                            {
                                enemyBS.gardDmg += BS.power * 1.25f;
                                Garded();
                            }
                            else
                            {
                                if(BS.isPlayer1)
                                {
                                    Effecter(main.rightLeg1, BS.leg_right.gameObject, 1, false);
                                }
                                else
                                {
                                    Effecter(main.rightLeg2, BS.leg_right.gameObject, 1, false);
                                }
                                Hit(1.25f);
                            }
                            main.Player(1, 0.5f);
                        }
                    }
                    else if(AC.IsCrouch)
                    {
                        if(!enemyAC.IsJump)
                        {
                            if(BS.isPlayer1)
                            {
                                Effecter(main.rightLeg1, BS.leg_right.gameObject, 0.5f, false);
                            }
                            else
                            {
                                Effecter(main.rightLeg2, BS.leg_right.gameObject, 0.5f, false);
                            }
                            Hit(5);
                            main.Player(1, 0.5f);
                        }
                    }
                    else
                    {
                        if(!enemyAC.IsJump)
                        {
                            if(enemyAC.IsGard)
                            {
                                enemyBS.gardDmg += BS.power * 1.5f;
                                Garded();
                            }
                            else
                            {
                                if(BS.isPlayer1)
                                {
                                    Effecter(main.rightLeg1, BS.leg_right.gameObject, 1.2f, false);
                                }
                                else
                                {
                                    Effecter(main.rightLeg2, BS.leg_right.gameObject, 1.2f, false);
                                }
                                Hit(1.5f);
                            }
                            main.Player(1, 0.5f);
                        }
                    }
                }
            }
            else if(AC.IsPunch)
            {
                if(gameObject == BS.arm_right.gameObject)
                {
                    if(!enemyAC.IsCrouch)
                    {
                        if(enemyAC.IsGard)
                        {
                            enemyBS.gardDmg += BS.power * 2;
                            Garded();
                        }
                        else
                        {
                            if(BS.isPlayer1)
                            {
                                Effecter(main.rightArm1, BS.arm_right.gameObject, 1.2f, false);
                            }
                            else
                            {
                                Effecter(main.rightArm2, BS.arm_right.gameObject, 1.2f, false);
                            }
                            Hit(2);
                        }
                        main.Player(2, 0.7f);
                    }
                }
            }
            else if(AC.IsUpper)
            {
                if(gameObject == BS.arm_left.gameObject)
                {
                    if(enemyAC.IsJump)
                    {
                        main.Player(2, 0.4f);
                        enemyAC.IsKick = false;
                        enemyAC.IsPunch = false;
                        enemyAC.IsUpper = false;

                        enemyBS.damage += BS.power * 1.75f;
                        StartCoroutine(BS.KnockBack(BS.enemy, (BS.enemy.transform.position - transform.parent.gameObject.transform.position).normalized, BS.power * 0.06f, 0.1f));
    
                        if(BS.isPlayer1)
                        {
                            Effecter(main.leftArm1, BS.arm_left.gameObject, 1, true);
                        }
                    }
                }
            }
        }
    }

    void Hit(float num)
    {
        enemyAC.IsKick = false;
        enemyAC.IsPunch = false;
        enemyAC.IsUpper = false;

        enemyBS.damage += BS.power * num;
        StartCoroutine(BS.KnockBack(BS.enemy, (BS.enemy.transform.position - transform.parent.gameObject.transform.position).normalized, BS.power * num / 500, 0.1f));
    }

    void Garded()
    {
        AC.IsKick = false;
        AC.IsPunch = false;
        BS.garded = true;

        if(enemyBS.gardDmg > 100)
        {
            enemyBS.gardDmg = 100;
            enemyBS.isGardCool = true;
            StartCoroutine(BS.Falser(newValue => enemyBS.isGardCool = newValue, 10));
        }
        
        StartCoroutine(BS.Falser(newValue => BS.garded = newValue, 1));
    }

    void Effecter(GameObject gameObj, GameObject gameObj2, float num, bool isUpper)
    {
        Vector3 pos = new(-0.7f, (gameObj.transform.position.y + gameObj2.transform.position.y) / 2, (gameObj.transform.position.z + gameObj2.transform.position.z) / 2);
        Quaternion rot;
        if(isUpper)
        {
            rot = Quaternion.Euler(0, 90, 90);
        }
        else
        {
            rot = Quaternion.Euler(0, gameObject.transform.parent.rotation.eulerAngles.y + 90, 0);
        }
        GameObject Effect = Instantiate(effect, pos, rot);
        Effect.tag = "clone";
        float size = BS.power * num / 30;
        Effect.transform.localScale = new Vector3(size, size, size);
        Effect.SetActive(true);
        StartCoroutine(BS.Destroyer(Effect, 0.08f));
    }
}
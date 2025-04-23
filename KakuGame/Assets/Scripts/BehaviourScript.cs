using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(2)]
public class BehaviourScript : MonoBehaviour
{
    bool isSelected = true;
    public bool isPlayer1;

    Animator animator;
    public AnimationController AC;
    public CharacterController CC;

    public float jumpForce;
    bool isGrounded = false;
    float hitCounter;
    Vector3 moveDirection;

    Main main;

    public BoxCollider body;
    public BoxCollider leg_left;
    public BoxCollider leg_right;
    public BoxCollider arm_left;
    public BoxCollider arm_right;
    public GameObject weapon;

    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode down;
    public KeyCode punch;
    public KeyCode kick;
    public KeyCode upper;
    public KeyCode special;
    public KeyCode gard;

    public GameObject enemy;
    public BehaviourScript enemyBS;
    public AnimationController enemyAC;

    public float moveSpeed;

    bool isAttackOK = true;
    int upperCounter = 0;
    public float attackRate;
    public float power;
    public float damage = 0;
    public float gardDmg = 0;
    public bool garded;
    public bool isGardCool;
    public float coolSpan;

    public bool isCool;
    Image gauge;
    public float time;

    Vector3 tmp;
    Vector3 headPos;

    public GameObject hand1;
    public GameObject hand2;

    GameObject redPin;
    GameObject bluePin;

    GameObject jumpEffect;
    GameObject walkEffect;

    void Start()
    {
        animator = GetComponent<Animator>();
        AC = new AnimationController(animator);

        main = GameObject.Find("Main").GetComponent<Main>();

        CC = GetComponent<CharacterController>();

        if(main.player1.name == name)
        {
            enemy = main.player2;
            isPlayer1 = true;

            if(name == "speed")
            {
                coolSpan = 7;
                gauge = main.gauges[2];
                main.gauges[0].gameObject.SetActive(false);
                main.gaugeBacks[0].SetActive(false);
            }
            else
            {
                coolSpan = 10;
                gauge = main.gauges[0];
                main.gauges[2].gameObject.SetActive(false);
                main.gaugeBacks[2].SetActive(false);
                main.bulletPoolBacks[0].SetActive(false);
            }
        }
        else if(main.player2.name == name)
        {
            enemy = main.player1;
            isPlayer1 = false;

            if(name == "speed2")
            {
                coolSpan = 7;
                gauge = main.gauges[3];
                main.gauges[1].gameObject.SetActive(false);
                main.gaugeBacks[1].SetActive(false);
            }
            else
            {
                coolSpan = 10;
                gauge = main.gauges[1];
                main.gauges[3].gameObject.SetActive(false);
                main.gaugeBacks[3].SetActive(false);
                main.bulletPoolBacks[1].SetActive(false);
            }
        }
        else
        {
            enemy = null;
            isSelected = false;
        }

        gauge.fillAmount = 0;
        time = coolSpan;

        enemyBS = enemy.GetComponent<BehaviourScript>();
        enemyAC = new AnimationController(enemyBS.GetComponent<Animator>());

        hand1 = GameObject.Find("RightHand");
        hand2 = GameObject.Find("RightHand2");

        redPin = GameObject.Find("RedPin");
        bluePin = GameObject.Find("BluePin");
    }

    void FixedUpdate()
    {
        if(isSelected)
        {
            if(main.gameOver == false && main.isWait == false)
            {
                if(isCool)
                {
                    time -= Time.deltaTime;
                    gauge.fillAmount = 1 - time / coolSpan;
                }
                else
                {
                    time = coolSpan;
                    gauge.fillAmount = 1;
                }

                if(transform.position.y > 0.5)
                {
                    CC.center = new Vector3(0, 100, 0);
                }
                else
                {
                    CC.center = Vector3.zero;
                }

                if(transform.position.z >= 4.99 || transform.position.z <= -4.99)
                {
                    moveDirection.y += Physics.gravity.y * Time.deltaTime;
                    CC.center = new Vector3(0, 100, 0);
                }
                else if(isGrounded)
                {
                    if(Input.GetKeyDown(up))
                    {
                        moveDirection.y = jumpForce;
                        isGrounded = false;
                    }
                }
                else
                {
                    moveDirection.y += Physics.gravity.y * Time.deltaTime;
                    hitCounter = 0;
                }
                
                if(Input.GetKey(left))
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    if(isGrounded)
                    {
                        if(AC.IsGard)
                        {
                            CC.Move(new Vector3(0, 0, moveSpeed * Time.deltaTime * 0.3f));
                        }
                        else if(AC.IsCrouch == false)
                        {
                            CC.Move(new Vector3(0, 0, moveSpeed * Time.deltaTime));
                            AC.IsWalk = true;
                        }
                        else
                        {
                            CC.Move(new Vector3(0, 0, moveSpeed * Time.deltaTime * 0.1f));
                        }
                    }
                    else
                    {
                        CC.Move(new Vector3(0, 0, moveSpeed * Time.deltaTime * 0.5f));
                    }
                }

                if(Input.GetKey(right))
                {
                    transform.rotation = Quaternion.Euler(0, 180,0);
                    if(isGrounded)
                    {
                        if(AC.IsGard)
                        {
                            CC.Move(new Vector3(0, 0, moveSpeed * Time.deltaTime * 0.3f * -1));
                        }
                        else if(AC.IsCrouch == false)
                        {
                            CC.Move(new Vector3(0, 0, moveSpeed * Time.deltaTime * -1));
                            AC.IsWalk = true;
                        }
                        else
                        {
                            CC.Move(new Vector3(0, 0, moveSpeed * Time.deltaTime * 0.1f * -1));
                        }
                    }
                    else
                    {
                        CC.Move(new Vector3(0, 0, moveSpeed * Time.deltaTime * 0.5f * -1));
                    }
                }

                if(Input.GetKey(down))
                {
                    if(isGrounded)
                    {
                        AC.IsCrouch = true;
                        AC.IsWalk = false;
                        AC.IsJump = false;
                    }
                }
                else
                {
                    AC.IsCrouch = false;
                }

                if(garded == false)
                {
                    if(isAttackOK)
                    {
                        if(Input.GetKeyDown(punch))
                        {
                            if(AC.IsPunch == false && AC.IsKick == false && AC.IsUpper == false)
                            {
                                if(AC.IsJump)
                                {
                                    AC.IsKick = true;
                                }
                                else if(!AC.IsCrouch)
                                {
                                    AC.IsPunch = true;
                                }
                                Attacker(1);
                            }
                        }

                        if(Input.GetKeyDown(kick))
                        {
                            if(AC.IsPunch == false && AC.IsKick == false && AC.IsUpper == false)
                            {
                                if(!AC.IsCrouch)
                                {
                                    AC.IsKick = true;
                                }
                                Attacker(2);
                            }
                        }

                        if(Input.GetKeyDown(upper))
                        {
                            if(AC.IsPunch == false && AC.IsKick == false && AC.IsUpper == false)
                            {
                                if(upperCounter == 0){
                                    upperCounter ++;
                                    AC.IsUpper = true;
                                    Attacker(3);
                                    moveDirection.y = jumpForce * 0.5f;
                                    isGrounded = false;
                                }
                                
                            }
                        }
                    }
                }

                if(transform.position.y >= 0.4f)
                {
                    AC.IsJump = true;
                    AC.IsWalk = false;
                    AC.IsCrouch = false;
                }
                else
                {
                    AC.IsJump= false;
                }

                if(Input.GetKey(gard) && !AC.IsJump && isGardCool == false && !(AC.IsPunch || AC.IsKick || AC.IsUpper))
                {
                    AC.IsGard = true;

                    AC.IsPunch = false;
                    AC.IsKick = false;
                    AC.IsUpper = false;
                }
                else
                {
                    AC.IsGard = false;
                }

                if(Input.GetKey(left) || Input.GetKey(right)){}
                else
                {
                    AC.IsWalk= false;
                }

                if(AC.Special == false)
                {
                    if(transform.rotation.eulerAngles.y <= 90 || transform.rotation.eulerAngles.y >= 270)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                }

                if(transform.position.y <= -5)
                {
                    main.GameOver(gameObject);
                }

                if(main.isPractice)
                {
                    if(damage >= 750)
                    {
                        main.GameOver(gameObject);
                    }
                }
                else
                {
                    if(damage >= 2000)
                    {
                        main.GameOver(gameObject);
                    }
                }

                CC.Move(moveDirection * Time.deltaTime);

                tmp = transform.position;
                transform.position = new Vector3(0, tmp.y, tmp.z);

                if(isPlayer1)
                {
                    headPos = main.head1.transform.position;
                    if(Math.Round(transform.rotation.y) == 0)
                    {
                        redPin.transform.position = new Vector3(headPos.x, headPos.y + 0.5f, headPos.z - 0.1f);
                    }
                    else
                    {
                        redPin.transform.position = new Vector3(headPos.x, headPos.y + 0.5f, headPos.z + 0.1f);
                    }
                }
                else
                {
                    headPos = main.head2.transform.position;
                    if(Math.Round(transform.rotation.y) == 0)
                    {
                        bluePin.transform.position = new Vector3(headPos.x, headPos.y + 0.5f, headPos.z - 0.1f);
                    }
                    else
                    {
                        bluePin.transform.position = new Vector3(headPos.x, headPos.y + 0.5f, headPos.z + 0.1f);
                    }
                }
            }
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.name == "floor")
        {
            isGrounded = true;
            upperCounter = 0;
            hitCounter ++;
            if(hitCounter == 1)
            {
                main.Player(0, 1);
                jumpEffect = Instantiate(main.effets[0], new Vector3(0, 0.1f, transform.position.z), Quaternion.Euler(270, 0, 0));
                jumpEffect.tag = "clone";
                StartCoroutine(Destroyer(jumpEffect, 0.2f));
            }
            else
            {
                if(AC.IsWalk)
                {
                    walkEffect = Instantiate(main.effets[1], transform.position, Quaternion.Euler(270, 0, 0));
                    walkEffect.tag = "clone";
                    StartCoroutine(Destroyer(walkEffect, 0.05f));
                }
            }
        }
    }

    void Attacker(int num)
    {
        switch(num)
        {
            case 1:
                AC.IsKick = false;
                AC.IsUpper = false;
                StartCoroutine(Falser(newValue => isAttackOK = newValue, 0.13f * attackRate));
                StartCoroutine(Truer(newValue => isAttackOK = newValue, 0.2f * attackRate));
                Invoke(nameof(AttackFalser), 0.13f * attackRate);
                break;
            case 2:
                AC.IsPunch = false;
                AC.IsUpper = false;
                StartCoroutine(Falser(newValue => isAttackOK = newValue, 0.13f * attackRate));
                StartCoroutine(Truer(newValue => isAttackOK = newValue, 0.2f * attackRate));
                Invoke(nameof(AttackFalser), 0.13f * attackRate);
                break;
            case 3:
                AC.IsPunch = false;
                AC.IsKick = false;
                StartCoroutine(Falser(newValue => isAttackOK = newValue, 0.2f * attackRate));
                StartCoroutine(Truer(newValue => isAttackOK = newValue, 0.27f * attackRate));
                Invoke(nameof(AttackFalser), 0.2f * attackRate);
                break;
        }
    }

    void AttackFalser()
    {
        AC.IsPunch = false;
        AC.IsKick = false;
        AC.IsUpper = false;
    }

    public IEnumerator Truer(Action<bool>setBool, float time)
    {
        yield return new WaitForSeconds(time);
        setBool(true);
    }

    public IEnumerator Falser(Action<bool>setBool, float time)
    {
        yield return new WaitForSeconds(time);
        setBool(false);
    }

    public IEnumerator Destroyer(GameObject gameObj, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObj);
    }

    public IEnumerator ActiveFalser(GameObject gameObj, float time)
    {
        yield return new WaitForSeconds(time);
        gameObj.SetActive(false);
    }

    public IEnumerator KnockBack(GameObject target, Vector3 direction, float num, float duration)
    {
        Vector3 startPos = target.transform.position;
        Vector3 endPosTmp = startPos + direction.normalized * num;
        Vector3 endPos = new Vector3(endPosTmp.x, Math.Max(endPosTmp.y, 0), endPosTmp.z);
        float time = 0;

        while(time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            target.transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        target.transform.position = endPos;
    }
}
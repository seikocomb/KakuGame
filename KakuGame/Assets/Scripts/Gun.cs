using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(3)]
public class Gun : MonoBehaviour, ISkill
{
    readonly float fireRate = 0.1f;
    float nextFireTime = 0;
    readonly int bulletSize = 15;
    public int magazine = 0;
    float reloadTime;
    GameObject speed;

    BulletPool bulletPool;
    Bullet b;
    Main main;
    BehaviourScript BS;
    AnimationController AC;

    [SerializeField]GameObject fire;
    GameObject Fire;

    void Start()
    {
        speed = transform.root.gameObject;
        bulletPool = speed.GetComponent<BulletPool>();
        main = GameObject.Find("Main").GetComponent<Main>();
        BS = speed.GetComponent<BehaviourScript>();
        AC = BS.AC;
        BS.isCool = false;
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(-90, speed.transform.eulerAngles.y + 180, 0);
        if(BS.isCool)
        {
            if(Time.time >= reloadTime + BS.coolSpan)
            {
                magazine = 0;
                BS.isCool = false;

                if(BS.isPlayer1)
                {
                    foreach(Image image in main.bulletPools1)
                    {
                        image.color = Color.red;
                    }
                }
                else
                {
                    foreach(Image image in main.bulletPools2)
                    {
                        image.color = Color.blue;
                    }
                }
            }
        }
        else
        {
            if(Input.GetKeyDown(BS.special))
            {
                if(AC.IsPunch == false && AC.IsKick == false && AC.IsUpper == false && AC.IsGard == false)
                {
                    if(magazine < bulletSize)
                    {
                        if(Time.time >= nextFireTime)
                        {
                            Skill();
                            nextFireTime = Time.time + fireRate;
                        }
                    }
                    else
                    {
                        BS.isCool = true;
                        if(BS.isPlayer1)
                        {
                            main.skillCnt1 += 1;
                        }
                        else
                        {
                            main.skillCnt2 += 1;
                        }
                        reloadTime = Time.time;
                    }
                }
            }
        }

        if(magazine > 0)
        {
            if(BS.isPlayer1)
            {
                main.bulletPools1[15 - magazine].color = Color.gray;
            }
            else
            {
                main.bulletPools2[magazine - 1].color = Color.gray;
            }
        }
    }

    public void Skill()
    {
        GameObject bullet = bulletPool.GetBullet(magazine);
        magazine ++;
        bullet.transform.SetPositionAndRotation(transform.position, speed.transform.rotation);
        bullet.SetActive(true);
        b = bullet.GetComponent<Bullet>();
        b.Shoot(speed);

        Fire = Instantiate(fire, transform);
        Fire.tag = "clone";
        fire.SetActive(true);
        StartCoroutine(BS.Destroyer(Fire, 0.2f));
    }

    public void Reset()
    {
        magazine = 0;
        BS.damage = 0;
        BS.gardDmg = 0;
        BS.isCool = false;
        try
        {
            Destroy(Fire);
        }
        catch{}
        if(BS.isPlayer1)
        {
            speed.transform.SetPositionAndRotation(new Vector3(0, 0.5f, 2), Quaternion.Euler(0, 180, 0));
        }
        else
        {
            speed.transform.SetPositionAndRotation(new Vector3(0, 0.5f, -2), Quaternion.Euler(0, 0, 0));
        }
        BS.CC.center = Vector3.zero;
    }
}

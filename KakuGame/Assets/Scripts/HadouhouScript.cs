using UnityEngine;

[DefaultExecutionOrder(4)]
public class HadouhouScript : MonoBehaviour
{
    BehaviourScript BS;
    Rigidbody rb;
    float damage;
    bool isSetBS = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Fire(BehaviourScript behaviourScript, float value)
    {
        BS = behaviourScript;
        isSetBS = true;
        damage = value;
    }

    void OnTriggerEnter(Collider other)
    {
        if(isSetBS && BS.isHadouhouWait == false)
        {
            if(other.gameObject.transform.root.gameObject == BS.enemy)
            {
                rb.velocity = Vector3.zero;
                if(BS.enemyAC.IsGard)
                {
                    BS.enemyBS.damage += damage / 2;
                    BS.enemyBS.gardDmg += damage / 2;
                }
                else
                {
                    BS.enemyBS.damage += damage;
                }
                isSetBS = false;
                gameObject.SetActive(false);
            }
            else if(other.gameObject.CompareTag("wall"))
            {
                rb.velocity = Vector3.zero;
                isSetBS = false;
                gameObject.SetActive(false);
            }
        }
    }
}

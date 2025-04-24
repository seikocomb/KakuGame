using UnityEngine;

[DefaultExecutionOrder(4)]
public class HadouhouScript : MonoBehaviour
{
    BehaviourScript BS;
    Rigidbody rb;
    float damage;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Fire(GameObject gameObj, float value)
    {
        BS = gameObj.GetComponent<BehaviourScript>();
        StartCoroutine(BS.ActiveFalser(gameObject, 2));
        damage = value;
    }

    void OnTriggerEnter(Collider other)
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
            gameObject.SetActive(false);
        }
        else if(other.gameObject.CompareTag("wall"))
        {
            rb.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
}

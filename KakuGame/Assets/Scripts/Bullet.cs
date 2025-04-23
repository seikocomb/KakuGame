using UnityEngine;

[DefaultExecutionOrder(3)]
public class Bullet : MonoBehaviour
{
    readonly float speed = 5;

    Main main;
    BehaviourScript BS;
    Rigidbody rb;

    GameObject effect;
    int counter = 0;

    public void Shoot(GameObject gameObj)
    {
        main = GameObject.Find("Main").GetComponent<Main>();
        BS = gameObj.GetComponent<BehaviourScript>();

        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
        main.Player(5, 1);
        counter = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.root.gameObject == BS.enemy)
        {
            if(counter == 0)
            {
                StartCoroutine(BS.ActiveFalser(gameObject, 0.12f));
                if(BS.enemyAC.IsGard)
                {
                    BS.enemyBS.gardDmg += 15;
                }
                else
                {
                    BS.enemyBS.damage += 15;
                }
                effect = Instantiate(main.effets[2], transform.position, Quaternion.Euler(-transform.rotation.x, 0, 0));
                effect.tag = "clone";
                StartCoroutine(BS.Destroyer(effect, 0.1f));
                rb.velocity = Vector3.zero;
            }
            counter ++;
        }
        else if(other.gameObject.CompareTag("wall"))
        {
            gameObject.SetActive(false);
        }
    }
}

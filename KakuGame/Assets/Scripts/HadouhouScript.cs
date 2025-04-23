using UnityEngine;

[DefaultExecutionOrder(4)]
public class HadouhouScript : MonoBehaviour
{
    BehaviourScript BS;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Call(GameObject gameObj)
    {
        BS = gameObj.GetComponent<BehaviourScript>();
        try
        {
            Invoke(nameof(Fuck), 2);
        }
        catch{}
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.root.gameObject == BS.enemy)
        {
            rb.velocity = Vector3.zero;
            gameObject.SetActive(false);
            BS.enemyBS.damage += 300;
        }
        else if(other.gameObject.CompareTag("wall"))
        {
            rb.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }
    }

    void Fuck()
    {
        gameObject.SetActive(false);
    }
}

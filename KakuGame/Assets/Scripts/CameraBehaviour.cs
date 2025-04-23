using System;
using UnityEngine;

[DefaultExecutionOrder(1)]
public class CameraBehaviour : MonoBehaviour
{
    Main main;

    public GameObject player1;
    public GameObject player2;
    Vector3 pos1;
    Vector3 pos2;

    void Start()
    {
        main = GameObject.Find("Main").GetComponent<Main>();
    }

    void FixedUpdate()
    {
        if(main.gameOver == false)
        {
            pos1 = player1.transform.position;
            pos2 = player2.transform.position;

            Vector3 midPoint = (pos1 + pos2) / 2;
            float distanceY = Mathf.Abs(pos1.y - pos2.y) + 1;
            float distanceZ = Mathf.Abs(pos1.z - pos2.z) + 2;
            float requiredSizeY = distanceY / 2 + 1.3f;
            float requiredSizeZ = distanceZ / 2;
            float requiredSize = Mathf.Max(requiredSizeY, requiredSizeZ, 2);
            transform.position = Vector3.Lerp(transform.position, new Vector3(-requiredSize, Math.Max(midPoint.y + 1.7f, 1.5f), midPoint.z), 0.5f);
        }
    }
}
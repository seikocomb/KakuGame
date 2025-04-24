using System;
using TMPro;
using UnityEngine;

[DefaultExecutionOrder(4)]
public class ScoreManager : MonoBehaviour
{
    Main main;

    [SerializeField]TextMeshProUGUI[] HPtexts;
    [SerializeField]TextMeshProUGUI[] FullHPtexts;

    void Start()
    {
        main = GetComponent<Main>();
    }

    void Update()
    {
        if(main.isPractice)
        {
            HPtexts[0].text = "" + (750 - Math.Floor(main.player1BS.damage));
            HPtexts[1].text = "" + (750 - Math.Floor(main.player2BS.damage));
            FullHPtexts[0].text = "/750";
            FullHPtexts[1].text = "/750";
        }
        else
        {
            HPtexts[0].text = "" + (2000 - Math.Floor(main.player1BS.damage));
            HPtexts[1].text = "" + (2000 - Math.Floor(main.player2BS.damage));
            FullHPtexts[0].text = "/2000";
            FullHPtexts[1].text = "/2000";
        }
    }
}

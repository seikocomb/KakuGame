using System;
using TMPro;
using UnityEngine;

[DefaultExecutionOrder(4)]
public class ScoreManager : MonoBehaviour
{
    Main main;

    TextMeshProUGUI text1;
    TextMeshProUGUI text2;

    void Start()
    {
        main = GetComponent<Main>();

        text1 = GameObject.Find("damage1").GetComponent<TextMeshProUGUI>();
        text2 = GameObject.Find("damage2").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text1.text = "" + Math.Floor(main.player1BS.damage);
        text2.text = "" + Math.Floor(main.player2BS.damage);
    }
}

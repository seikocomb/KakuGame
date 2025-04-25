using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    Image winnerImg;
    TextMeshProUGUI winnerText;
    TextMeshProUGUI winPlayer;
    TextMeshProUGUI losePlayer;
    [SerializeField]Sprite[] sprites;
    [SerializeField]TextMeshProUGUI[] tableTxt;

    [SerializeField]GameObject[] canvases;

    bool isThanks = false;

    void Start()
    {
        canvases[0].SetActive(true);
        canvases[1].SetActive(false);

        winnerImg = GameObject.Find("WinnerImg").GetComponent<Image>();
        winnerText = GameObject.Find("WinnerName").GetComponent<TextMeshProUGUI>();
        winPlayer = GameObject.Find("WinPlayer").GetComponent<TextMeshProUGUI>();
        losePlayer = GameObject.Find("LosePlayer").GetComponent<TextMeshProUGUI>();

        if(Main.isWinner1)
        {
            winPlayer.text = $"勝：{Starter.name1}";
            losePlayer.text = $"負：{Starter.name2}";
            winPlayer.color = Color.red;
            losePlayer.color = Color.blue;
        }
        else
        {
            winPlayer.text = $"勝：{Starter.name2}";
            losePlayer.text = $"負：{Starter.name1}";
            winPlayer.color = Color.blue;
            losePlayer.color = Color.red;
        }

        switch(Main.winnerName)
        {
            case "kimono":
            case "kimono2":
                winnerImg.sprite = sprites[0];
                winnerText.text = "咲弥";
                break;
            case "macho":
            case "macho2":
                winnerImg.sprite = sprites[1];
                winnerText.text = "アレス";
                break;
            case "speed":
            case "speed2":
                winnerImg.sprite = sprites[2];
                winnerText.text = "ニンリル";
                break;
            case "butler":
            case "butler2":
                winnerImg.sprite = sprites[3];
                winnerText.text = "ミトラ";
                break;
        }

        tableTxt[0].text = Starter.name1;
        tableTxt[1].text = Starter.name2;

        switch(Main.player1Name)
        {
            case "kimono":
                tableTxt[2].text = "咲弥";
                break;
            case "macho":
                tableTxt[2].text= "アレス";
                break;
            case "speed":
                tableTxt[2].text = "ニンリル";
                break;
            case "butler":
                tableTxt[2].text = "ミトラ";
                break;
        }
        switch(Main.player2Name)
        {
            case "kimono2":
                tableTxt[3].text = "咲弥";
                break;
            case "macho2":
                tableTxt[3].text= "アレス";
                break;
            case "speed2":
                tableTxt[3].text = "ニンリル";
                break;
            case "butler2":
                tableTxt[3].text = "ミトラ";
                break;
        }

        tableTxt[4].text = Math.Round(Main.damageDealt1).ToString();
        tableTxt[5].text = Math.Round(Main.damageDealt2).ToString();

        tableTxt[6].text = Main.skillCntSta1.ToString();
        tableTxt[7].text = Main.skillCntSta2.ToString();

        Invoke(nameof(Thanks), 20);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(isThanks)
            {
                LoadStart();
            }
            else
            {
                Thanks();
            }
        }
    }

    void Thanks()
    {
        isThanks = true;
        canvases[0].SetActive(false);
        canvases[1].SetActive(true);
        Invoke(nameof(LoadStart), 5);
    }

    void LoadStart()
    {
        SceneManager.LoadScene("Start");
    }
}
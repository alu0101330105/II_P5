using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SequenceManager : MonoBehaviour {
    private List<int> sequence = new List<int>();
    public GameObject[] buttons;
    private int playerindex = 0;
    private int playerScore = 0;
    public int scoreToWin = 10;
    public TMP_Text ScoreText;
    public TMP_Text WinText;
    bool winState = false;

    void OnEnable() {
        Button.OnButtonClicked += PlayerButton;
    }

    void Start() {
        ResetGame();
    }

    IEnumerator PlayGame() {
        yield return new WaitForSeconds(1.5f);
        RandomButton();
    }

    void RandomButton() {
        if(winState)
            return;
        int randomButton = Random.Range(0, buttons.Length);
        buttons[randomButton].GetComponent<Button>().PressButton();
        sequence.Add(randomButton);
    }

    void PlayerButton(int buttonIndex) {
        if(winState) {
            ResetGame();
            winState = false;
            StartCoroutine("PlayGame");
            return;
        }
        if(buttonIndex == sequence[playerindex]) {
            Debug.Log("Correct");
            playerindex++;
            if(playerindex == sequence.Count) {
                playerindex = 0;
                playerScore++;
                ScoreText.text = playerScore.ToString();
                if(playerScore == scoreToWin) {
                    GameWin();
                }
                StartCoroutine("PlayGame");
            }
        } else {
            Debug.Log("Wrong");
            ResetGame();
        }
    }

    void ResetGame() {
        Debug.Log("Reset Game");
        playerindex = 0;
        playerScore = 0;
        ScoreText.text = playerScore.ToString();
        sequence.Clear();
        foreach(GameObject button in buttons) {
            button.GetComponent<Button>().ResetColor();
        }
        WinText.text = "";
        StartCoroutine("PlayGame");
    }

    void GameWin() {
        ScoreText.text = "";
        WinText.text = "You Win!\nClick an Orb to Play Again";
        winState = true;
        foreach(GameObject button in buttons) {
            button.GetComponent<Button>().WinColor();
        }
    }
}

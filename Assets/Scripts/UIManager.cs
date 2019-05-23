using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {

        public TextMeshProUGUI score;
        public TextMeshProUGUI time;
        public TextMeshProUGUI gameOver;

        public float timeLimit;
        public int playerScore;

        float accumTIme = 0;
	
	// Update is called once per frame
	void Update () {
                accumTIme += Time.deltaTime;

                score.text = "Score: " + playerScore;
                float timeLeft = Mathf.Max((timeLimit - accumTIme), 0);
                int minutes = (int)timeLeft / 60;
                int seconds = (int)timeLeft - 60 * minutes;
                time.text = string.Format("{0:00}:{1:00}", minutes, seconds);

                if (accumTIme >= timeLimit) {
                        gameOver.gameObject.SetActive(true);
                        Time.timeScale = 0;
                }

	}
}

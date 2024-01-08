using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//import library when using TextMesh pro
using TMPro;
//enables management of scene in scene folder
using UnityEngine.SceneManagement;
//library allows interaction w ui elements
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public bool isGameActive;
    private int score;
    private float spawnRate = 1.5f;

    IEnumerator SpawnTarget() {
        while(isGameActive){
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        //set the text on the text element
        scoreText.text = "Score: " + score;
    }

    public void GameOver() {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame() {
        //this method allows us to use SceneManager to load a scene using name of current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty) {
        //set active before coroutine
        isGameActive = true;
        score = 0;
        //spawnRate divided by the difficulty(set in the ui for each button)
        spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;

    public Button restartButton;
    private int score;
    private float spawnRate = 2.0f;
    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        //isGameActive = true;
        //score = 0;
        //StartCoroutine(nameof(SpawnTarget));
        //UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget(float spawnRateInput)
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRateInput);
            int randomIndex = Random.Range(0, targets.Count);
            Instantiate(targets[randomIndex]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        //GameObject.Find("GameOverText").SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(float difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate = spawnRate / difficulty;
        StartCoroutine(nameof(SpawnTarget), spawnRate);
        UpdateScore(0);
        titleScreen.SetActive(false);
    }
}

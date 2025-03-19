using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using UnityEngine.Networking;

public class GameManagerSpace : MonoBehaviour
{
    private bool isGameRunning = true;
    public TextMeshProUGUI _textScore;

    public TextMeshProUGUI _textLife;
    int life;
    //newwwwwwwww
    [HeaderAttribute(" Score ID")]
    public int score = 0;
    public int user_id = 0; // ID del usuario
    private string scoreUrl = "http://localhost/insert_spaceship.php";

    [SerializeField] GameObject _gameOver;
    [SerializeField] AudioSource backGround;
    //private bool isGameOver = false;
    public void ReceiveID(string id)
    {
        Debug.Log("ReceiveID called with id: " + id);
        if (int.TryParse(id, out int parsedId))
        {
            user_id = parsedId;
            Debug.Log("Received user ID: " + user_id);
        }
        else
        {
            Debug.LogError("Invalid user ID received: " + id);
        }
    }


    public class GameScore
    {
        public int user_id;
        public int score_space;
    }
    private void Awake()
    {
        life = 50;
        gameScore = new GameScore();
        gameScore.user_id = 0;
        gameScore.score_space = 0;
       // DontDestroyOnLoad(this);
        
    }
    [SerializeField] private GameScore gameScore;
    private void Start()
    {
        
        _gameOver.SetActive(false);
    }
    public void InsertScore()
    {
        StartCoroutine(InsertScoreCoroutine());
    }

    private IEnumerator InsertScoreCoroutine()
    {
        string jsonString = JsonUtility.ToJson(gameScore);
        UnityWebRequest request = new UnityWebRequest(scoreUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonString);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error al insertar el mejor tiempo: " + request.error);
        }
        else
        {

            string responseText = request.downloadHandler.text;
            ServerResponseCard response = JsonUtility.FromJson<ServerResponseCard>(responseText);

            if (response.message == "Score inserted successfully")
            {
                Debug.Log("puntaje agregao");
            }
            else
            {
                Debug.LogError("puntaje nave fallao: " + response.message);
            }
        }
    }
    public void SetUserID()
    {
        gameScore.user_id = user_id;
        Debug.Log("User ID set to: " + gameScore.user_id);
    }

    public void SetSpaceScore(int score)
    {

        gameScore.score_space = score;
        Debug.Log("Score set to: " + gameScore.score_space);
    }
    void OnEnable()
    {
        playerControl.OnCollisionEnemy += CurrentLife;
        enemyControler.OnEliminated += CurrentScore;
    }
    private void OnDisable()
    {
        playerControl.OnCollisionEnemy -= CurrentLife;
        enemyControler.OnEliminated -= CurrentScore;
    }
    private void Update()
    {
        _textScore.text = "Score: " + score;
        _textLife.text = "Life: " + life;
       GameOver();
        
    }

    public void CurrentLife(int numb)
    {
       life = life - numb;
    }
    public void CurrentScore(int num)
    {
        score += num;
    }
    public void GameOver()
    {
        if (life <=0 || score <= -50)
        {
            //isGameOver = true;
            
            _gameOver.SetActive(true);
            backGround.Stop();
            Time.timeScale = 0f;
        }
    }
    private IEnumerator RestartGameCoroutine()
    {
        SetUserID();
        SetSpaceScore(score);
        if (score >= 0)
        {
            InsertScore(); // Guarda el puntaje
        }
        else
        {
            Debug.Log("puntaje invalido");
        }
        
        yield return new WaitForSecondsRealtime(1); // Espera un momento para asegurarte de que se guarde
        Time.timeScale = 1f;
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
    public void RestartGame()
    {
        StartCoroutine(RestartGameCoroutine());
        
        //InsertScore();
        //Time.timeScale = 1f;
        //string sceneName = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(sceneName);
    }


}
[System.Serializable]
public class ServerResponseCard
{
    public string message;
}

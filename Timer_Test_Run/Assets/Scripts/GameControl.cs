using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelSelectPanel;
    [SerializeField] private GameObject gamePlay;
    [SerializeField] private Timer gameTimer;
    [SerializeField] private GameObject pausePanel;
    
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private Button playBtn;
    [SerializeField] private Button pauseBtn;
    [SerializeField] private Button unPauseBtn;
    [SerializeField] private Button exitBtn;
    
    [SerializeField] private Button restartBtn;
    [SerializeField] private Button exitToMenuBtn;

    private void Awake()
    {
        mainMenu.SetActive(true);
        gameOverPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
        gamePlay.SetActive(false);
        pausePanel.SetActive(false);
    }

    private void OnEnable()
    {
        playBtn.onClick.AddListener(PlayGame);
        pauseBtn.onClick.AddListener(PauseGame);
        unPauseBtn.onClick.AddListener(UnPauseGame);
        exitBtn.onClick.AddListener(ExitGame);
        gameTimer.onTimerEnd.AddListener(GameOverSequence);
        
        restartBtn.onClick.AddListener(RestartGame);
        exitToMenuBtn.onClick.AddListener(ExitGame);
    }

    private void OnDisable()
    {
        playBtn.onClick.RemoveListener(PlayGame);
        pauseBtn.onClick.RemoveListener(PauseGame);
        unPauseBtn.onClick.RemoveListener(UnPauseGame);
        exitBtn.onClick.RemoveListener(ExitGame);
        gameTimer.onTimerEnd.RemoveListener(GameOverSequence);
        
        restartBtn.onClick.RemoveListener(RestartGame);
        exitToMenuBtn.onClick.RemoveListener(ExitGame);
    }

    private void RestartGame()
    {
        gameTimer.StopTimer();
        gameOverPanel.SetActive(false);
        StartGame(levelCompleteTime);
    }

    private void GameOverSequence()
    {
        gameOverPanel.SetActive(true);
    }

    private void PlayGame()
    {
        levelSelectPanel.SetActive(true);
    }

    private void PauseGame()
    {
        pausePanel.SetActive(true);
        gameTimer.PauseTimer();
    }

    private void UnPauseGame()
    {
        pausePanel.SetActive(false);
        gameTimer.ResumeTimer();
    }

    private void ExitGame()
    {
        gameTimer.StopTimer();
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gamePlay.SetActive(false);
        mainMenu.SetActive(true);
    }

    private int levelCompleteTime;
    public void StartGame(int levelCompleteTime)
    {
        this.levelCompleteTime = levelCompleteTime;
        levelSelectPanel.SetActive(false);
        mainMenu.SetActive(false);
        gamePlay.SetActive(true);
        gameTimer.seconds = this.levelCompleteTime;
        gameTimer.StartTimer();
    }
}

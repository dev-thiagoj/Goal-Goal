using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DevUtills.Core.Singleton;

public class GameManager : Singleton<GameManager>
{
    //public Button buttonStart;
    //public Button buttonRestart;
    //public Button buttonOk;
    //public GameObject initialBackground;
    //public GameObject endgameBackground;
    //public GameObject rulesBackground;

    //public ParticleSystem particleSystem;

    public TextMeshProUGUI winnerAnnouncer;

    public Player[] playersCS;

    public int endPoint = 5;

    public float timeToSetBallFree = 4f;

    protected override void Awake()
    {
        base.Awake();

        //Screen.SetResolution(600, 800, false, 60);

        //SetRatio(16f, 9f);
        Debug.Log("GameManager Awake");
        DontDestroyOnLoad(gameObject);
        //rulesBackground.SetActive(false);

        playersCS = FindObjectsOfType<Player>();
    }

    void SetRatio(float w, float h)
    {
        if ((((float)Screen.width) / ((float)Screen.height)) > w / h)
        {
            Screen.SetResolution((int)(((float)Screen.height) * (w / h)), Screen.height, true);
        }
        else
        {
            Screen.SetResolution(Screen.width, (int)(((float)Screen.width) * (h / w)), true);
        }
    }

    private void Start()
    {
        Debug.Log("GameManager Start");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(1);
    }

    public void SwithStateReset()
    {
        StateMachine.Instance.ResetPosition();
    }

    public void ResetBall()
    {
        BallBase.Instance.CanMove(false);
        BallBase.Instance.ResetBall();
        Invoke(nameof(SetBallFree), Random.Range(2, timeToSetBallFree));
    }

    private void SetBallFree()
    {
        BallBase.Instance.CanMove(true);
    }

    public void ExitRulesBackground()
    {
        //rulesBackground.SetActive(false);
        //initialBackground.SetActive(true);
    }

    public void LoadPlayScene()
    {
        SceneManager.LoadScene(2);
        Invoke(nameof(ChangeStateToPlay), 2);
    }

    public void StartGame()
    {
        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }

    public void EndGame()
    {   
        BallBase.Instance.ball.SetActive(false);
        BallBase.Instance.CanMove(false);
        Invoke(nameof(LoadEndScene), 5);
        UpdateWinnerText();
    }

    void LoadEndScene()
    {
        SceneManager.LoadScene(3);
    }

    public void UpdateWinnerText()
    {
        //winnerAnnouncer.text = (string) player.playerName + " é o vencedor!";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeStateToPlay()
    {
        StateMachine.Instance.SwitchState(StateMachine.States.PLAYING);
    }

    public void ChangeStateToEnd()
    {
        
        StateMachine.Instance.SwitchState(StateMachine.States.END_GAME);
    }
}

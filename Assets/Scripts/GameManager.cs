using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DevUtills.Core.Singleton;

public class GameManager : Singleton<GameManager>
{
    private const string V = "Player 02 é o vencedor.";
    private const string V1 = "Player 01 é o vencedor.";

    //public Button buttonStart;
    //public Button buttonRestart;
    //public Button buttonOk;
    //public GameObject initialBackground;
    //public GameObject endgameBackground;
    //public GameObject rulesBackground;

    //public ParticleSystem particleSystem;

    public TextMeshProUGUI winnerAnnouncer;

    public Player player01;
    public Player player02;

    public int endPoint = 5;

    public float timeToSetBallFree = 4f;

    protected override void Awake()
    {
        base.Awake();

        //Screen.SetResolution(600, 800, false, 60);

        //SetRatio(16f, 9f);
        
        DontDestroyOnLoad(gameObject);
        //rulesBackground.SetActive(false);
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
        winnerAnnouncer.text = "";
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
        ChangeStateToPlay();
    }

    public void StartGame()
    {
        Debug.Log("Start game");
        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }

    public void EndGame()
    {   
        UpdateWinnerText();
        BallBase.Instance.ball.SetActive(false);
        BallBase.Instance.CanMove(false);
        Invoke(nameof(LoadEndScene), 5);
    }

    void LoadEndScene()
    {
        SceneManager.LoadScene(3);
    }

    public void UpdateWinnerText()
    {
        if (player01.currentPoints == Instance.endPoint) 
            winnerAnnouncer.text = V1;
        else
            winnerAnnouncer.text = V;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
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

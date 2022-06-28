using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DevUtills.Core.Singleton;

public class GameManager : Singleton<GameManager>
{
    public TextMeshProUGUI winnerAnnouncer;

    public Player player01;
    public Player player02;

    public string winner = "";

    public int endPoint = 5;

    public float timeToSetBallFree = 6f;

    //public LoadSceneHelper sceneHelper;

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
        //sceneHelper.isLogoScene = false;
    }

    public void DebugRestartButton()
    {
        Debug.Log("Restart Button");
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
        AudioHelper.Instance.PitchAccelerator(1f);
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
        Debug.Log(winner);
        //if (player01.currentPoints == endPoint)
        winnerAnnouncer.text = winner + " é o(a) vencedor(a).";
        //else
            //winnerAnnouncer.text = player02.name + " é o(a) vencedor(a).";
    }

    public void RestartGame()
    {
        ChangeStateToPlay();
        SceneManager.LoadScene(1);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void TurnSoundOff()
    {
        AudioHelper.Instance.TurnSoundOff();
    }

    public void TurnSoundOn()
    {
        AudioHelper.Instance.TurnSoundOn();
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

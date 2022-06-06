using System.Collections.Generic;
using UnityEngine;
using DevUtills.Core.Singleton;
using UnityEngine.SceneManagement;

public class StateMachine : Singleton<StateMachine>
{
    public enum States
    {
        MENU,
        PLAYING,
        RESET_POSITION,
        END_GAME
    }

    public Dictionary<States, StateBase> dictionaryState;

    public StateBase _currentState;
    public float timeToStartGame = 0f;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);

        dictionaryState = new Dictionary<States, StateBase>
        {
            { States.MENU, new StateBase() },
            { States.PLAYING, new StatePlaying() },
            { States.RESET_POSITION, new StateResetPosition() },
            { States.END_GAME, new StateEndGame() }
        };

        SwitchState(States.MENU);
    }


    public void SwitchState(States state)
    {
        if (_currentState != null) _currentState.OnStateExit();

        _currentState = dictionaryState[state];

        _currentState.OnStateEnter();
    }

    private void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();       

        if (_currentState == null) _currentState.OnStateExit();        
    }

    public void ResetPosition()
    {
        SwitchState(States.RESET_POSITION);
    }
}

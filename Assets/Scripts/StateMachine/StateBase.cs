using UnityEngine;
using UnityEngine.SceneManagement;

public class StateBase
{
    public virtual void OnStateEnter(object o = null) {}

    public virtual void OnStateStay() {}

    public virtual void OnStateExit() {}
}

public class StatePlaying : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        GameManager.Instance.StartGame();
    }
}

public class StateResetPosition : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        GameManager.Instance.ResetBall();
    }
}

public class StateEndGame : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        GameManager.Instance.EndGame();
    }
}
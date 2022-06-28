using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    public Player player;
    public ParticleSystem newParticleSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {
            Countpoint();
        }
    }

    void Countpoint()
    {
        if (player.currentPoints < GameManager.Instance.endPoint)
        {
            StateMachine.Instance.ResetPosition();
            player.AddPoint();
            newParticleSystem.Play();
        }
    }


}

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;

    public Image uiPlayer;
    public int indexColor;
    public string playerName;

    [Header("Bounds")]
    public Transform rightBoundTransform;
    private Vector3 rightBoundVec;
    public Transform leftBoundTransform;
    private Vector3 leftBoundVec;
    public Transform upBoundTransform;
    private Vector3 upBoundVec;
    public Transform downBoundTransform;
    private Vector3 downBoundVec;

    [Header("Texts")]
    public TextMeshProUGUI uiTextPoints;

    public int currentPoints;

    private AudioSource audioSource;
    private Vector3 _pos;
    private bool _playing;

    private void OnValidate()
    {
        if (rigidbody2D == null) rigidbody2D = GetComponent<Rigidbody2D>();
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        ResetPlayer();
    }

    private void Start()
    {
        GetBounds();
        ChangeColor(indexColor);
    }

    void Update()
    {
        Bounds();
        if(_playing) AudioPitchModifier();
        if(_playing) FinalPoint();
    }

    public void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();
        _playing = true;
    }

    private void GetBounds()
    {
        rightBoundVec = rightBoundTransform.transform.position;
        leftBoundVec = leftBoundTransform.transform.position;
        upBoundVec = upBoundTransform.transform.position;
        downBoundVec = downBoundTransform.transform.position;
    }

    public void Bounds()
    {
        _pos.y = rigidbody2D.transform.position.y;
        _pos.x = rigidbody2D.transform.position.x;

        if (_pos.x > rightBoundVec.x) _pos.x = rightBoundVec.x;
        else if (_pos.x < leftBoundVec.x) _pos.x = leftBoundVec.x;

        if (_pos.y > upBoundVec.y) _pos.y = upBoundVec.y;
        else if (_pos.y < downBoundVec.y) _pos.y = downBoundVec.y;

        rigidbody2D.transform.position = _pos;
    }

    /*public void SetName(string s)
    {
        player.name = s;
    }*/

    public void ChangeColor(int i)
    {
        uiPlayer.color = SetColorHelper.Instance.colors[i];
    }

    public void AddPoint()
    {
        currentPoints++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        uiTextPoints.text = currentPoints.ToString();
    }

    public void AudioPitchModifier()
    {
        if (currentPoints == GameManager.Instance.endPoint - 4)
        {
            AudioHelper.Instance.PitchAccelerator(1.1f);
        }
        else if (currentPoints == GameManager.Instance.endPoint - 3)
        {
            AudioHelper.Instance.PitchAccelerator(1.2f);
        }
        else if (currentPoints == GameManager.Instance.endPoint - 2)
        {
            AudioHelper.Instance.PitchAccelerator(1.3f);
        }
        else if (currentPoints == GameManager.Instance.endPoint - 1)
        {
            AudioHelper.Instance.PitchAccelerator(1.4f);
        }
    }

    public void FinalPoint()
    {
        if (currentPoints == GameManager.Instance.endPoint)
        {
            _playing = false;
            PlayFireworksHelper.Instance.StartFireworks();
            //BallBase.Instance.gameObject.SetActive(false);
            Player_MovementManager.Instance.playerSpeed = 0;
            GameManager.Instance.ChangeStateToEnd();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {
            audioSource.Play();
        }
    }
}

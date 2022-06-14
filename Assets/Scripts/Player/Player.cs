using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public Player player;
    //public CharacterController characterController;
    public Rigidbody2D rigidbody2D;

    public Image uiPlayer;
    public string playerName;

    [Header("Bounds")]
    //public Vector2 limitsX = new Vector2(-4f, 4f);
    //public Vector2 limitsY = new Vector2(-4f, 4f);
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
    //public TextMeshProUGUI uiTextEndGame;

    public int currentPoints;

    private Vector3 _pos;
    private bool _playing;

    private void OnValidate()
    {
        //if (characterController == null) characterController = GetComponent<CharacterController>();
        if (rigidbody2D == null) rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        ResetPlayer();
        //initialPosition = transform.position;
    }

    private void Start()
    {
        GetBounds();
    }

    void Update()
    {
        Bounds();
        if(_playing) FinalPoint();

        Debug.Log(gameObject.name + " = " + currentPoints);
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

        ///if (_pos.x < limitsX.x) _pos.x = limitsX.x;
        //else if (_pos.x > limitsX.y) _pos.x = limitsX.y;

        //if (_pos.y < limitsY.x) _pos.y = limitsY.x;
        //else if (_pos.y > limitsY.y) _pos.y = limitsY.y;

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

    public void ChangeColor(Color c)
    {
        uiPlayer.color = c;
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

    public void FinalPoint()
    {
        if (currentPoints == GameManager.Instance.endPoint)
        {
            //player.name = (string) playerName;
            GameManager.Instance.winner = gameObject.name;
            _playing = false;
            PlayFireworksHelper.Instance.StartFireworks();
            BallBase.Instance.gameObject.SetActive(false);
            Player_MovementManager.Instance.playerSpeed = 0;
            GameManager.Instance.ChangeStateToEnd();
        }
    }
}

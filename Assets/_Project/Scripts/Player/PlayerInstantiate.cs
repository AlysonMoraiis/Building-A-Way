using System.Collections.Generic;
using UnityEngine;

public class PlayerInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject _bridgePrefab;
    [SerializeField] private GameObject _ladderPrefab;
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] private Transform _instantiatePoint;
    [SerializeField] private PlayerMovement _playerMovement;

    private List<GameObject> _bridgeList = new List<GameObject>();
    private List<GameObject> _ladderList = new List<GameObject>();
    private List<GameObject> _wallList = new List<GameObject>();
    private GameObject _bridgeGameObject;
    private GameObject _ladderGameObject;
    private GameObject _wallGameObject;
    public bool _isPaused;
    public bool _isThinking;

    public static PlayerInstantiate Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (_isPaused)
        {
            return;
        }

        if (Time.timeScale == 1 && _playerMovement.GroundCheck())
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CreateLadder();
                _isThinking = true;
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                CreateBridge();
                _isThinking = true;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                CreateWall();
            }
        }
    }

    private void CreateBridge()
    {
        if (_bridgeList.Count != 0)
        {
            Destroy(_bridgeList[0].gameObject);
        }

        _bridgeList.Clear();
        _bridgeGameObject = Instantiate(_bridgePrefab, _instantiatePoint.position, _instantiatePoint.rotation);
        _bridgeList.Add(_bridgeGameObject);
    }

    private void CreateWall()
    {
        if (_wallList.Count != 0)
        {
            Destroy(_wallList[0].gameObject);
        }

        _wallList.Clear();
        _wallGameObject = Instantiate(_wallPrefab, _instantiatePoint.position, transform.rotation);
        _wallList.Add(_wallGameObject);
    }

    private void CreateLadder()
    {
        if (_ladderList.Count != 0)
        {
            Destroy(_ladderList[0].gameObject);
        }

        _ladderList.Clear();
        _ladderGameObject = Instantiate(_ladderPrefab, _instantiatePoint.position, transform.rotation);
        _ladderList.Add(_ladderGameObject);
    }
}

using Assets.Unit5.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class DificultyButton : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private int _difficulty;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        _gameManager.StartGame(_difficulty);
    }
}
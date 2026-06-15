using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Unit5.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject _gameTitlePannel;
        [SerializeField] private Button _restartBtn;
        [SerializeField] private TextMeshProUGUI _gameOverText;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private List<GameObject> _targets;

        [SerializeField] private float _spawnRate;

        private int _score = 0;
        private bool _isGameActive = false;

        void OnEnable()
        {
            Target.OnTargetClicked += HandleTargetClicked;
            _restartBtn.onClick.AddListener(RestartGame);
        }
        void Start()
        {
            _restartBtn.gameObject.SetActive(false);
            _gameOverText.gameObject.SetActive(false);
            _score = 0;
            _scoreText.text = "Score: 0";
        }

        void OnDisable()
        {
            Target.OnTargetClicked -= HandleTargetClicked;
            _restartBtn.onClick.RemoveListener(RestartGame);
        }

        void Update()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame && _isGameActive)
            {
                Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 2f);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.TryGetComponent<ITarget>(out var target))
                    {
                        target.OnClick();
                    }
                }
            }
        }

        public void StartGame(int difficulty)
        {
            _gameTitlePannel.SetActive(false);
            _spawnRate = 1.5f / difficulty;
            _score = 0;
            _scoreText.text = "Score: 0";
            _isGameActive = true;
            StartCoroutine(SpawnTarget());
        }

        private void HandleTargetClicked(int arg0)
        {
            AddScore(arg0);
            if (arg0 < 0)
            {
                GameOver();
                StopAllCoroutines();
            }
        }

        private void GameOver()
        {
            _isGameActive = false;
            _gameOverText.gameObject.SetActive(true);
            _restartBtn.gameObject.SetActive(true);
        }

        private IEnumerator SpawnTarget()
        {
            while (_isGameActive)
            {
                yield return new WaitForSeconds(_spawnRate);
                int idx = Random.Range(0, _targets.Count);
                Instantiate(_targets[idx]);
            }
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void AddScore(int add)
        {
            _score += add;
            _scoreText.text = "Score: " + _score;
        }
    }
}
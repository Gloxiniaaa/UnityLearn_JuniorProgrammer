using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LoadSceneButton : MonoBehaviour
{
    [SerializeField] private int _sceneIndex;
    private Button _btn;

    private void Awake()
    {
        _btn = GetComponent<Button>();
    }
    void OnEnable()
    {
        _btn.onClick.AddListener(LoadScene);
    }

    void OnDisable()
    {
        _btn.onClick.RemoveListener(LoadScene);

    }

    private void LoadScene()
    {
        SceneManager.LoadScene(_sceneIndex);
    }
}
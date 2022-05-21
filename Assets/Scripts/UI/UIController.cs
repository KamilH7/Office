using Game.Events;
using InputSystem.Events;
using UnityEngine;

public class UIController : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField, Header("UI References")]
    private RectTransform inGameUI;
    [SerializeField]
    private RectTransform preGameUI;
    [SerializeField]
    private RectTransform postGameUI;

    [SerializeField, Header("Listening To")]
    private GameStarted gameStarted;
    [SerializeField]
    private GameEnded gameEnded;
    [SerializeField]
    private FingerUp fingerUp;

    #endregion

    #region Unity Callbacks

    private void OnEnable()
    {
        AssignCallbacks();
    }

    private void OnDisable()
    {
        UnAssignCallbacks();
    }

    private void Start()
    {
        EnableInput();
        EnablePreGameUI();
    }

    #endregion

    #region Private Methods

    private void GameStarted()
    {
        DisableInput();
        EnableInGameUI();
    }

    private void GameEnded(int finalScore)
    {
        EnableInput();
        EnablePostGameUI();
    }

    private void EnablePreGameUI()
    {
        preGameUI.gameObject.SetActive(true);
        inGameUI.gameObject.SetActive(false);
        postGameUI.gameObject.SetActive(false);
    }

    private void EnableInGameUI()
    {
        preGameUI.gameObject.SetActive(false);
        inGameUI.gameObject.SetActive(true);
        postGameUI.gameObject.SetActive(false);
    }

    private void EnablePostGameUI()
    {
        preGameUI.gameObject.SetActive(false);
        inGameUI.gameObject.SetActive(false);
        postGameUI.gameObject.SetActive(true);
    }

    private void EnableInput()
    {
        fingerUp.Subscribe(GameStarted);
    }

    private void DisableInput()
    {
        fingerUp.UnSubscribe(GameStarted);
    }

    private void AssignCallbacks()
    {
        gameStarted.Subscribe(GameStarted);
        gameEnded.Subscribe(GameEnded);
    }

    private void UnAssignCallbacks()
    {
        gameStarted.UnSubscribe(GameStarted);
        gameEnded.UnSubscribe(GameEnded);
    }

    #endregion
}
using Game.Events;
using InputSystem.Events;
using Player.Events;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Serialized Fields

    [Header("Listening To"), SerializeField]
    private PlayerDied playerDied;
    [SerializeField]
    private FingerDown fingerUp;

    [Header("Broadcasting On"), SerializeField]
    private GameStarted gameStarted;
    [SerializeField]
    private GameEnded gameEnded;

    #endregion

    #region Unity Callbacks

    private void OnEnable()
    {
        AssignEvents();
    }

    private void OnDisable()
    {
        UnAssignEvents();
    }

    #endregion

    #region Public Methods

    public void StartGame()
    {
        gameStarted.Invoke();
        fingerUp.UnSubscribe(StartGame);
    }

    #endregion

    #region Private Methods

    private void EndGame(int playerScore)
    {
        gameEnded.Invoke(playerScore);
        fingerUp.UnSubscribe(StartGame);
    }

    private void AssignEvents()
    {
        playerDied.Subscribe(EndGame);
        fingerUp.Subscribe(StartGame);
    }

    private void UnAssignEvents()
    {
        playerDied.UnSubscribe(EndGame);
    }

    #endregion
}
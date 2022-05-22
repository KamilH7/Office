using Player;
using Player.Events;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreDisplayer : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private TMP_Text scoreText;
        [SerializeField]
        private PlayerData playerData;

        [SerializeField, Header("Listening To")]
        private ScoreChanged scoreChanged;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            AssignCallbacks();
            ResetScore();
        }

        private void OnDisable()
        {
            UnAssignCallbacks();
        }

        #endregion

        #region Private Methods

        private void ResetScore()
        {
            UpdateScoreText(playerData.CurrentScore);
        }

        private void UpdateScoreText(int newScore)
        {
            scoreText.text = newScore.ToString();
        }

        private void AssignCallbacks()
        {
            scoreChanged.Subscribe(UpdateScoreText);
        }

        private void UnAssignCallbacks()
        {
            scoreChanged.UnSubscribe(UpdateScoreText);
        }

        #endregion
    }
}
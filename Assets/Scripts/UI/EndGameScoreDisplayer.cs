using Player;
using TMPro;
using UnityEngine;

namespace UI
{
    public class EndGameScoreDisplayer : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private string scoreAffix;
        [SerializeField]
        private PlayerData playerData;
        [SerializeField]
        private TMP_Text scoreText;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            scoreText.text = $"{playerData.CurrentScore} {scoreAffix}";
        }

        #endregion
    }
}
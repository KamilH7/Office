using System.Collections;
using Player;
using Player.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private float textBlinkTime = 0.5f;
        [SerializeField]
        private PlayerData playerData;

        [Header("UI References"), SerializeField, Space(10)]
        private Image fillImage;
        [SerializeField]
        private TMP_Text healthChangeText;

        [SerializeField, Header("Listening to:")]
        private PlayerDamaged playerDamaged;
        [SerializeField]
        private PlayerHealed playerHealed;

        #endregion

        #region Private Fields

        private Coroutine textBlinkCoroutine;

        #endregion

        #region Unity Callbacks

        private void OnEnable()
        {
            AssignCallbacks();
            RestartHealthBar();
        }

        private void OnDisable()
        {
            UnAssignCallbacks();
        }

        #endregion

        #region Private Methods

        private void RestartHealthBar()
        {
            DisableHealthChangeText();
            UpdateHealthBar();
        }

        private void PlayerHealthIncreased(float changeAmount)
        {
            UpdateHealthBar();
            BlinkText($"+{changeAmount}");
        }

        private void PlayerHealthDecreased(float changeAmount)
        {
            UpdateHealthBar();
            BlinkText($"{changeAmount}");
        }

        private void UpdateHealthBar()
        {
            fillImage.fillAmount = playerData.GetHealthPercentage();
        }

        private void BlinkText(string text)
        {
            if (textBlinkCoroutine != null)
            {
                StopCoroutine(textBlinkCoroutine);
            }

            textBlinkCoroutine = StartCoroutine(BlinkHealthChangeText(text));
        }

        private IEnumerator BlinkHealthChangeText(string text)
        {
            healthChangeText.text = text;
            EnableHealthChangeText();

            yield return new WaitForSeconds(textBlinkTime);

            DisableHealthChangeText();
            textBlinkCoroutine = null;
        }

        private void DisableHealthChangeText()
        {
            healthChangeText.enabled = false;
        }

        private void EnableHealthChangeText()
        {
            healthChangeText.enabled = true;
        }

        private void AssignCallbacks()
        {
            playerDamaged.Subscribe(PlayerHealthDecreased);
            playerHealed.Subscribe(PlayerHealthIncreased);
        }

        private void UnAssignCallbacks()
        {
            playerDamaged.UnSubscribe(PlayerHealthDecreased);
            playerHealed.UnSubscribe(PlayerHealthIncreased);
        }

        #endregion
    }
}
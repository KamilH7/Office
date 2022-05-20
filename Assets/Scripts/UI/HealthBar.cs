using System.Collections;
using Player;
using Player.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    #region Serialized Fields

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

    private IEnumerator textBlinkCoroutine;

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
        DisableHealthChangeText();
        UpdateHealthBar();
    }

    #endregion

    #region Private Methods

    private void PlayerHealthIncreased(float changeAmount)
    {
        UpdateHealthBar();
        RestartTextBlinkCoroutine($"+{changeAmount}");
    }

    private void PlayerHealthDecreased(float changeAmount)
    {
        UpdateHealthBar();
        RestartTextBlinkCoroutine($"{changeAmount}");
    }

    private void UpdateHealthBar()
    {
        fillImage.fillAmount = playerData.GetHealthPercentage();
    }

    private void RestartTextBlinkCoroutine(string text)
    {
        if (textBlinkCoroutine != null)
        {
            StopCoroutine(textBlinkCoroutine);
        }

        textBlinkCoroutine = BlinkHealthChangeText(text);
        StartCoroutine(textBlinkCoroutine);
    }

    private IEnumerator BlinkHealthChangeText(string text)
    {
        healthChangeText.text = text;
        EnableHealthChangeText();

        yield return new WaitForSeconds(1);

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
        playerDamaged.Subscribe(PlayerHealthIncreased);
        playerHealed.Subscribe(PlayerHealthDecreased);
    }

    private void UnAssignCallbacks()
    {
        playerDamaged.UnSubscribe(PlayerHealthIncreased);
        playerHealed.UnSubscribe(PlayerHealthDecreased);
    }

    #endregion
}
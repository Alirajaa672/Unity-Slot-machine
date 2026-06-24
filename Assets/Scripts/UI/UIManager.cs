using TMPro;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [Header("Main UI")]
    public TextMeshProUGUI balanceText;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI betText;

    [Header("Statistics UI")]
    public TextMeshProUGUI spinsText;
    public TextMeshProUGUI winsText;
    public TextMeshProUGUI winRateText;
    public TextMeshProUGUI biggestWinText;

    [Header("Managers")]
    public BalanceManager balanceManager;
    public StatisticsManager statisticsManager;

    [Header("Win Screen")]
    public GameObject jackpotPanel;
    public TextMeshProUGUI jackpotText;
    public ParticleSystem jackpotParticles;

    private void Start()
    {
        UpdateBalance();
        UpdateBet();
        UpdateStatistics();

        if (resultText != null)
            resultText.text = "";

        if (jackpotPanel != null)
            jackpotPanel.SetActive(false);
    }

    public void UpdateBalance()
    {
        if (balanceText != null)
        {
            balanceText.text =
                "Balance: $" +
                balanceManager.balance;
        }
    }

    public void UpdateBet()
    {
        if (betText != null)
        {
            betText.text =
                "Bet: $" +
                balanceManager.currentBet;
        }
    }

    public void UpdateStatistics()
    {
        if (statisticsManager == null)
            return;

        if (spinsText != null)
        {
            spinsText.text =
                "Spins: " +
                statisticsManager.totalSpins;
        }

        if (winsText != null)
        {
            winsText.text =
                "Wins: " +
                statisticsManager.totalWins;
        }

        if (winRateText != null)
        {
            winRateText.text =
                "Win Rate: " +
                statisticsManager.WinRate.ToString("F1") +
                "%";
        }

        if (biggestWinText != null)
        {
            biggestWinText.text =
                "Biggest Win: $" +
                statisticsManager.biggestWin;
        }
    }

    public void ShowWin(int reward)
    {
        if (resultText == null)
            return;

        resultText.color = Color.green;

        resultText.text =
            "YOU WIN $" + reward;

        resultText.transform.localScale =
            Vector3.one;

        resultText.transform
            .DOScale(1.3f, 0.25f)
            .SetLoops(2, LoopType.Yoyo);
    }

    public void ShowLose()
    {
        if (resultText == null)
            return;

        resultText.color = Color.red;

        resultText.text =
            "YOU LOST";

        resultText.transform.localScale =
            Vector3.one;

        resultText.transform
            .DOShakePosition(
                0.3f,
                10f
            );
    }

    public void ShowGameOver()
    {
        if (resultText == null)
            return;

        resultText.color = Color.red;

        resultText.text =
            "GAME OVER";

        resultText.transform.localScale =
            Vector3.one;

        resultText.transform
            .DOScale(1.2f, 0.3f)
            .SetLoops(4, LoopType.Yoyo);
    }

    public void ShowWinScreen(
        string symbolName,
        int reward)
    {
        if (jackpotPanel == null ||
            jackpotText == null)
            return;

        jackpotPanel.SetActive(true);

        switch (symbolName)
        {
            case "Cherry":
                jackpotText.color = Color.red;
                break;

            case "Bell":
                jackpotText.color = Color.yellow;
                break;

            case "Diamond":
                jackpotText.color = Color.cyan;
                break;

            case "Seven":
                jackpotText.color = Color.magenta;
                break;

            default:
                jackpotText.color = Color.white;
                break;
        }

        jackpotText.text =
            symbolName.ToUpper() +
            " WIN!\n$" +
            reward;

        jackpotText.transform.localScale =
            Vector3.zero;

        jackpotText.transform
            .DOScale(1f, 0.5f)
            .SetEase(Ease.OutBack);

        if (jackpotParticles != null)
        {
            jackpotParticles.Play();
        }

        Invoke(
            nameof(HideWinScreen),
            2.5f
        );
    }

    private void HideWinScreen()
    {
        if (jackpotPanel != null)
        {
            jackpotPanel.SetActive(false);
        }
    }

    public void ClearResult()
    {
        if (resultText != null)
        {
            resultText.text = "";
        }
    }
}
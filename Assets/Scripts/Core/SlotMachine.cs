// DOTween Animations Added
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class SlotMachine : MonoBehaviour
{
    public Reel[] reels;
    public SymbolData[] symbols;

    public BalanceManager balanceManager;
    public UIManager uiManager;
    public AudioManager audioManager;
    public StatisticsManager statisticsManager;

    public Button spinButton;

    private bool isSpinning;

    public void Spin()
    {
        if (isSpinning)
            return;

        foreach (Reel reel in reels)
        {
            reel.symbol.glow.SetActive(false);
        }

        if (balanceManager.balance <= 0)
        {
            uiManager.ShowGameOver();
            spinButton.interactable = false;
            return;
        }

        uiManager.ClearResult();

        if (balanceManager.balance < balanceManager.currentBet)
        {
            uiManager.ShowLose();
            return;
        }

        spinButton.transform
            .DOScale(0.9f, 0.1f)
            .SetLoops(2, LoopType.Yoyo);

        audioManager?.PlayButton();

        statisticsManager.RegisterSpin();
        uiManager.UpdateStatistics();

        StartCoroutine(SpinRoutine());
    }

    IEnumerator SpinRoutine()
    {
        isSpinning = true;
        spinButton.interactable = false;

        balanceManager.RemoveBet();

        audioManager?.PlaySpin();

        SymbolData[] results = new SymbolData[reels.Length];

        // FIXED: use the full symbol array
        for (int i = 0; i < reels.Length; i++)
        {
            int randomIndex = Random.Range(0, symbols.Length);
            results[i] = symbols[randomIndex];
        }

        // Each reel spins slightly longer
        for (int i = 0; i < reels.Length; i++)
        {
            yield return StartCoroutine(
                reels[i].Spin(
                    symbols,
                    results[i],
                    i * 0.35f
                )
            );

            yield return new WaitForSeconds(0.15f);
        }

        CheckWin();

        spinButton.interactable = true;
        isSpinning = false;
    }

    void CheckWin()
    {
        SymbolData first = reels[0].currentSymbol;
        SymbolData second = reels[1].currentSymbol;
        SymbolData third = reels[2].currentSymbol;

        if (first == second && second == third)
        {
            int reward = first.payout;

            if (first.symbolName == "Seven")
                reward = 500;

            uiManager.ShowWin(reward);
            uiManager.ShowWinScreen(first.symbolName, reward);

            foreach (Reel reel in reels)
            {
                reel.symbol.glow.SetActive(true);

                reel.symbol.glow.transform
                    .DOScale(1.2f, 0.3f)
                    .SetLoops(6, LoopType.Yoyo);
            }

            balanceManager.AddWin(reward);

            statisticsManager.RegisterWin(reward);
            uiManager.UpdateStatistics();

            audioManager?.PlayWin();

            StartCoroutine(reels[0].FlashWin());
            StartCoroutine(reels[1].FlashWin());
            StartCoroutine(reels[2].FlashWin());
        }
        else
        {
            uiManager.ShowLose();
        }
    }
}
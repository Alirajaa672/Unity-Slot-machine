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

        reels[0].symbol.glow.SetActive(false);
        reels[1].symbol.glow.SetActive(false);
        reels[2].symbol.glow.SetActive(false);

        if (balanceManager.balance <= 0)
        {
            uiManager.ShowGameOver();

            spinButton.interactable = false;

            return;
        }

        uiManager.ClearResult();

        if (balanceManager.balance <
            balanceManager.currentBet)
        {
            uiManager.ShowLose();
            return;
        }

        spinButton.transform
            .DOScale(0.9f, 0.1f)
            .SetLoops(2, LoopType.Yoyo);

        if (audioManager != null)
            audioManager.PlayButton();

        statisticsManager.RegisterSpin();
        uiManager.UpdateStatistics();

        StartCoroutine(
            SpinRoutine()
        );
    }

    IEnumerator SpinRoutine()
    {
        isSpinning = true;

        spinButton.interactable = false;

        balanceManager.RemoveBet();

        if (audioManager != null)
            audioManager.PlaySpin();

        SymbolData[] results =
            new SymbolData[reels.Length];

        for (int i = 0; i < reels.Length; i++)
        {
            int randomIndex =
                Random.Range(
                    2,
                    symbols.Length
                );

            results[i] =
                symbols[randomIndex];
        }

        for (int i = 0; i < reels.Length; i++)
        {
            yield return StartCoroutine(
                reels[i].Spin(
                    symbols,
                    results[i]
                )
            );

            yield return new WaitForSeconds(
                0.25f
            );
        }

        CheckWin();

        spinButton.interactable = true;

        isSpinning = false;
    }

    void CheckWin()
    {
        SymbolData first =
            reels[0].currentSymbol;

        SymbolData second =
            reels[1].currentSymbol;

        SymbolData third =
            reels[2].currentSymbol;

        if (first == second &&
            second == third)
        {
            int reward =
                first.payout;

            bool isJackpot =
                first.symbolName ==
                "Seven";

            if (isJackpot)
            {
                reward = 500;
            }

            uiManager.ShowWin(
                reward
            );

            uiManager.ShowWinScreen(
                first.symbolName,
                reward
            );

            reels[0].symbol.glow.SetActive(true);
            reels[1].symbol.glow.SetActive(true);
            reels[2].symbol.glow.SetActive(true);

            reels[0].symbol.glow.transform
                .DOScale(1.2f, 0.3f)
                .SetLoops(6, LoopType.Yoyo);

            reels[1].symbol.glow.transform
                .DOScale(1.2f, 0.3f)
                .SetLoops(6, LoopType.Yoyo);

            reels[2].symbol.glow.transform
                .DOScale(1.2f, 0.3f)
                .SetLoops(6, LoopType.Yoyo);

            balanceManager.AddWin(
                reward
            );

            statisticsManager.RegisterWin(
                reward
            );

            uiManager.UpdateStatistics();

            if (audioManager != null)
                audioManager.PlayWin();

            reels[0].symbol.transform
                .DOScale(1.25f, 0.2f)
                .SetLoops(6, LoopType.Yoyo);

            reels[1].symbol.transform
                .DOScale(1.25f, 0.2f)
                .SetLoops(6, LoopType.Yoyo);

            reels[2].symbol.transform
                .DOScale(1.25f, 0.2f)
                .SetLoops(6, LoopType.Yoyo);

            Debug.Log(
                "WIN! Reward = " +
                reward
            );
        }
        else
        {
            if (audioManager != null)
                audioManager.PlayLose();

            uiManager.ShowLose();

            Debug.Log("LOSE");
        }
    }
    public void QuitGame()
{
    Application.Quit();

    Debug.Log("Game Closed");
}
}
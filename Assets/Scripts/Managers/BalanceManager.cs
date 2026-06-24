using UnityEngine;

public class BalanceManager : MonoBehaviour
{
    public int balance = 1000;

    public int currentBet = 10;

    public int minBet = 10;
    public int maxBet = 100;

    public UIManager uiManager;

    private void Start()
    {
        if (uiManager != null)
        {
            uiManager.UpdateBalance();
            uiManager.UpdateBet();
        }
    }

    public void RemoveBet()
    {
        balance -= currentBet;

        if (uiManager != null)
        {
            uiManager.UpdateBalance();
        }
    }

    public void AddWin(int amount)
    {
        balance += amount;

        if (uiManager != null)
        {
            uiManager.UpdateBalance();
        }
    }

    public void IncreaseBet()
    {
        currentBet += 10;

        currentBet = Mathf.Min(
            currentBet,
            maxBet
        );

        if (uiManager != null)
        {
            uiManager.UpdateBet();
        }
    }

    public void DecreaseBet()
    {
        currentBet -= 10;

        currentBet = Mathf.Max(
            currentBet,
            minBet
        );

        if (uiManager != null)
        {
            uiManager.UpdateBet();
        }
    }
}
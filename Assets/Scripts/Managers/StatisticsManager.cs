// Statistics Manager Added
using UnityEngine;

public class StatisticsManager : MonoBehaviour
{
    public int totalSpins;
    public int totalWins;
    public int biggestWin;

    public float WinRate
    {
        get
        {
            if (totalSpins == 0)
                return 0f;

            return (float)totalWins /
                   totalSpins * 100f;
        }
    }

    public void RegisterSpin()
    {
        totalSpins++;
    }

    public void RegisterWin(int reward)
    {
        totalWins++;

        if (reward > biggestWin)
        {
            biggestWin = reward;
        }
    }
}
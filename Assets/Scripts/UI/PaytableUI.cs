using UnityEngine;

public class PaytableUI : MonoBehaviour
{
    public GameObject paytablePanel;

    public void OpenPaytable()
    {
        paytablePanel.SetActive(true);
    }

    public void ClosePaytable()
    {
        paytablePanel.SetActive(false);
    }
}
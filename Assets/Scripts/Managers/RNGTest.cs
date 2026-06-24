using UnityEngine;

public class RNGTest : MonoBehaviour
{
    public RNGManager rng;

    private void Start()
    {
        int randomNumber =
            rng.GetRandomIndex(5);

        Debug.Log(randomNumber);
    }
}
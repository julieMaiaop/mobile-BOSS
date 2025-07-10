using UnityEngine;
using TMPro;


public class PlayerColect : MonoBehaviour
{
    public int coinCount = 0;
    public TMP_Text coinText; // agora aceita TextMeshPro

    void Start()
    {
        UpdateUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            Destroy(other.gameObject);
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        coinText.text = "Moedas: " + coinCount;
    }
}


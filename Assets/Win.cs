using UnityEngine;
using TMPro;
public class Win : MonoBehaviour
{
    string winnerName;
    public TMP_Text winText;
    public bool won = false;
    public void OnTriggerEnter(Collider other)
    {
        if (!won)
        {
            winnerName = other.name;
            won = true;
        }

    }
    public void Update()
    {
        if (won)
        {
            winText.text = "Winner is " + winnerName;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    Text healthText;
    GameSession gameSession;
    // Start is called before the first frame update
    void Start()
    {
        healthText = FindObjectOfType<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = gameSession.GetHealth().ToString();
    }
}

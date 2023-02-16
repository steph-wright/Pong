using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestRallyScript : MonoBehaviour
{
    private TMP_Text text;
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "BEST RALLY: " + PlayerPrefs.GetInt("HighScore", logic.Rally);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RallyCounter : MonoBehaviour
{
    public LogicScript Logic;
    private TMP_Text text;


    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "RALLY: " + Logic.Rally;
    }
}

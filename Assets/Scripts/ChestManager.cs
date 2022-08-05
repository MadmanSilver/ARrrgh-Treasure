using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestManager : MonoBehaviour
{
    public TextMesh goldText;
    public int gold;
    public GameObject popup;

    private float goldTick = 0.0f;
    private int goldTickValue = 0;
    private float goldTickRate = 1.0f;
    private bool tut = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldTick += Time.deltaTime;

        if (goldTick > goldTickRate) {
            goldTick -= goldTickRate;
            gold += goldTickValue;
        }

        if (goldText.gameObject.activeSelf) {
            goldText.text = gold.ToString();
        }

        if (tut && gold > 10) {
            popup.SetActive(true);
        }
    }

    public void Tutorial() {
        gold = 0;
        goldTickValue = 1;
        tut = true;
    }
}

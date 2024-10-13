using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactManager : MonoBehaviour
{
    public Text Fact;
    private string[] facts = new string[18] 
    {
        "Fact 1: ...", "Fact 2: ...", "Fact 3: ...",
        "Fact 4: ...", "Fact 5: ...", "Fact 6: ...",
        "Fact 7: ...", "Fact 8: ...", "Fact 9: ...",
        "Fact 10: ...", "Fact 11: ...", "Fact 12: ...",
        "Fact 13: ...", "Fact 14: ...", "Fact 15: ...",
        "Fact 16: ...", "Fact 17: ...", "Fact 18: ..."
    };

    void Start()
    {
        // Obtain the right saved index
        int factIndex = PlayerPrefs.GetInt("SelectedFact", 0); 
        ShowFact(factIndex); 
    }

    public void ShowFact(int slotNumber)
    {
        Fact.text = facts[slotNumber];
    }
}

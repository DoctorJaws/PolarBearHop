using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactManager : MonoBehaviour
{
    public Text Fact;
    private string[] facts = new string[18] 
    {
        "Polar bears primarily hunt seals on sea ice, so shrinking ice cover directly impacts their access to food.", 
        "Less sea ice means fewer suitable denning sites for mothers to raise cubs, impacting reproduction rates.", 
        "As ice retreats, polar bears are forced to swim longer distances to find food, which can be energetically demanding, especially for cubs.",
        "With less sea ice, polar bears are more likely to venture onto land, increasing the risk of encounters with human settlements and potential conflicts.", 
        "The loss of polar bears, as apex predators, can disrupt the entire Arctic food chain.", 
        "The Arctic is warming at a rate roughly twice the global average, significantly impacting the polar bear habitat.",
        "Besides polar bears, other Arctic species like seals, walruses, and Arctic foxes are also threatened by diminishing sea ice.", 
        "Scientists predict significant declines in polar bear populations if climate change continues at current rates.", 
        "While polar bears can adapt to some extent, their ability to adjust to rapidly changing Arctic conditions is limited.",
        "Efforts to mitigate climate change through reducing greenhouse gas emissions are crucial to protecting polar bears and the Arctic ecosystem.", 
        "The Arctic sea ice extent has decreased by about 13% per decade since the late 1970s.", 
        "Thinner ice due to warming allows more sunlight to penetrate the ocean, further accelerating ice melt and warming.",
        "Polar bears rely on their thick fur and fat layers for insulation, but as ice melts, they face challenges with overheating.", 
        "Overfishing and industrial activities in the Arctic are additional threats to polar bears, compounding the effects of climate change.", 
        "The warming Arctic influences global weather patterns, causing extreme events like heatwaves and unusual weather elsewhere.",
        "Melting Arctic ice contributes to rising sea levels, which threaten coastal communities worldwide.", 
        "Increased oil and gas exploration in the Arctic increases the risk of pollution and habitat destruction.", 
        "International agreements like the Paris Accord aim to limit global warming and reduce the impact on Arctic biomes."
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Resource
{   // I made this script with the help of this tutorial: https://www.youtube.com/watch?v=fE0R6WLpmrE&ab_channel=ConsideraCore

    using static ResearchPointManager;

    public class TechTree : MonoBehaviour
    {
        public static TechTree techTree;
        private void Awake() => techTree = this;

        public bool[] canLearn;
        public bool[] isLearned;
        public string[] techNames;
        public string[] techDescriptions;

        public Tech[] techList;

        public GameObject ResearchPointManager;
        public TMP_Text researchPointsText;

        // Start is called before the first frame update
        void Start()
        {
            UpdateAllTechUI();
        }

        public void UpdateAllTechUI()
        {
            foreach (var tech in techList) tech.UpdateUI();
            researchPointsText.text = "Research points: " + researchPointManager.researchPoints;
        }
    } 
}

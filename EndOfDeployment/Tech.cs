using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Resource
{   // I made this script with the help of this tutorial: https://www.youtube.com/watch?v=fE0R6WLpmrE&ab_channel=ConsideraCore

    using static TechTree;
    using static ResearchPointManager;

    public class Tech : MonoBehaviour
    {
        public int id;

        public TMP_Text nameText;
        public TMP_Text descriptionText;

        public Tech[] connectedTechs;
        public Tech[] requiredTechs;

        public void UpdateUI()
        {
            // Gives the tech a correct name from tehcs array
            nameText.text = $"{techTree.techNames[id]}";
            descriptionText.text = $"{techTree.techDescriptions[id]}";
            
            // Changes the color of the tech button according to its learning state
            GetComponent<Image>().color = techTree.canLearn[id] == false && techTree.isLearned[id] == false ? Color.red
            : techTree.canLearn[id] == true && techTree.isLearned[id] == false ? Color.yellow : Color.green;
        }

        // Handles tech learning when the tech button is clicked and requirements for learning are met
        public void LearnTech()
        {
            if (researchPointManager.researchPoints < 1 || !techTree.canLearn[id] || techTree.isLearned[id]) return;

            researchPointManager.researchPoints -= 1;
            techTree.isLearned[id] = true;

            // Makes any connected techs available to learn
            foreach (var connectedTech in connectedTechs) 
            { 
                if (connectedTech.IsRequiredTechsLearned())
                {
                    techTree.canLearn[connectedTech.id] = true;
                }
            } 
            techTree.UpdateAllTechUI();
        }

        private bool IsRequiredTechsLearned()
        {
            foreach (var requiredtech in requiredTechs)
            {
                if(requiredtech == null)
                {

                }
                else if (techTree.isLearned[requiredtech.id] == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

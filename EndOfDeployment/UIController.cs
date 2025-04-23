using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Resource
{
    public class UIController : MonoBehaviour
    {
        public GameObject techTreeUI;
        public GameObject modulesUI;
        public GameObject techTreeButton;
        public GameObject modulesButton;
        public GameObject[] moduleSlots;
        public GameObject[] acquiredModules;

        public TechTree techTree;

        // Start is called before the first frame update
        void Start()
        {
            ActivateTechTreeUI();
        }

        public void ActivateTechTreeUI()
        {
            techTreeUI.SetActive(true);
            modulesUI.SetActive(false);

            techTreeButton.GetComponent<Image>().color = Color.black;
            modulesButton.GetComponent<Image>().color = Color.white;
        }

        public void ActivateModulesUI()
        {
            techTreeUI.SetActive(false);
            modulesUI.SetActive(true);

            foreach (GameObject slots in moduleSlots)
            {
                slots.SetActive(false);
            }

            foreach(GameObject modules in acquiredModules)
            {
                modules.SetActive(false);
            }

            int id = 0;
            foreach (bool isLearned in techTree.isLearned)
            {
                if (isLearned)
                {
                    acquiredModules[id].SetActive(true);
                }
                id++;
            }

            techTreeButton.GetComponent<Image>().color = Color.white;
            modulesButton.GetComponent<Image>().color = Color.black;
        }
    } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JA73Character;

namespace Resource
{
    public class ModuleSystem : MonoBehaviour
    {
        public WarForm warform;
        public GameObject[] gearButtons;
        public GameObject[] slotButtons;
        public Gear selectedGear;
        public Module selectedModule;

        // Start is called before the first frame update
        void Start()
        {
            warform = GameObject.Find("WarForm").GetComponent<WarForm>();

            FilterButtons(gearButtons, warform.gears.Length);
        }

        public void FilterButtons(GameObject[] buttonArray, int arrayLength)
        {
            foreach (GameObject buttons in buttonArray)
            {
                buttons.SetActive(false);
            }

            for (int i = 0; i < arrayLength; i++)
            {
                buttonArray[i].SetActive(true);
            }
        }

        public void SelectGear(int gearSlot)
        {
            selectedGear = warform.gears[gearSlot];
            FilterButtons(slotButtons, selectedGear.GetInternalModulesSize());
        }

        public void SelectModule(Module module)
        {
            selectedModule = module;

        }

        public void InstalModule(int moduleSlot)
        {
            if (selectedModule != null)
            {
                selectedGear.internalModules[moduleSlot] = selectedModule;
                warform.EshtablishGear();
            }
        }
    } 
}

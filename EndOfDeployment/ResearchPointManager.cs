using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Resource
{
    public class ResearchPointManager : MonoBehaviour
    {
        public static ResearchPointManager researchPointManager;
        public int researchPoints;

        private void Awake()
        {
            if (researchPointManager == null)
            {
                researchPointManager = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (researchPointManager != this)
            {
                Destroy(gameObject);
            }
        }

        public void IncreaseScore()
        {
            researchPoints += 1;
        }
    } 
}

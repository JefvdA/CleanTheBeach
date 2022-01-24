using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class ShowLevelCompletedBg : MonoBehaviour
    {
        [SerializeField] private Sprite cityBg;
        [SerializeField] private Sprite beachBg;

        [SerializeField] private Image bgImage;

        private void Start()
        {
            if (GameManager.instance.lastPlayedLevel == "CityLevel")
                bgImage.sprite = cityBg;
            else
                bgImage.sprite = beachBg;
        }
    }
}
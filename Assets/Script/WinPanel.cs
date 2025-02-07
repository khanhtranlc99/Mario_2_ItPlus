using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    public Button btnNext;
    private void Start()
    {
        btnNext.onClick.AddListener(delegate
        {
            var currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
            currentLevel += 1;
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);
            SceneManager.LoadScene("GamePlay");

        });
    }
}

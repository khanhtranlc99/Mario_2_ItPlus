using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    public TMP_Text tmp_Level;
    public TMP_Text tmp_Coin;
    public Button btn_Setting;
    public GameObject panelSetting;

    private void Start()
    {
        btn_Setting.onClick.AddListener(HandleOnCliclSettingBtn);
        tmp_Level.text = "Level " + PlayerPrefs.GetInt("CurrentLevel", 1);
        tmp_Coin.text = PlayerPrefs.GetInt("Coin", 1000).ToString() + " <sprite name=\"Coin\">";

    }


    private void HandleOnCliclSettingBtn()
    {
        panelSetting.SetActive(true);

    }    



}

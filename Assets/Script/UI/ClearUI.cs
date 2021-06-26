using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearUI : MonoBehaviour
{
    // Start is called before the first frame update
    public void SetClearUI(bool isClear, Scene stageNumber)
    {
        this.isClear = isClear;
        Debug.Log("Start Clear UI");
        switch (stageNumber)
        {
            case Scene.FirstStage:
                this.stageText.text = "FIRST STAGE";
                currentScene = Scene.FirstStage;
                break;
            case Scene.MiddleStage:
                this.stageText.text = "MIDDLE STAGE";
                currentScene = Scene.MiddleStage;
                break;
            case Scene.FinalStage:
                this.stageText.text = "FINAL STAGE";
                currentScene = Scene.FinalStage;
                break;
        }
        failObj.SetActive(!this.isClear);
        clearObj.SetActive(this.isClear);
        foreach (CharacterUI charUI in characterList)
        {
            if (this.isClear)
            {
                charUI.ActionClear();
            }
            else
            {
                charUI.ActionFail();
            }
        }

        this.homeBtn.SetActive(true);
        this.retryBtn.SetActive(!isClear);
        this.nextBtn.SetActive(isClear && this.currentScene != Scene.FinalStage);
        this.rewardUI.SetActive(isClear);
    }

    public void OnClickHomeBtn()
    {
        SceneLoadManager.Instance.MoveScene(Scene.KingdomScene);
        if (this.isClear)
        {
            DataManager.Instance.AddCoin(10);
            DataManager.Instance.SaveJsonData(DataManager.Instance.UserData);
        }

    }

    public void OnClickRetryBtn()
    {
        SceneLoadManager.Instance.MoveScene(currentScene);
        if (this.isClear)
        {
            DataManager.Instance.AddCoin(10);
            DataManager.Instance.SaveJsonData(DataManager.Instance.UserData);
        }
    }

    public void OnClickNextBtn()
    {
        SceneLoadManager.Instance.MoveScene(currentScene + 1);
    }

    protected void Start()
    {
        SetClearUI(DataManager.Instance.UserData.isClear, DataManager.Instance.UserData.currentScene);
    }

    [SerializeField] Text stageText;
    [SerializeField] GameObject clearObj;
    [SerializeField] GameObject failObj;
    [SerializeField] GameObject rewardUI;
    [SerializeField] GameObject homeBtn;
    [SerializeField] GameObject retryBtn;
    [SerializeField] GameObject nextBtn;
    [SerializeField] List<CharacterUI> characterList;

    private Scene currentScene;
    private bool isClear;

    private void OnDisable()
    {
        DataManager.Instance.UserData.isClear = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;

public enum CharectorType
{
    Small,
    Big,
    Special
}
public class GamePlaycontroller : MonoBehaviour
{
    public static GamePlaycontroller instance;
    [Header("Charector------------------------------------")]
    public CharectorBase currentCharector;
    [SerializeField] private CharectorBase smallCharectorPrefab;
    [SerializeField] private CharectorBase bigCharectorPrefab;
    [SerializeField] private CharectorBase specialCharectorPrefab;
    [Header("------------------------------------")]

    [SerializeField] private Transform firtPost;
    [SerializeField] private ProCamera2D camera2D;

    [SerializeField] private List<GameObject> lsLevelData;

    public LevelData levelData;
    public GameObject winPanel;
    public GameObject losePanel;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Debug.LogError("CurrentLevel" + PlayerPrefs.GetInt("CurrentLevel", 1));
        var levelObj = Resources.Load<GameObject>("Level_" + PlayerPrefs.GetInt("CurrentLevel", 1));
        if(levelObj != null)
        {
            levelData = Instantiate(levelObj).GetComponent<LevelData>();
            firtPost = levelData.firstPost;
            currentCharector = Instantiate(smallCharectorPrefab);
            currentCharector.transform.position = firtPost.position;
            camera2D.AddCameraTarget(currentCharector.transform);
        }    
     
    }


    public void ChangeCharector(CharectorType charectorType)
    {
      
        camera2D.RemoveAllCameraTargets();
        var currentPost = currentCharector.transform.position;
        Destroy(currentCharector.gameObject);
        currentCharector = null;
   
        switch (charectorType)
        {
           case CharectorType.Small:
                currentCharector = Instantiate(smallCharectorPrefab);
       
                break;
            case CharectorType.Big:
                currentCharector = Instantiate(bigCharectorPrefab);
               
                break;
            case CharectorType.Special:
                currentCharector = Instantiate(specialCharectorPrefab);
              
                break;
        }
 
        currentCharector.transform.position = currentPost;
        camera2D.AddCameraTarget(currentCharector.transform);

    }


    public void HandleSetCurrentToFirstPossition()
    {
        currentCharector.transform.position = firtPost.position;
    }

    public void MoveLeft()
    {
        currentCharector.isLeft = true;
     
    }
    public void MoveRight()
    {
     
        currentCharector.isRight = true;
    }


    public void OffLeft()
    {
        currentCharector.isLeft = false;

    }
    public void OffRight()
    {
        currentCharector.isRight = false;

    }

    public void Jump()
    {
        currentCharector.Move(ActionType.Jump);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private GameObject levelSelectBtnPrefab;
    [SerializeField] private Transform  levelSelectBtnParent;
    [SerializeField] private GameControl gameControl;
    [SerializeField] private LevelDetails levelDetailsSo;

    private void Start()
    {
        foreach (var levelBtn in levelDetailsSo.levelDetailList)
        {
            var levelBtnObj = Instantiate(levelSelectBtnPrefab, levelSelectBtnParent);
            levelBtnObj.transform.GetChild(0).GetComponent<Text>().text = $"Level\n{levelBtn.level}";
            levelBtnObj.GetComponent<Button>().onClick.AddListener(() =>
            {
                gameControl.StartGame(levelBtn.timeLimit);
            });
        }
    }
    
}

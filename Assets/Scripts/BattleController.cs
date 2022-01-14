using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Classes;
using BattleClasses;

public class BattleController : MonoBehaviour
{
    public string battleToStart;
    private Battle currentBattle;

    public Button FirstSelectHeroBtn;
    public Button FirstSelectActionBtn;
    public Text DialogText;

    public BattleDialogController BattleDialogController;
    private BattleDialogController dialogControllerScript;

    public BattleSceneController BattleSceneController;
    private BattleSceneController sceneControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        dialogControllerScript = BattleDialogController.GetComponent<BattleDialogController>();
        sceneControllerScript = BattleSceneController.GetComponent<BattleSceneController>();
        StartBattle(battleToStart);
    }


    // Public classes 
    public void StartBattle(string battleType)
    {
        switch (battleType)
        {
            case "battle1":
                currentBattle = new Battle1();
                break;
            case "battle2":
                currentBattle = new Battle2();
                break;
            case "battle3":
                currentBattle = new Battle3();
                break;
            case "battle4":
                currentBattle = new Battle4();
                break;
            default:
                break;
        }

        dialogControllerScript.SetScene(currentBattle.GetScene());
        sceneControllerScript.SetBattle(currentBattle);

        dialogControllerScript.OpenDialog();
        sceneControllerScript.UpdatePV();
    }

    public Turn GetTurn()
    {
        return currentBattle.GetTurn();
    }
    
    public Scene GetScene()
    {
        return currentBattle.GetScene();
    }

    public void SelectAction(string action)
    {

        //if (BattleController.GetTurn().GetEntity().type == hero2)

        Debug.Log(action);
        if (action == "Special1" || action == "Special3")
        {
            FirstSelectHeroBtn.Select();
        }

    }

    public void SelectTarget(string action)
    {

        //if (BattleController.GetTurn().GetEntity().type == hero2)

        Debug.Log(action);

        FirstSelectActionBtn.Select();
    }


}

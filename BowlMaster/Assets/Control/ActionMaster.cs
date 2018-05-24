using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster{

    public enum Action { Tidy, Reset, EndTurn, EndGame };

    private int[] bowls = new int[21];
    public int bowl = 1;

    public static Action NextAction(List<int> pinFalls){
        ActionMaster am = new ActionMaster();
        Action currentAction = new Action();

        foreach(int pinFall in pinFalls){
            currentAction = am.Bowl(pinFall);
        }

        return currentAction;
    }

    public Action Bowl(int pins){

        bowls[bowl - 1] = pins;

        // Debug.Log("Now bowl = " + bowl);
        if (pins < 0 || pins > 10) throw new UnityException("Invalid pins!");

        if (bowl == 21)
        {
            bowl = 1;
            return Action.EndGame;
        }

        if (bowl == 20)
        {
            if (bowls[19 - 1] != 10)
            {
                if (Bowl21Awarded())
                {
                    bowl += 1;
                    return Action.Reset;
                }
                else
                {
                    return Action.EndGame;
                }
            }
            if(bowls[19 - 1] == 10 && pins == 10){
                bowl += 1;
                return Action.Reset;
            }else if(bowls[19 - 1] == 10 && pins != 10){
                bowl += 1;
                return Action.Tidy;
            }
        }

        if (bowl == 19)
        {
            if (pins == 10)
            {
                bowl += 1;
                return Action.Reset;
            }else
            {
                bowl += 1;
                return Action.Tidy;
            }
        }

        if (pins == 10) {
            if (bowl % 2 == 0 && bowl <= 18)
            {
                bowl += 1;
                return Action.EndTurn;
            }
            if (bowl % 2 != 0 && bowl <= 18)
            {
                bowl += 2;
                return Action.EndTurn;
            }
        } 

        if (pins >= 0 && pins < 10){
            if (bowl % 2 == 0 && bowl <= 18)
            {
                bowl += 1;
                return Action.EndTurn;
            }
            if (bowl % 2 != 0 && bowl <= 18) {
                bowl += 1;
                return Action.Tidy; 
            }
        }

        throw new UnityException("Not sure what action to return!");
    }

    private bool Bowl21Awarded(){
        return (bowls[19 - 1] + bowls[20 - 1] >= 10);
    }


}

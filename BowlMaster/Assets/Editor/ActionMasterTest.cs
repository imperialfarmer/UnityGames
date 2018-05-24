using System;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using NUnit.Compatibility;
using System.Linq;

// must be put in 'Editor'
[TestFixture]
public class ActionMasterTest {

    private List<int> pinFalls;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;

    [SetUp]
    public void Setup(){
        pinFalls = new List<int>();
    }

    [Test]
    public void Test01(){
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    } 

    [Test]
    public void Test02(){
        pinFalls.Add(1);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
        pinFalls.Add(1);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    } 

    [Test]
    public void Test03(){
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1 };
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    } 
}

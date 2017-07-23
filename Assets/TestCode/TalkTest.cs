﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Character;
using MasterData;

public class TalkTest : MonoBehaviour {
    public Container con;
    public Container plCon;

	// Use this for initialization
	void Start () {
        Citizen citizen = new Citizen();
        con.setCharacter(citizen);
        Hero hero = new Hero(JobMasterManager.getJobFromId(0), plCon);
        plCon.setCharacter(hero);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

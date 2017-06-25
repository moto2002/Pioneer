﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Character;
using Parameter;

namespace MasterData{
	[System.SerializableAttribute]
	public class EnemyBuilder{
		[SerializeField]
		private int
		id,
		aiId,
		maxHp,
		maxMp,
		mft,
		fft,
		phy,
		mgp,
		agi,
		def,
		level,
		normalDropId,
		rareDropId,
		skillSetId;

		[SerializeField]
		private string 
		name,
		modelName,
		faction;

		public EnemyBuilder(string[] parameters){
			setParameterFromCSV (parameters);
		}

		public int getId() {
			return id;
		}

		public int getAiId() {
			return aiId;
		}

		public int getMaxHp() {
			return maxHp;
		}

		public int getMaxMp() {
			return maxMp;
		}

		public int getMft() {
			return mft;
		}

		public int getFft() {
			return fft;
		}

		public int getPhy() {
			return phy;
		}

		public int getMgp() {
			return mgp;
		}

		public int getAgi() {
			return agi;
		}

		public int getDef() {
			return def;
		}

		public int getLevel() {
			return level;
		}

		public int getNormalDropId() {
			return normalDropId;
		}

		public int getRareDropId() {
			return rareDropId;
		}

		public int getSkillSetId() {
			return skillSetId;
		}

		public string getName() {
			return name;
		}

		public string getModelName() {
			return modelName;
		}

		public Faction getFaction(){
			return (Faction) Enum.Parse (typeof(Faction),this.faction);
		}

		public Enemy build(){
			Enemy returnEnemy = new Enemy (this);
			return returnEnemy;
		}

		private void setParameterFromCSV(string[] parameters){
			id = int.Parse (parameters [0]);
			name = parameters [1];
			aiId = int.Parse (parameters [2]);
			maxHp = int.Parse (parameters [3]);
			maxMp = int.Parse (parameters [4]);
			mft = int.Parse (parameters[5]);
			fft = int.Parse (parameters [6]);
			phy = int.Parse (parameters [7]);
			mgp = int.Parse (parameters [8]);
			agi = int.Parse (parameters [9]);
			def = int.Parse (parameters [10]);
			level = int.Parse (parameters [11]);
			normalDropId = int.Parse (parameters [12]);
			rareDropId = int.Parse (parameters [13]);
			skillSetId = int.Parse (parameters [14]);
			faction = parameters [15];
			modelName = "Models/" + parameters [16];
		}

		public override string ToString () {
			return "EnemyBuilder " + name;
		}
	}
}
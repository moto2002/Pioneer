﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Character;
using Parameter;
using AI;

using Ability = Parameter.CharacterParameters.Ability;
using Faction = Parameter.CharacterParameters.Faction;

namespace MasterData{
	[System.SerializableAttribute]
	public class EnemyBuilder{
		//プロパティです

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
		activeSkillSetId,
		reactionSkillSetId;

		[SerializeField]
		private string 
		name,
		modelName,
		faction;

		//csvによるstring配列から初期化します
		public EnemyBuilder(string[] parameters){
			setParameterFromCSV (parameters);
		}

		//各能力値のgetterです

		public int getId() {
			return id;
		}

		public int getAiId() {
			return aiId;
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

		public int getActiveSkillSetId() {
			return activeSkillSetId;
		}

		public int getReactionSkillSetId(){
			return reactionSkillSetId;
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

		public Dictionary<Ability,int> getAbilities(){
			return new Dictionary<Ability,int> {
				{Ability.MFT,mft},
				{Ability.FFT,fft},
				{Ability.PHY,phy},
				{Ability.MGP,mgp},
				{Ability.AGI,agi},
				{Ability.HP,maxHp},
				{Ability.MP,maxMp}			
			};
		}

		//Enemyを取得します
		public Enemy build(){
			Enemy returnEnemy = new Enemy (this);
			return returnEnemy;
		}

		//csvのstring配列から初期化します
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
			activeSkillSetId = int.Parse (parameters [14]);
			reactionSkillSetId = int.Parse (parameters[15]);
			faction = parameters [16];
			modelName = "Models/" + parameters [17];
		}

		public override string ToString () {
			return "EnemyBuilder " + name;
		}
	}
}
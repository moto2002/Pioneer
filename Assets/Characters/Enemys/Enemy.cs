﻿using System.Collections.Generic;
using System;
using UnityEngine;

using item;
using parameter;
using AI;
using masterdata;
using battleSystem;

namespace character{
	public class Enemy : IBattleable{
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

		private string 
			name,
			modelName;

		private int hp;
		private int mp;
		private int defBonus = 0;
		private int dodgeBonus = 0;
		private int atkBonus = 0;

		private bool isBattling = false;
		private bool isReadyToCounter = false;

		private Container container;

		private IEnemyAI ai;

		private readonly int UNIQE_ID;

		private readonly Faction FACTION;

		public Enemy(EnemyBuilder builder,int uniqeId){
			this.id = builder.getId ();
			this.name = builder.getName ();
			this.maxHp = builder.getMaxHp ();
			this.maxMp = builder.getMaxMp ();
			this.mft = builder.getMft ();
			this.fft = builder.getFft ();
			this.phy = builder.getPhy ();
			this.mgp = builder.getMgp ();
			this.agi = builder.getAgi ();
			this.def = builder.getDef ();
			this.level = builder.getLevel ();
			this.normalDropId = builder.getNormalDropId ();
			this.rareDropId = builder.getRareDropId ();
			this.skillSetId = builder.getSkillSetId ();
			this.modelName = builder.getModelName ();
			this.FACTION = builder.getFaction ();

			GameObject prefab = (GameObject)Resources.Load(modelName);
			GameObject gameobject = MonoBehaviour.Instantiate (prefab);
			this.container = gameobject.GetComponent<Container> ();
			container.setCharacter(this);

			this.UNIQE_ID = uniqeId;
		}

	    //エンカウントし、戦闘に突入します
		public void encount(){
			throw new NotSupportedException ();
		}

	    //このEnemyが与える経験値を取得します
		public int getGiveExp(){
			throw new NotSupportedException ();
		}

	    //このEnemyのドロップアイテムを取得します。ない場合はnullを返します
		public IItem getDrop(){
			throw new NotSupportedException ();
		}
			
		#region IBattleable implementation
		public int getHp () {
			return hp;
		}
		public int getMp () {
			return mp;
		}
		public void setHp (int hp) {
			if (hp < 0)
				throw new ArgumentException ("invlid hp");
			this.hp = hp;
		}
		public void setMp (int mp) {
			if (mp < 0)
				throw new ArgumentException ("invlid mp");
			this.mp = mp;
		}
		public int getMaxHp () {
			return maxHp;
		}
		public int getMaxMp () {
			return maxMp;
		}
		public int getMft () {
			return mft;
		}
		public int getFft () {
			return fft;
		}
		public int getMgp () {
			return mgp;
		}
		public int getAgi () {
			return agi;
		}
		public int getPhy () {
			return phy;
		}
		public int getDef () {
			return def;
		}
		public float getDelay (skill.ActiveSkill skill) {
			throw new System.NotImplementedException ();
		}
		public bool getIsBattling () {
			throw new System.NotImplementedException ();
		}
		public void setIsBattling (bool boolean) {
			isBattling = boolean;
		}
		public int move () {
			throw new System.NotImplementedException ();
		}
		public void syncronizePositioin (UnityEngine.Vector3 vector) {
			container.getModel ().transform.position = vector;
		}
		public battleSystem.BattleCommand decideCommand () {
			throw new System.NotImplementedException ();
		}
		public skill.ActiveSkill decideSkill () {
			throw new System.NotImplementedException ();
		}
		public int getRange (skill.ActiveSkill skill) {
			throw new System.NotImplementedException ();
		}
		public int getHitness (skill.ActiveSkill skill) {
			throw new System.NotImplementedException ();
		}
		public int battleAction (skill.ActiveSkill skill) {
			throw new System.NotImplementedException ();
		}
		public skill.IPassiveSkill decidePassiveSkill () {
			throw new System.NotImplementedException ();
		}
		public int getDodgeness () {
			throw new System.NotImplementedException ();
		}
		public void setDefBonus (int bonus) {
			defBonus = bonus;
		}
		public void setDodBonus (int bonus) {
			dodgeBonus = bonus;
		}
		public void setAtkBonus (int bonus) {
			atkBonus = bonus;
		}
		public void setIsReadyToCounter (bool flag) {
			isReadyToCounter = flag;
		}
		public void resetBonus () {
			defBonus = 0;
			dodgeBonus = 0;
			atkBonus = 0;
			isReadyToCounter = false;
		}
		public int getLevel () {
			return level;
		}
		List<IBattleable> IBattleable.decideTarget (List<IBattleable> bals) {
			throw new System.NotImplementedException ();
		}

		public Faction getFaction () {
			return FACTION;
		}

		public bool isHostility (Faction faction) {
			return (faction == FACTION);
		
		}
		#endregion

		#region IChracter implementation
		public GameObject getModel () {
			throw new NotImplementedException ();
		}

		public void act () {
//			Debug.Log ("Succesed");
		}

		public void death () {
			throw new NotImplementedException ();
		}
		#endregion

		public int getId(){
			return this.id;
		}

		public int getUniqeId(){
			return UNIQE_ID;
		}

		public override bool Equals (object obj) {
			//Enemyであり、IDとユニークIDが同値ならば等価と判断します
			if (!(obj == typeof(Enemy)))
				return false;
			Enemy target = (Enemy)obj;
			if (target.getUniqeId () != this.getUniqeId() && target.getId() != this.getId())
				return false;
			return true;
		}

		public void dammage (int dammage, skill.SkillAttribute attribute) {
			throw new NotImplementedException ();
		}

		public void healed (int heal, skill.HealAttribute attribute) {
			throw new NotImplementedException ();
		}

		public float getDelay (float delay) {
			throw new NotImplementedException ();
		}

		public int move (int moveAmount) {
			throw new NotImplementedException ();
		}

		public int getRange (int range) {
			throw new NotImplementedException ();
		}

		public int getHitness (int hitness) {
			throw new NotImplementedException ();
		}

		public int attack (int baseParameter, Ability useAbility) {
			throw new NotImplementedException ();
		}

		public int healing (int baseParameter, Ability useAbility) {
			throw new NotImplementedException ();
		}
	}
}
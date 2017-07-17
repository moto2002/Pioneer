﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Item;
using BattleAbility = Parameter.CharacterParameters.BattleAbility;

namespace MasterData{
	[System.SerializableAttribute]
	public class WeponBuilder{
		//プロパティです

		[SerializeField]
		private int
		id,
		attack,
		range,
		needMft,
		itemValue,
		mass;

		[SerializeField]
		private string 
		name,
		description,
        flavorText;

		private float delay;

        private BattleAbility weponAbility;
        private WeponType weponType;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="datas">データを表すstring配列</param>
		public WeponBuilder(string[] datas){
			setFromCSV (datas);
		}

		//各プロパティのgetterです

		public int getId(){
			return id;
		}

		public int getAttack() {
			return attack;
		}

		public int getRange() {
			return range;
		}

		public int getNeedMft() {
			return needMft;
		}

		public int getItemValue() {
			return itemValue;
		}

		public int getMass(){
			return mass;
		}

		public string getName() {
			return name;
		}

		public string getDescription() {
			return description;
		}
		public string getFlavorText(){
			return flavorText;
		}

		public float getDelay() {
			return delay;
		}

		public WeponType getWeponType(){
            return weponType;
		}

        public BattleAbility getWeponAbility(){
            return weponAbility;
        }

		/// <summary>
        /// csvから初期化を行います
        /// </summary>
        /// <param name="datas">csvのstring配列</param>
		private void setFromCSV(string[] datas){
			this.id = int.Parse (datas[0]);
			this.name = datas [1];
			this.attack = int.Parse (datas[2]);
			this.range = int.Parse (datas[3]);
			this.delay = float.Parse (datas[4]);
			this.needMft = int.Parse (datas [5]);
			this.itemValue = int.Parse (datas[6]);
			this.mass = int.Parse (datas[7]);
			this.weponType = (WeponType)Enum.Parse(typeof(WeponType), datas[8]);
			this.weponAbility = (BattleAbility)Enum.Parse(typeof(BattleAbility), datas[9]);
			this.description = datas [10];
			this.flavorText = datas [11];
		}

		/// <summary>
        /// 武器を生成します
        /// </summary>
        /// <returns>生成した武器</returns>
		public Wepon build(){
			return new Wepon(this);
		}

		public override string ToString(){
			return "wepon " + name;
		}
	}
}
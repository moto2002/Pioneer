﻿using System;
using UnityEngine;

using Character;
using BattleSystem;

using MasterData;

using BattleAbility = Parameter.CharacterParameters.BattleAbility;

namespace Item{
	public class  Wepon :  IItem{
		private readonly int
            ID,
			/// <summary> 武器の攻撃力 </summary>
			ATTACK,
			/// <summary> この武器の射程 </summary>
			RANGE,
			/// <summary> 装備するのに必要な能力値　この能力値はweponAbitliyで設定します </summary>
            NEED_ABILITY,
			/// <summary> アイテムの基本価格 </summary>
			ITEM_VALUE,
			/// <summary> アイテムの重さ </summary>
			MASS;

		private readonly string 
			/// <summary> アイテム名 </summary>
			name,
			/// <summary> アイテムの説明 </summary>
			description,
			/// <summary> 装備条件の説明 </summary>
            flavorText;

		/// <summary> 武器のディレイ値 </summary>
		private float DELAY;

		/// <summary> 武器の種別 </summary>
		private WeponType type;

        /// <summary> 武器が使用するBattleAbility </summary>
		private BattleAbility weponAbility;

        private bool canStore;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="builder">ビルダー</param>
		public Wepon(WeponBuilder builder){
            ID = builder.getId();
			ATTACK = builder.getAttack ();
			RANGE = builder.getRange ();
			NEED_ABILITY = builder.getNeedMft ();
			ITEM_VALUE = builder.getItemValue ();
			MASS = builder.getMass ();
			name = builder.getName ();
			description = builder.getDescription ();
			flavorText = builder.getFlavorText ();
			type = builder.getWeponType ();
			DELAY = builder.getDelay ();
            weponAbility = builder.getWeponAbility();
		}

		/// <summary>
        /// 攻撃力を取得します
        /// </summary>
        /// <returns>攻撃力</returns>
		public int getAttack() {
			return ATTACK;
		}

		/// <summary>
        /// 射程を取得します
        /// </summary>
        /// <returns>射程</returns>
		public int getRange() {
			return RANGE;
		}

		/// <summary>
        /// 装備に必要な能力値を取得します
        /// </summary>
        /// <returns>必要な能力値</returns>
        public int getNeedAbility() {
			return NEED_ABILITY;
		}

		/// <summary>
		/// 武器の種別を取得します
		/// </summary>
		/// <returns>武器の種別</returns>
		public WeponType getWeponType() {
			return type;
		}

		/// <summary>
		/// 武器が装備可能かを判定します
		/// </summary>
		/// <returns><c>true</c>, 装備可能 , <c>false</c> 装備不可能 </returns>
		/// <param name="user">装備したいキャラクター</param>
		public bool canEquip(IPlayable user) {
            return (NEED_ABILITY <= user.getRawAbility(weponAbility));
		}

		/// <summary>
		/// 装備条件の説明を取得します
		/// </summary>
		/// <returns>装備条件のい説明の文章</returns>
		public string getEquipDescription() {
			return flavorText;
		}

		/// <summary>
		/// 武器を使用するのに使うBattleAbilityを取得します
		/// </summary>
		/// <returns>使用するBattleAbility</returns>
		public BattleAbility getWeponAbility() {
			return weponAbility;
		}

		/// <summary>
		/// ディレイ値を取得します
		/// </summary>
		/// <returns>The delay.</returns>
		public float getDelay() {
			return DELAY;
		}

		#region IItem implementation

        public int getId(){
            return ID;
        }

		public int getItemValue() {
			return ITEM_VALUE;
		}

		public int getMass(){
			return MASS;
		}

		public string getName() {
			return name;
		}

        public string getDescription() {
            return description;
        }

		public void use(IPlayable user) {
			user.equipWepon(this);
		}

        public bool getCanStore() {
            return canStore;
        }
        #endregion
    }
}
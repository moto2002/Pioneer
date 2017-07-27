﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Character;
using MasterData;

using HealAttribute = Skill.ActiveSkillParameters.HealSkillAttribute;

namespace Item {
    public class HealItem : IItem {
        
        private readonly int
			/// <summary> アイテムID </summary>
			ID,
			/// <summary> アイテムの回復量 </summary>
			HEAL,
			/// <summary> アイテムの基本価格 </summary>
			ITEM_VALUE,
			/// <summary> アイテムの重量 </summary>
			MASS;


        private readonly string
    		/// <summary> アイテム名 </summary>
			NAME,
			/// <summary> アイテムの説明文 </summary>
			DESCRITION,
			/// <summary> アイテムのフレーバーテキスト </summary>
			FLAVOR_TEXT;


		/// <summary> アイテムの回復属性 </summary>
		private readonly HealAttribute ATTRIBUTE;

        public HealItem(HealItemBuilder builder){
            ID = builder.getId();
            NAME = builder.getName();
            HEAL = builder.getHeal();
            ITEM_VALUE = builder.getItemValue();
            MASS = builder.getMass();
            DESCRITION = builder.getDescription();
            FLAVOR_TEXT = builder.getFlavorText();
            ATTRIBUTE = builder.getAttribute();
        }

        /// <summary>
        /// アイテムの回復量を取得します
        /// </summary>
        /// <returns>回復量</returns>
        public int getHeal() {
            return HEAL;
        }

        /// <summary>
        /// 回復属性を取得します
        /// </summary>
        /// <returns>回復属性</returns>
        public HealAttribute getAttribute(){
            return ATTRIBUTE;
        }

		#region IItem implementation

		public bool getCanStore() {
            return true;
        }

        public string getDescription() {
            return DESCRITION;
        }

        public int getId() {
            return ID;
        }

        public int getItemValue() {
            return ITEM_VALUE;
        }

        public int getMass() {
            return MASS;
        }

        public string getName() {
            return NAME;
        }

        public void use(IPlayable user) {
            user.healed(HEAL, ATTRIBUTE);
        }

        public string getFlavorText() {
            return FLAVOR_TEXT;
        }

		public bool getCanStack() {
            return true;
		}

        #endregion

        public override bool Equals(object obj) {
            //HealItemであり、IDが同値なら等価と判断
            if(!(obj is HealItem)){
                return false;
            }

            HealItem item = (HealItem)obj;

            return item.getId() == this.getId();
        }


    }
}
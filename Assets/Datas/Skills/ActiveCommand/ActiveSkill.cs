﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using character;
using battleSystem;

namespace skill{
	public interface ActiveSkill : Skill{
		//スキルの属性を決定します
		SkillType getSkillType();

		//スキルの射程を取得します
		int getRange(Battleable user,int basicRange);

		//スキルの成功率を算出します
		int getSuccessRate(Battleable user);

		//スキルのディレイを表します
		float getDelay(Battleable user,float basicDelay);

		//友好的なスキルであるかを返します
		bool isFriendly();

		//スキルの対象人数を表します

	}

	public class SkillSuporter{
		private SkillSuporter(){}
		public static int getUseAbility(Battleable user){
			switch(user.getAttackType()){
			case AttackType.MELEE:
				return user.getMft ();
			case AttackType.FAR:
				return user.getFft ();
			case AttackType.MAGIC:
				return user.getMgp ();
			}
			throw new System.Exception ("不正な引数");
		}
	}

	public enum SkillType{
		//物理
		PHYGICAL,
		//魔法（火）
		FIRE,
		//魔法（水）
		WATER,
		//魔法（風）
		WIND,
		//魔法（土）
		EARTH,
		//魔法（神聖）
		HOLY,
		//魔法（無）
		NEUTRAL,
		//貫通
		PENETRATION
	}

	public enum Extent{
		//単体
		SINGLE,
		//一帯
		AREA,
		//全範囲
		ALL
	}
}

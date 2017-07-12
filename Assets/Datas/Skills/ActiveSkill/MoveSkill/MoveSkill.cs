﻿using System;

using Character;
using BattleSystem;

using BattleAbility = Parameter.CharacterParameters.BattleAbility;
using ActiveSkillType = Skill.ActiveSkillParameters.ActiveSkillType;

namespace Skill {
	public class MoveSkill : IActiveSkill{
		private readonly int
			/// <summary> スキルのID </summary>
			ID,
			/// <summary> 最大移動量 </summary>
			MOVE,
			/// <summary> MPコスト </summary>
			COST;

		private readonly string
			/// <summary> スキル名 </summary>
			NAME,
			/// <summary> スキルの説明 </summary>
			DESCRIPTION;

		/// <summary> ディレイ秒数 </summary>
		private readonly float DELAY;

		/// <summary> 使用する能力値 </summary>
		private readonly BattleAbility USE_ABILITY;

		public MoveSkill (string[] datas) {
			ID = int.Parse (datas[0]);
			NAME = datas [1];
			MOVE = int.Parse (datas [2]);
			DELAY = float.Parse (datas [3]);
			COST = int.Parse (datas [4]);
			DESCRIPTION = datas [5];
			USE_ABILITY = (BattleAbility)Enum.Parse (typeof(BattleAbility),datas[6]);
		}

		/// <summary>
		/// 対象を移動させます
		/// </summary>
		/// <param name="actioner"> 移動する対象 </param>
		/// <param name="move"> 移動距離 </param>
		private void move(IBattleable actioner,int move){
			//値が適切か判断
			FieldPosition nowPos = BattleManager.getInstance ().searchCharacter (actioner);
			int moveAmountMax = Enum.GetNames (typeof(FieldPosition)).Length - (int)nowPos;
			int moveAmountMin = -1 * (int)nowPos;
			if (moveAmountMax <= MOVE||moveAmountMin >= MOVE)
				throw new ArgumentException ("invlit moveNess");

			BattleManager.getInstance ().moveCommand (actioner,move);
		}

		/// <summary>
		/// 移動量の最大値を取得します
		/// </summary>
		/// <returns> スキルの移動量 </returns>
		public int getMove(IBattleable actioner){
			int moveBonus = 0;
			switch(USE_ABILITY){
				case BattleAbility.MFT:
					moveBonus += (actioner.getMft () / 5) + 1;
					break;
				case BattleAbility.AGI:
					moveBonus += (actioner.getAgi () / 3) + 1;
					break;
				case BattleAbility.FFT:
					moveBonus += (actioner.getFft () / 5) + 1;
					break;
				case BattleAbility.PHY:
					moveBonus += (actioner.getPhy () / 5) + 1;
					break;
				case BattleAbility.MGP:
					moveBonus += (actioner.getMgp () / 5) + 1;
					break;
			}

			return MOVE + moveBonus;
		}

		public int getRawMove(){
			return MOVE;
		}

		#region IActiveSkill implementation

		public void action (IBattleable actioner, BattleTask task) {
			if (actioner.getMp () < this.COST)
				return;
			move (actioner,task.getMove());

			actioner.minusMp (this.COST);
		}

		public int getCost () {
			return COST;
		}

		public float getDelay (IBattleable actioner) {
			return DELAY;
		}

		public ActiveSkillType getActiveSkillType () {
			return ActiveSkillType.MOVE;
		}

		public bool isFriendly () {
			return true;
		}
		#endregion

		#region ISkill implementation

		public string getName () {
			return this.NAME;
		}

		public string getDescription () {
			return this.DESCRIPTION;
		}

		public int getId () {
			return this.ID;
		}

		#endregion
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using AI;
using Character;

namespace MasterData{
	public class ActiveSkillSetMasterManager : MasterDataManagerBase{
		/// <summary> 登録済みのActiveSkillSetBuilderのリスト </summary>
		private static List<ActiveSkillSetBuilder> dataTable = new List<ActiveSkillSetBuilder>();

		private void Awake(){
			var activeSkillSetCSV = Resources.Load ("MasterDatas/ActiveSkillSetMasterData") as TextAsset;
			constractedBehaviour (activeSkillSetCSV);
		}

		/// <summary>
        /// IDからActiveSkillSetを取得します
        /// </summary>
        /// <returns>指定されたActiveSkillSet</returns>
        /// <param name="id">取得したいActiveSkillSetのリスト</param>
        /// <param name="user">使用者</param>
		public static ActiveSkillSet getActiveSkillSetFromId(int id,IBattleable user){
			foreach(ActiveSkillSetBuilder builder in dataTable){
				if (builder.getId () == id)
					return builder.build(user);
			}
			throw new ArgumentException ("invlit id");
		}

		#region implemented abstract members of MasterDataManagerBase

		protected override void addInstance (string[] datas) {
			dataTable.Add (new ActiveSkillSetBuilder(datas));
		}

        #endregion
    }
}

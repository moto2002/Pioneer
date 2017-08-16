﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Skill;

namespace MasterData {
	public class DebufSkillMasterManager : MasterDataManagerBase{
        /// <summary>
        /// 登録済みのDebufSkillのリスト
        /// </summary>
		private static List<DebufSkill> dataTable = new List<DebufSkill>();
        private static Dictionary<int, ActiveSkillProgress> progressTable = new Dictionary<int, ActiveSkillProgress>();

		void Awake(){
			var csv = Resources.Load ("MasterDatas/DebufSkillMasterData") as TextAsset;
			constractedBehaviour (csv);
		}

        /// <summary>
        /// IDからDebufSkillを取得します
        /// </summary>
        /// <returns>指定されたDebufSkill</returns>
        /// <param name="id">取得したいDebufSkillのID</param>
		public static DebufSkill getDebufSkillFromId(int id){
			foreach(DebufSkill skill in dataTable){
				if (skill.getId () == id)
					return skill;
			}
			throw new ArgumentException ("invalid DebufSkillId");
		}

        public static ActiveSkillProgress getProgressFromId(int id){
            return progressTable[id];
        }

		#region implemented abstract members of MasterDataManagerBase
		protected override void addInstance (string[] datas) {
            var builder = new DebufSkill(datas);
            dataTable.Add (builder);
            int id = int.Parse(datas[0]);
            if (ES2.Exists(getLoadPass(id, "DebufSkillProgress.txt"))) {
                var progress = loadSaveData<ActiveSkillProgress>(int.Parse(datas[0]), "DebufProgress.txt");
                progressTable.Add(id, progress);
            }else{
                progressTable.Add(id,new ActiveSkillProgress());
            }
		}
        #endregion
    }
}


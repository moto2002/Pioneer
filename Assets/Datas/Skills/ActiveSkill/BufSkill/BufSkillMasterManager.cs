﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Skill;

namespace MasterData {
	public class BufSkillMasterManager : MasterDataManagerBase{
        /// <summary> 登録済みのBufSkillのリストです </summary>
		private static List<BufSkill> dataTable = new List<BufSkill>();
        private static Dictionary<int, ActiveSkillProgress> progressTable = new Dictionary<int, ActiveSkillProgress>();

		void Awake(){
			var csv = (TextAsset)Resources.Load ("MasterDatas/BufSkillMasterData");
			constractedBehaviour (csv);
		}

        /// <summary>
        /// IDからBufSkillを取得します
        /// </summary>
        /// <returns>指定されたBufSkill</returns>
        /// <param name="id">取得したいBufSkillのID</param>
		public static BufSkill getBufSkillFromId(int id){
			foreach(BufSkill skill in dataTable){
				if(skill.getId() == id){
					return skill;
				}
			}
			throw new ArgumentException ("invalid BufSkillId");
		}

        public static ActiveSkillProgress getProgressFromId(int id){
            return progressTable[id];
        }

		#region implemented abstract members of MasterDataManagerBase
		protected override void addInstance (string[] datas) {
            var builder = new BufSkill(datas);
            dataTable.Add (builder);
            int id = int.Parse(datas[0]);
            if (ES2.Exists(getLoadPass(id, "BufSkillProgress.txt"))) {
                var progress = loadSaveData<ActiveSkillProgress>(int.Parse(datas[0]), "BufSkillProgress.txt");
                progressTable.Add(id, progress);
            }else{
                progressTable.Add(id,new ActiveSkillProgress());
            }
		}
        #endregion
    }
}


﻿using System;
using System.Collections;
using System.Collections.Generic;

using character;
using skill;
using battleSystem;

namespace AI {
	public interface IEnemyAI {

		//与えられたデータを元に、使うスキルを判断します
		ActiveSkill decideSkill();

		//与えられたデータを元に、攻撃する敵を判断します
		List<IBattleable> decideTarget (List<IBattleable> targets,ActiveSkill useSkill);

		//与えられたデータを元に、移動量を決定します
		int decideMove();
	}


}

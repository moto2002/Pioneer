﻿using System.Collections;

    /// <summary> 購入ウィンドウのプレファブ </summary>
    private GameObject tradeViewPrefab;
		tradeViewPrefab = (GameObject)Resources.Load("Prefabs/TradeView");

	// Update is called once per frame
	void Update() {
		bool isHavingMassage = (massageList.Count > 0);
		bool isIndexInCount = (massageList.Count > massageIndex);
				printCoroutine = StartCoroutine(showText(massageList[massageIndex]));
				massageIndex++;
				//メッセージプリント中ならキャンセル
				cancelPrint();
				TalkManager.getInstance().finishTalk();
			printCoroutine = StartCoroutine(showText(massageList[massageIndex]));
			massageIndex++;

		if (tradeViewPrefab == null) {
			tradeViewPrefab = (GameObject)Resources.Load("Prefabs/TradeView");
        buyWindow.setState(tradegoods, player, trader,this);
        //かり
        tradeViewNode.transform.SetParent(CanvasGetter.getCanvas().transform);
        tradeViewNode.transform.localPosition = new Vector3(posX, 0, 0);
		isTrading = true;
    }
        if (massageIndex - 1 >= 0 && massageIndex - 1 == startTradeIndex) {
			startTrade();
		}
        if (!isTrading) {
            judgeTrade();
		massagePrinting = false;
		massageTextObject.text = printingMassage;
        massageList = massages;
        startTradeIndex = tradeIndex;
    }
        isTrading = false;
    }
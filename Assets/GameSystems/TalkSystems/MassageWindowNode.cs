﻿using System.Collections;
                    if (massagePrinting) {
                        //メッセージをプリントしている場合は全文字表示してコルーチン停止
                        Debug.Log("into massagePringing true");
                        cancelPrint();
                    } else {
                        //違うなら新しく文字を表示
                        Debug.Log("into massagePringing false");
                        printCoroutine = StartCoroutine("showText");
                    }
                    //インデックスが最後まで来たら削除
                    TalkManager.getInstance().finishTalk();
                    Destroy(view);
                }
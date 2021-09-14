using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public int money;
    public Text moneyText;

    void Update(){
        moneyText.text = ("" + money);
    }
}

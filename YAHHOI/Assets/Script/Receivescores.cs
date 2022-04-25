using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Receivescores: MonoBehaviour
{
    int Completedconstellations;
    public Text textComponent;
    //public Text textDamege;
    //public Text textItem;
    // Start is called before the first frame update
    void Start()
    {
        Completedconstellations = 0424;
        //damage = Damage.getdamagecount();
        //item = Item.getItemcount();


        textComponent.text = string.Format("Score ........ {0}", Completedconstellations);
        //textDamege.text = string.Format("Damage..... {0}", damage);
        //textItem.text = string.Format("Item.......... {0}", item);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    SortedDictionary<MaterialItem, int> inventory;


    private void Start()
    {
        inventory = new();
        //inventory.Add(new Wolf_Fang(),1);
        //inventory.Add(new Wolf_Claw(), 5);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            //Debug.Log();
        }
    }
}

//public abstract class Item
//{
//    public abstract string itemName { get; }
//}

//public class Wolf_Fang : Item
//{
//    public override string itemName { get => "Wolf Fang"; }

//}

//public class Wolf_Claw : Item
//{
//    public override string itemName { get => "Wolf Claw"; }

//}
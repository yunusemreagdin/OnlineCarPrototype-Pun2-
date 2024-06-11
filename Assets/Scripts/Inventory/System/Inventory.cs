using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
    {
        #region Variables

        public List<Item> inventoryList = new List<Item>();
        public int _money;
       
        private GameManager _gameManagerInstance;
        #endregion

        private void Update()
        {
            UIInventoryManager.Instance.moneyUI.text = _money.ToString();
        }

        public int Money
        {
            get
            {
                return _money;
            }
            set
            {
                _money = value;
                UIInventoryManager.Instance.moneyUI.text = _money.ToString();
            }
        }
        
        public void AddItem(Item item)
        {
            inventoryList.Add(item);
        }
        
        public void RemoveItem(Item item)
        {
            inventoryList.Remove(item);
        }
    }

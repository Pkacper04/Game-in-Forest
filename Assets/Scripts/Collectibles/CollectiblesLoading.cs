using System.Collections.Generic;
using UnityEngine;
using Game.SaveLoadSystem;
using NaughtyAttributes;

namespace Game.Collections
{
    public class CollectiblesLoading : MonoBehaviour
    {
        [ReorderableList]
        public List<FoodContainer> Berries = new List<FoodContainer>();

        [HideInInspector]
        public List<int> pickedUpFood = new List<int>();

        private List<int> foodId = new List<int>();
        private List<Berry> food = new List<Berry>();

        private void Start()
        {
            foreach(FoodContainer container in Berries)
            {
                foodId.Add(container.id);
                food.Add(container.food);
            }

            LevelData data = SaveSystem.LoadLevel();

            if (data != null)
            {
                foreach (int id in data.foodID)
                    Berries[foodId.IndexOf(id)].food.Collected();
            }
        }


        public void PickUp(Berry food)
        {
            pickedUpFood.Add(Berries[this.food.IndexOf(food)].id);
        }
    }
}

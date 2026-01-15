using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx3
{
    class GreedyUtils
    {
        //Step 4: Implement the Greedy Algorithm
        //Explanation:The greedy algorithm selects items to maximize the total value
        //within the weight limit.Items are sorted by their ValRatio,
        //and the algorithm adds as many as possible without exceeding the weight limit.
        public static List<Item> GetGreedyManifesto(List<Item> items, double limit)
        {
            //Create a new list of opimised itmes
            List<Item> result = new List<Item>();
            double CurrentWeight = 0; //Tracking the current weight

            //convert item list to array
            Item[] itemsArray = items.ToArray();
            SortUtils.InsertSortGen(itemsArray); //Sort the items bast on their ratio 

            foreach (var item in itemsArray)
            {
                //check adding the items will exceed the limit. 
                if (CurrentWeight + item.Weight <= limit)
                {
                    result.Add(item); //if not keep until add item to the result.
                    CurrentWeight += item.Weight; //Add item weight to the current weight.
                }
            }
            //List of items 
            return result;
        }
    }
}

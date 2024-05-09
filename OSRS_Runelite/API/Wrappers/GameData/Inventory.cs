using OSRS_Runelite.API.Helper;
using OSRS_Runelite.API.Wrappers.Ids;
using OSRS_Runelite.API.Wrappers.Interactive;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace OSRS_Runelite.API.Wrappers.GameData
{
    public class InventoryContainer
    {
        [JsonIgnore]
        private List<Item>? _ITEMS;
        
        public List<Item>? Items
        {
            get
            {
                LoadData();
                return _ITEMS;
            }
        }

        private async void LoadData()
        {

            _ITEMS =
                Web.RequestData.ConvertJsonClientData<Dictionary<string, Item>>("/Inventory/OldDataStructure").Values.ToList();
        }

        public List<Item?> FindItemById(int id)
        {
            var matchingItems = Items.Where(item => item.Id == id).ToList();
            return matchingItems;
        }

        public List<Item?> FindItemsById(params int[] ids)
        {
            // Use Contains to check if the item.Id is in the ids array
            var matchingItems = Items.Where(item => ids.Contains(item.Id)).ToList();
            return matchingItems;
        }

        public bool ContainsItem(double itemId)
        {
            return Items.Any(item => item.Id == itemId);
        }

        public bool IsFull()
        {
             return !Items.Any(item => item?.Id == 6512); // # 6512 == empty
        }
    }

    public class Item
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public Bounds Bounds { get; set; }
   
        public bool Drop()
        {
            int rndX = Randoms.RandomNumber(Bounds.LocalPoint.X, (int)(Bounds.LocalPoint.X + Bounds.Width));
            int rndY = Randoms.RandomNumber(Bounds.LocalPoint.Y, (int)(Bounds.LocalPoint.Y + Bounds.Height));

            return Input.Mouse.LeftClickShift(rndX, rndY);
        }

        public bool RightClick()
        {
            int rndX = Randoms.RandomNumber(Bounds.LocalPoint.X, (int)(Bounds.LocalPoint.X + Bounds.Width));
            int rndY = Randoms.RandomNumber(Bounds.LocalPoint.Y, (int)(Bounds.LocalPoint.Y + Bounds.Height));

            return Input.Mouse.RightClick(rndX, rndY);
        }
    }

    public class Bounds
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        [JsonIgnore]
        public RSPoint LocalPoint
        {
            get
            {
                return new RSPoint((int)X, (int)Y);
            }
        }

    }
}

using Storage;
using System.Collections.Generic;

namespace Requests
{
    public class RequestsHandler
    {
        private ItemStorage storage;

        public RequestsHandler(ItemStorage storage)
        {
            this.storage = storage;
        }

        public bool CheckoutItems(List<Tovar> items)
        {
            foreach (Tovar item in items)
            {
                Tovar storageItem = storage.GetItem(item.Name);
                if (storageItem == null || storageItem.Quantity < item.Quantity)
                    return false;
            }

            foreach (Tovar item in items)
            {
                Tovar storageItem = storage.GetItem(item.Name);
                storageItem.Quantity -= item.Quantity;
            }

            return true;
        }
    }

}

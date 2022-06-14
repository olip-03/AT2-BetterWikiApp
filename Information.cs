using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT2_BetterWikiApp
{
    // 6.1 Create a separate class file to hold the four data items of the Data Structure
    // (use the Data Structure Matrix as a guide). Use auto-implemented properties for the
    // fields which must be of type “string”. Save the class as “Information.cs”.
    public class Information: IComparable<Information>
    {
        private string itemName;
        private string itemType;
        private string itemSubType;
        private string itemDescription;

        public Information()
        {

        }

        public Information(string name, string type, string subtype, string description)
        {
            itemName = name;
            itemType = type;
            itemSubType = subtype;
            itemDescription = description;
        }

        #region Getters&Setters
        public string GetItemName()
        {
            return itemName;
        }
        public void SetItemName(string name)
        {
            itemName =name; 
        }
        public string GetItemType()
        {
            return itemType;
        }
        public void SetItemType(string type)
        {
            itemType = type;
        }
        public string GetItemSubType()
        {
            return itemSubType;
        }
        public void SetItemSubType(string subType)
        {
            itemSubType = subType;
        }
        public string GetItemDescription()
        {
            return itemDescription;
        }
        public void SetItemDescription(string description)
        {
            itemDescription = description;
        }
        public void SetAll(string name, string type, string subtype, string description)
        {
            itemName = name;
            itemType = type;
            itemSubType = subtype;
            itemDescription = description;
        }
        #endregion
        public int CompareTo(Information other, string comparison)
        { // Better compare function that can return different stuff
            switch (comparison)
            {
                case "names":
                    return this.itemName.ToLower().CompareTo(other.itemName.ToLower());
                case "description":
                    return this.itemDescription.ToLower().CompareTo(other.itemDescription.ToLower());
                case "type":
                    return this.itemType.ToLower().CompareTo(other.itemType.ToLower());
                case "subtype":
                    return this.itemSubType.ToLower().CompareTo(other.itemSubType.ToLower());
                default:
                    return this.itemName.ToLower().CompareTo(other.itemName.ToLower());
            }
        }
        public int CompareTo(Information other)
        { // Generic compare function for a sort
            return this.itemName.ToLower().CompareTo(other.itemName.ToLower());
        }
        public bool CheckIdentical(Information other)
        { // Just checks the names of each type to see if items are identical
            int validate = 0;
            if (other.itemName.Equals(itemName))
            {
                validate++;
            }
            if (other.itemType.Equals(itemType))
            {
                validate++;
            }
            if (other.itemSubType.Equals(itemSubType))
            {
                validate++;
            }
            if (other.itemDescription.Equals(itemDescription))
            {
                validate++;
            }

            if (validate >= 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}

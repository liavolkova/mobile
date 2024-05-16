﻿using System;
namespace ShoppingList.Models
{
    public class UserData
    {
        public class UserDataCollection
        {
            public UserData[] UserDataItems { get; set; }
        }

        public string dataID { get; set; }
        public string dataValue { get; set; }
        public string userKey { get; set; }

        public UserData (string dataID, string dataValue, string userKey)
        {
            this.dataID = dataID;
            this.dataValue = dataValue;
            this.userKey = userKey;
        }

        
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WalkSploration.Models
{
    public class DistanceMatrixResponse
    {
        public string Status { get; set; }
        public string[] Origin_Addresses { get; set; }
        public string[] Destination_Addresses { get; set; }
        public Row[] Rows { get; set; }
    }

    public class Row
    {
        public Element[] Elements { get; set; }
    }

    public class Element
    {
        public string Status { get; set; }
        public Item Duration { get; set; }
        public Item Distance { get; set; }
    }

    public class Item
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
}
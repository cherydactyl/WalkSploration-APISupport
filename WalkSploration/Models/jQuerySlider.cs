using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WalkSploration.Models
{
    public class jQuerySlider
    {
        private readonly HtmlHelper readOnlyHtmlHelper;

        private string id;
        private RouteValueDictionary htmlAttributes;
        private int value;
        private int[] values;
        private int minimum;
        private int maximum;

        public jQuerySlider (HtmlHelper htmlHelper)
        {
            readOnlyHtmlHelper = htmlHelper;
        }

        public jQuerySlider Id(string elementId)
        {
            id = elementId;
            return this;
        }

        public jQuerySlider HtmlAttributes(object attributes)
        {
            htmlAttributes = new RouteValueDictionary(attributes);

            return this;
        }

        public jQuerySlider Value (int sliderValue)
        {
            value = sliderValue;
            return this;
        }

        // Range
        public jQuerySlider Values (int slider1Value, int slider2Value)
        {
            values = new int[2];            // Sets value of time selected in the slider int array
                                                             
            values[0] = slider1Value;       // Sets value of the minimum time in the slider int array
            values[1] = slider2Value;       // Sets value of the minimum time in the slider int array

            return this;
        }

        public jQuerySlider Minimum(int value)
        {
            minimum = value;
            return this;
        }

        public jQuerySlider Maximum(int value)
        {
            maximum = value;
            return this;
        }

        public void Render()
        {


        }
         
    }
    
}
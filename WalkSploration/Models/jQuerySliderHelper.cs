using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WalkSploration.Models;

namespace WalkSploration
{
    public static class jQuerySliderHelper
    {
        public static jQuerySlider Slider(this HtmlHelper helper)
        {
            return new jQuerySlider(helper);
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace WalkSploration.Models
{
    public class InputInfo
    {
        [Required]
        public int TimeIn { get; set; }

        public Location LocationIn { get; set; }
    }
}
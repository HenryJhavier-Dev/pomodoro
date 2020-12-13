using System;
using System.Collections.Generic;
using System.Text;

namespace Pomodoro.Models
{
    public enum MenuItemType
    {
        Pomodoro,
        History,
        Configuration,          
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}

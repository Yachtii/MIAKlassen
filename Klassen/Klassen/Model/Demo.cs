using System;
using System.Collections.Generic;
using System.Text;

namespace Klassen.Model
{
    public class Demo
    {
        public string Title { get; set; } = string.Empty;
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public Demo (string title, int id, string description)
        {
            Title = title;
            Id = id;
            Description = description; ;
        }

        public string GetTitle()
        {
            return Title;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public delegate void ClickHandler(object sender, string buttonName);
    public class Button
    {
        public string Name { get; set; }

        public Button(string name) {Name = name; }

        public event ClickHandler Click;

        public void PerformClick()
        {
            if (Click != null)
                Click(this, Name);
        }
    }
}

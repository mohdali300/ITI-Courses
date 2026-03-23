using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class StringCollection
    {
        string[] Items { get; set; }
        string[] Keys { get; set; }

        public StringCollection(int size)
        {
            Items = new string[size];
            Keys = new string[size];
        }

        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < Items.Length)
                    return Items[index];
                else
                    return "Not found!";
            }
            set { Items[index] = value; }
        }

        public string this[string key]
        {
            get
            {
                for (int i = 0; i < Keys.Length; i++)
                {
                    if (Keys[i] == key)
                        return Keys[i];
                }
                return "Not found!";
            }
            set
            {
                for (int i = 0; i < Keys.Length; i++)
                {
                    if (Keys[i] == key)
                    {
                        Keys[i] = value;
                        return;
                    }
                }
                for (int i = 0; i < Keys.Length; i++)
                {
                    if (Keys[i] == null)
                    {
                        Keys[i] = value;
                        return;
                    }
                }
            }
        }

        public void DisplayItems()
        {
            for (int i = 0; i < Items.Length; i++)
            {
                Console.WriteLine($"Item {i + 1}: {Items[i]}");
            }
        }

        public void DisplayKeys()
        {
            for (int i = 0; i < Keys.Length; i++)
            {
                Console.WriteLine($"Key {i + 1}: {Keys[i]}");
            }
        }
    }
}

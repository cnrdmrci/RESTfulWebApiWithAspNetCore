using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiExample.Model
{
    public class NotBilgisi
    {
        public NotBilgisi() { }
        public NotBilgisi(string ders, string not)
        {
            Ders = ders;
            Not = not;
        }
        public string Ders { get; set; }
        public string Not { get; set; }
    }
}

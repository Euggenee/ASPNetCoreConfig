using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Life
{
    public class Life : IScoupe, ISingl, ITrans
    {

        private readonly string GuidStr;

        public Life()
        {
            GuidStr = Guid.NewGuid().ToString();
        }
        public string GetStr()
        {
            return GuidStr;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectURL.Domain.Models
{
    public class Url: EntityBase
    {
        public string description { get; set; }

        public string shortURL { get; set; }

        public string longURL { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gap.WepApi.Models
{
    public class CustomerModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace WebApp3.Models
{
    public class Community
    {
        public int id { get; set; }

        public string Name { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string Pic { get; set; }
     //   public IFormFile ProfileImage { get; set; }
        public Community()
        {

        }
        
    }
}

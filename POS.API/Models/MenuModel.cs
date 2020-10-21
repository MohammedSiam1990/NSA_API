using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Models
{
    public class MenuModel
    {
        public int MenuId { get; set; }
        public string MenuKeyName { get; set; }
        public string MenuKeyNameAr { get; set; }
        public int? MenuParentId { get; set; }
        public string MenuUrl { get; set; }
        public string MenuClassName { get; set; }
        public string MenuImagePath { get; set; }
        public int? StatusId { get; set; }
        public int? MenuOrder { get; set; }
        public bool? Header { get; set; }
        public bool? Main { get; set; }
        public int? MenuType { get; set; }
        public virtual ICollection<MenuModel> InverseMenuParent { get; set; }
    }
}

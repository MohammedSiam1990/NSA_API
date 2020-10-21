using System;
using System.Collections.Generic;

namespace POS.Entities
{
    public partial class Menu
    {
        public Menu()
        {
            InverseMenuParent = new HashSet<Menu>();
        }

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
        public virtual Menu MenuParent { get; set; }
        public virtual ICollection<Menu> InverseMenuParent { get; set; }
    }
}

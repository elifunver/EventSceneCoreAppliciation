using EntityLayer;
using System.Collections.Generic;

namespace EventSceneCoreAppliciation.Models
{
    public class MenuParentListModel
    {
        public Menu menuModel { get; set; }
        public IEnumerable<Menu> menuListModel { get; set; }
    }
}
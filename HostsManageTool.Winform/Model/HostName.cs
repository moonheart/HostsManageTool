using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HostsManageTool.Winform.Model
{
    public class HostName
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

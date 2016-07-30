using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HostsManageTool.Winform.Model
{
    public class HostsSource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int IsEnabled { get; set; }

        public int Order { get; set; }
    }
}

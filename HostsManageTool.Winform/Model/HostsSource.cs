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

        public string Display
        {
            get
            {
                var r = (IsEnabled == 1 ? "“—∆Ù”√" : "Œ¥∆Ù”√") + "|";
                if (Name.IsNullOrWhiteSpace())
                {
                    return r + Url;
                }
                return r + Name + "|" + Url;
            }
        }
    }
}

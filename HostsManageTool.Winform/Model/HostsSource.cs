namespace HostsManageTool.Winform.Model
{
    /// <summary>
    /// hosts源
    /// </summary>
    public class HostsSource
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 启用状态（0：:禁用，1：启用）
        /// </summary>
        public int IsEnabled { get; set; }

        /// <summary>
        /// 列表显示
        /// </summary>
        public string Display
        {
            get
            {
                var r = (IsEnabled == 1 ? "已启用" : "未启用") + "|";
                if (Name.IsNullOrWhiteSpace())
                {
                    return r + Url;
                }
                return r + Name + "|" + Url;
            }
        }
    }
}

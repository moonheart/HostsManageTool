namespace HostsManageTool.Winform.Model
{
    /// <summary>
    /// hostsԴ
    /// </summary>
    public class HostsSource
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ��ַ
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// ����״̬��0��:���ã�1�����ã�
        /// </summary>
        public int IsEnabled { get; set; }

        /// <summary>
        /// �б���ʾ
        /// </summary>
        public string Display
        {
            get
            {
                var r = (IsEnabled == 1 ? "������" : "δ����") + "|";
                if (Name.IsNullOrWhiteSpace())
                {
                    return r + Url;
                }
                return r + Name + "|" + Url;
            }
        }
    }
}

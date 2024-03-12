namespace SEP_Management.Enums
{
    public class ActiveEnum
    {
        public string DisplayActiveName { get; set; }
        public int ActiveKey { get; set; }
        public static List<ActiveEnum> GetListActive()
        {
            List<ActiveEnum> list = new List<ActiveEnum>();
            list.Add(new ActiveEnum { DisplayActiveName = "All", ActiveKey = -1 });
            list.Add(new ActiveEnum { DisplayActiveName = "InActive", ActiveKey = 0 });
            list.Add(new ActiveEnum { DisplayActiveName = "Active", ActiveKey = 1 });
            return list.OrderBy(x => x.ActiveKey).ToList();
        }
    }
}

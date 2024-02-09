﻿namespace Learning_Razor_EF.Helpers
{
    public class PagingModel
    {

        public int currentPage {  get; set; }   
        public int countPages { get; set; }
        public Func<int?, string> generateUrl { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DataGrid.Definitions
{
    public class PagingConfig
    {
        public PagingConfig()
        {
            Enabled = false;
            PageSize = 25;
            AllowedPageSizes = new int[] { 25, 50, 100 };
            CustomPager = false;
        }

        public bool Enabled { get; set; }
        public int PageSize { get; set; }
        public int[] AllowedPageSizes { get; set; }
        public bool CustomPager { get; set; }

        public int NumOfItemsToSkip(int currentPage)
        {
            if (Enabled)
            {
                return (currentPage - 1) * PageSize;
            }

            return 0;
        }

        public int NumOfItemsPerPage(int totalItemsCount)
        {
            if (Enabled) return PageSize;
            return totalItemsCount;
        }

        public int NextPageNumber(int currentPage, int totalItemsCount)
        {
            if (currentPage < MaxPageNumber(totalItemsCount))
                return currentPage + 1;
            else
                return currentPage;
        }

        public int PrevPageNumber(int currentPage)
        {
            if (currentPage > 1)
                return currentPage - 1;
            else
                return 1;
        }

        public int MaxPageNumber(int totalItemsCount)
        {
            int maxPageNumber;
            double numPages = totalItemsCount / (double)PageSize;
            if (numPages == Math.Floor(numPages))
            {
                maxPageNumber = (int)numPages;
            }
            else
            {
                maxPageNumber = (int)numPages + 1;
            }
            return maxPageNumber;
        }
    }
}

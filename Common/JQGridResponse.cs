using HospitalManagementSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace HospitalManagementSystem.JqGrid
{
    public class JQGridResponse<T>
    {
        public int total { get; set; }
        public int page { get; set; }
        public int records { get; set; }
        public List<T> rows { get; set; } = new List<T>();

        public bool _search { get; set; }

    }

    public class JQGridSort
    {
        public string sidx { get; set; }
        public string sord { get; set; }
        public int page { get; set; }
        public int rows { get; set; }
        public bool _search { get; set; }
        public string filters { get; set; }

    }

    public class Rule
    {
        public string field { get; set; }
        public string op { get; set; }
        public string data { get; set; }
    }

    public class JQGridFilter
    {
        public string groupOp { get; set; }
        public List<Rule> rules { get; set; }
        public JQGridFilter[] Groups { get; set; }
    }

    public static class JqGridResult
    {

        public static JQGridResponse<T> GridFilteration<T>(JQGridSort jQGridSort, List<T> objlistFilter)
        {
            if (jQGridSort != null)
            {

                if (jQGridSort.sidx == null)
                {
                    jQGridSort.sord = AppConstant.Asc;
                }

                jQGridSort.sidx = jQGridSort.sidx;
                var recordsCount = objlistFilter.Count();
                var pagerIndex = jQGridSort.page;
                var pagerSize = jQGridSort.rows;
                var startRow = (pagerIndex - 1) * pagerSize;
                var totalPages = (int)Math.Ceiling((float)recordsCount / (float)pagerSize);

                List<T> filterlist;

                if (jQGridSort.sidx != null)
                {
                    filterlist = objlistFilter.OrderBy(jQGridSort.sidx + " " + jQGridSort.sord).ToList().Skip(startRow).Take(pagerSize).ToList();
                }
                else
                {
                    filterlist = objlistFilter.ToList().Skip(startRow).Take(pagerSize).ToList();
                }

                var result = new JQGridResponse<T>()
                {
                    total = totalPages,
                    page = pagerIndex,
                    records = recordsCount,
                    //rows = filterlist,
                };
                return result;
            }
            else
            {
                var result = new JQGridResponse<T>()
                {
                    rows = objlistFilter,
                };
                return result;
            }
        }
    }
}

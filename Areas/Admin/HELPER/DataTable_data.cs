using appweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appweb.Areas.Admin.HELPER
{
    public class DataTable_data
    {
        public int draw { set; get; }
        public int recordsTotals { set; get; }
        public int recordsFiltered { set; get; }
        public List<sanPham>data { set; get; }
        public DataTable_data(List<sanPham> sanPhams) {
           this.data = sanPhams;
        }
        
        public List<sanPham>FillterData(int draw,int length,int start)
        {
            
            this.draw = draw;
            this.recordsTotals = data.Count;
            this.recordsFiltered = data.Count;
            data= data.Skip(start).Take(length).ToList() ;
            return data;
        }
    }
}
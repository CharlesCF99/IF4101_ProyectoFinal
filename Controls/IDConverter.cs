using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IF4101_ProyectoFinal.Controls
{
    public class IDConverter
    {
        public int convertRowIDToDbID(List<string> dataList, int rowID) {
            int index = 0;
            foreach (var item in dataList) {
                if (index == rowID) {
                    return Convert.ToInt32(item.Split('|')[0].ToString());
                }
                index++;
            }
            return 0;
        }
    }
}
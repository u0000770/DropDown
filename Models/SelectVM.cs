﻿using DropDown.Data;
using DropDown.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Formats.Asn1.AsnWriter;

namespace DropDown.Models
{
    public class SelectViewModel
    {
        public string SelectId { get; set; }
        public IEnumerable<SelectListItem> List { get; set; }

        public static List<SelectListItem> BuildList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Very Large", Value = "0" });
            items.Add(new SelectListItem { Text = "Large", Value = "1" });
            items.Add(new SelectListItem { Text = "Medium", Value = "2", Selected = true });
            items.Add(new SelectListItem { Text = "Small", Value = "3" });
            return items;
        }
    }


    public class GradeStoreVM
    {
        public string GradeId { get; set; }
        public IEnumerable<SelectListItem> List { get; set; }
        public List<Shop> GradeStores { get; set; }

        public static List<SelectListItem> BuildList(List<Grade> lst)
        {
      
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var i in lst)
            {
                items.Add(new SelectListItem { Text = i.Description, Value = i.GradeId.ToString() });
            }

            return items;
        }

    }
}
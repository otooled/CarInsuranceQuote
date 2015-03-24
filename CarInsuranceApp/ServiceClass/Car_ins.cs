using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarInsuranceApp.ServiceClass
{
    public class TodoItem
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public bool Complete { get; set; }
    }
    public class Counties
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Premium { get; set; }
    }

    public class CoverType
    {
        public string Id { get; set; }
        public string CoverTypeName { get; set; }
        public int CoverTypeValue { get; set; }
    }
    public class CarMake
    {
        public string Id { get; set; }
        public string Make { get; set; }
    }
    //class Car_ins
    //{

    //}
}

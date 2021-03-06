﻿using System;
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
    public class CarModel
    {
        public string Id { get; set; }
        public string Model { get; set; }
    }

    public class EngineSize
    {
        public string Id { get; set; }
        public string Engine_Size { get; set; }
    }

    public class ModelFord
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class ModelMerc
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    
    public class ModelToyota
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class ManufactureYear
    {
        public string Id { get; set; }
        public string Year { get; set; }
    }

    public class NoOfClaims
    {
        public string Id { get; set; }
        public int ClaimsNum { get; set; }
    }

    public class PenPoints
    {
        public string Id { get; set; }
        public int NumOfPoints { get; set; }
    }
    public class LicenceType
    {
        public string Id { get; set; }
        public string License { get; set; }
    }
    public class ExistingVehicles
    {
        public string Id { get; set; }
        public string Reg { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double Eng_size { get; set; }
        public int Year { get; set; }
    }

    public class Quote
    {
        public string Id { get; set; }
        public string q_ref { get; set; }
        public double q_price { get; set; }
        public string f_name { get; set; }
        public string sname { get; set; }
    }
}

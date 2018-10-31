namespace STPGroup.Services.ViewModels.ApiModels
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class CompanyModel
    {
        //public CompanyModel()
        //{
        //    this.Employees = new List<EmployeeModel>();
        //}

        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "SalaryMin")]
        public decimal SalaryMin { get; set; }

        [JsonProperty(PropertyName = "SalaryMax")]
        public decimal SalaryMax { get; set; }

        [JsonProperty(PropertyName = "CreatedOn")]
        public DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "ModifiedOn")]
        public DateTime ModifiedOn { get; set; }

        //[JsonArray("Employees")]
        public IList<EmployeeModel> Employees { get; set; }
    }
}

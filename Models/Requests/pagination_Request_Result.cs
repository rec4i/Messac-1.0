using System;
using System.Collections.Generic;
using WebApi.Entities;

namespace KaynakKod.Models.pagenation_request
{
    public class pagination_Request_Result<T>
    {
        public List<T> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }

        public static implicit operator pagination_Request_Result<T>(pagination_Request_Result<UretimMaliyeti> v)
        {
            throw new NotImplementedException();
        }
    }
}
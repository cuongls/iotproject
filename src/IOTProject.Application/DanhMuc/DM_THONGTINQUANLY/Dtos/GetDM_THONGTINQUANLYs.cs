using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace IOTProject.DanhMuc.Dtos
{
    public class GetDM_THONGTINQUANLYs : IPagedResultRequest
    {      
        public  string Filter { get; set; }                

        public const int DefaultPageSize = 10;

        [Range(1, int.MaxValue)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }

        public GetDM_THONGTINQUANLYs()
        {
            MaxResultCount = DefaultPageSize;
        }

    }
}

using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace IOTProject.ThongTin.Dtos
{
    public class GetThongTin_ThietBis : IPagedResultRequest
    {      
        public  string Filter { get; set; }                

        public const int DefaultPageSize = 10;

        [Range(1, int.MaxValue)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }

        public GetThongTin_ThietBis()
        {
            MaxResultCount = DefaultPageSize;
        }

    }
}

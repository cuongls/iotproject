using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace IOTProject.DanhMuc.Dtos
{
    [AutoMapFrom(typeof(DM_DonVi)), AutoMapTo(typeof(DM_DonVi))]
    public class DM_DonViDto : EntityDto<int>
    {
         public string NAME { get; set; }
         public string CODE { get; set; }
         public string ADDRESS { get; set; }
         public string DOMAIN { get; set; }
         public string DESCRIPTION { get; set; }
         public int TenantId { get; set; }

    }
}

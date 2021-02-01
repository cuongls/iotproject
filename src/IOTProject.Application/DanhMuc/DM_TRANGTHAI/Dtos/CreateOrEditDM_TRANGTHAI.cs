using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace IOTProject.DanhMuc.Dtos
{
    [AutoMapFrom(typeof(DM_TRANGTHAI)), AutoMapTo(typeof(DM_TRANGTHAI))]
    public class CreateOrEditDM_TRANGTHAI
    {
        public long Id { get; set; }
        
         public string NAME { get; set; }
 public string CODE { get; set; }
 public string DESCRIPTION { get; set; }
 public int TenantId { get; set; }

    }
}

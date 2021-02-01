using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace IOTProject.DanhMuc.Dtos
{
    [AutoMapFrom(typeof(DM_SENSOR)), AutoMapTo(typeof(DM_SENSOR))]
    public class CreateOrEditDM_SENSOR
    {
        public long Id { get; set; }
        
         public string NAME { get; set; }
 public string CODE { get; set; }
 public string DESCRIPTION { get; set; }
 public int TenantId { get; set; }

    }
}

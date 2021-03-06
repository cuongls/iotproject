﻿using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace IOTProject.DanhMuc.Dtos
{
    [AutoMapFrom(typeof(DM_TRAM)), AutoMapTo(typeof(DM_TRAM))]
    public class CreateOrEditDM_TRAM
    {
        public long Id { get; set; }
        
         public long IDDONVI { get; set; }
         public DM_DonViDto DONVI { get; set; }
         public string NAME { get; set; }
         public string CODE { get; set; }
         public string ADDRESS { get; set; }
         public string DESCRIPTION { get; set; }
         public int TenantId { get; set; }

    }
}

using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IOTProject.IOTProjectConsts;

namespace IOTProject.DanhMuc
{
    public class DM_ThietBi : FullAuditedEntity<long>, IMustHaveTenant
    {
        public virtual long IDTRAM { get; set; }
        [ForeignKey("IDTRAM")]
        public virtual DM_TRAM TRAM { get; set; }
        [StringLength(LimitTextLength.Length100)]
        public virtual string NAME { get; set; }
        [StringLength(LimitTextLength.Length100)]
        public virtual string CODE { get; set; }
        [StringLength(LimitTextLength.Length100)]
        public virtual string IP { get; set; }
        [StringLength(LimitTextLength.Length500)]
        public virtual string PORT_INFO { get; set; }
        [StringLength(LimitTextLength.Length500)]
        public virtual string DESCRIPTION { get; set; }
        public int TenantId { get; set; }
    }
}

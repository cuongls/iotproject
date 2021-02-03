using IOTProject.ThongTin.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTProject.DanhMuc.Dtos
{
    public class GiamSatThietBi
    {
        public DM_ThietBiDto thietbi { get; set; }
        public List<ThongTin_ThietBiDto> lsThongTin { get; set; }
    }
}

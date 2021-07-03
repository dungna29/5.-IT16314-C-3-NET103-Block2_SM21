using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_1_TongQuanWindowForm
{
    class TheLoai
    {
        public int Id { get; set; }
        public string MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }
        public bool TrangThai { get; set; }
        public bool statuEdit { get; set; }

        public List<TheLoai> GetListTheLoais()
        {
            return new List<TheLoai>
            {
                new TheLoai{Id = 1,MaTheLoai = "TL1",TenTheLoai = "Small",TrangThai = true},
                new TheLoai{Id = 2,MaTheLoai = "TL2",TenTheLoai = "Large",TrangThai = true},
                new TheLoai{Id = 3,MaTheLoai = "TL3",TenTheLoai = "Full Size",TrangThai = false},
            };
        }
    }
}

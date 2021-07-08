using Jemeppe.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jemeppe.Web.Models
{

    public class RoomViewModel
    {
        public RoomType SelectedRoomType { get; set; }

        public MayBeCheck SelectedHasToilet { get; set; }


        public MayBeCheck SelectedHasShower { get; set; }

        public MayBeCheck SelectedHasSink { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double Price { get; set; }

        [MinLength(5)]
        public string Name { get; set; }

        [MinLength(5)]
        [MaxLength(1024)]
        public string Description { get; set; }

        [MinLength(5)]
        public string WebLink { get; set; }
        
        public int Id { get; set; }
    }
}

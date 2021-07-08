using Jemeppe.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jemeppe.Web.Controllers
{
    public class RoomController : Controller
    {
        Data.Access.RoomAccess _roomAccess;

        public RoomController(Jemeppe.Data.Access.RoomAccess roomAccess)
        {
            _roomAccess = roomAccess;
        }
        public IActionResult Edit(int Id)
        {
            var room = _roomAccess.GetRoomById(Id);
            var vm = new RoomViewModel();
            FillRoomViewModelWithRoom(vm, room);
            return View(vm);
        }

        public static void FillRoomViewModelWithRoom(RoomViewModel vm, Data.Model.Room room)
        {
            MayBeCheck NullableBoolToMayBe(bool? booleanValue)
            {
                if (booleanValue == null)
                    return MayBeCheck.Maybe;
                if (booleanValue == true)
                    return MayBeCheck.Yes;

                return MayBeCheck.No;
            }
            
            vm.SelectedRoomType = room.RoomType;
            vm.SelectedHasToilet = NullableBoolToMayBe(room.HasToilet);
            vm.SelectedHasShower = NullableBoolToMayBe(room.HasShower);
            vm.SelectedHasSink = NullableBoolToMayBe(room.HasSink);
            vm.Price = room.Price;
            vm.Name = room.Name;
            vm.WebLink = room.WebLink;
            vm.Description = room.Description;
            vm.Id = room.Id;
        }

        [HttpPost]
        public IActionResult Edit(RoomViewModel model)
        {
            bool? MayBeToNullableBool(MayBeCheck mayBeCheck)
            {
                if (mayBeCheck == MayBeCheck.No)
                    return false;
                if (mayBeCheck == MayBeCheck.Yes)
                    return true;

                return null;
            }

            var room = _roomAccess.GetRoomById(model.Id);
            room.Description = model.Description;
            room.HasShower = MayBeToNullableBool(model.SelectedHasShower);
            room.HasSink = MayBeToNullableBool(model.SelectedHasSink);
            room.HasToilet = MayBeToNullableBool(model.SelectedHasToilet);
            room.Name = model.Name;
            room.Price = model.Price;
            room.RoomType = model.SelectedRoomType;
            room.WebLink = model.WebLink;
            _roomAccess.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}

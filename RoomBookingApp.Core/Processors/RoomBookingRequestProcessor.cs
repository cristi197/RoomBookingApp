﻿using RoomBookingApp.Core.DataServices;
using RoomBookingApp.Core.Domain;
using RoomBookingApp.Core.Models;

namespace RoomBookingApp.Core.Processors
{
    public class RoomBookingRequestProcesor
    {
        private readonly IRoomBookingService _roomBookingService;

        public RoomBookingRequestProcesor(IRoomBookingService roomBookingService)
        {
            this._roomBookingService = roomBookingService;
        }

        public RoomBookingResult BookRoom(RoomBookingRequest bookingRequest)
        {
            if (bookingRequest is null)
            {
                throw new ArgumentNullException(nameof(bookingRequest));
            }

            _roomBookingService.Save(CreateRoomBookingObject<RoomBooking>(bookingRequest));

            return CreateRoomBookingObject<RoomBookingResult>(bookingRequest);
        }

        private static TRoomBooking CreateRoomBookingObject<TRoomBooking>(RoomBookingRequest bookingRequest) 
            where TRoomBooking: RoomBookingBase, new()
        {
            return new TRoomBooking
            {
                FullName = bookingRequest.FullName,
                Date = bookingRequest.Date,
                Email = bookingRequest.Email
            };
        }
    }
}
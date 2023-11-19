using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YBS.Data.Models;
using YBS.Service.Dtos;
using YBS.Service.Dtos.InputDtos;
using YBS.Service.Dtos.ListingDtos;
using YBS.Service.Dtos.PageRequests;
using YBS.Service.Dtos.PageResponses;

namespace YBS.Service.Services
{
    public interface IBookingService
    {
        Task CreateGuestBooking (GuestBookingInputDto pageRequest);
        Task<bool> ChangeStatusBookingNonMember(int id, string status);
        Task<DefaultPageResponse<BookingListingDto>> GetAllBookings(BookingPageRequest pageRequest, int companyId);
        Task<BookingDto> GetDetailBooking(int id);
        Task<int> CreateMemberBooking (MemberBookingInputDto pageRequest);
    }
}
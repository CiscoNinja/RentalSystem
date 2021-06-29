using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using RentalSystem.Authorization;
using RentalSystem.Bookings.Dtos;
using RentalSystem.Clients.Dtos;
using RentalSystem.Entities;
using RentalSystem.Facilities.Dtos;
using RentalSystem.Miscellaneouss.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Bookings
{
    [AbpAuthorize(PermissionNames.Pages_Bookings)]
    public class BookingAppService : AsyncCrudAppService<
        Booking,
        BookingDto,
        int,
        PagedAndSortedResultRequestDto,
        CreateUpdateBookingDto,
        BookingDto>, IBookingAppService
    {
        private readonly IRepository<Client, long> _clientRepository;
        private readonly IRepository<Booking> _bookingRepository;
        private readonly IRepository<Facility> _facilityRepository;
        private readonly IRepository<Miscellaneous> _miscellaneousRepository;
        private readonly IRepository<MiscellaneousBooking> _miscellaneousBookingRepository;
        private readonly IRepository<FacilityBooking> _facilityBookingRepository;


        public BookingAppService(IRepository<Booking, int> repository,
            IRepository<Booking> bookingRepository,
            IRepository<Client, long> clientRepository,
            IRepository<Facility> facilityRepository,
            IRepository<Miscellaneous> miscellaneousRepository,
            IRepository<MiscellaneousBooking> miscellaneousBookingRepository,
            IRepository<FacilityBooking> facilityBookingRepository
            )
            : base(repository)
        {
            _bookingRepository = bookingRepository;
            _clientRepository = clientRepository;
            _facilityRepository = facilityRepository;
            _miscellaneousRepository = miscellaneousRepository;
            _miscellaneousBookingRepository = miscellaneousBookingRepository;
            _facilityBookingRepository = facilityBookingRepository;
        }

        public override async Task<PagedResultDto<BookingDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var bookings = await _bookingRepository.GetAllIncluding(x => x.Client).ToListAsync();

            var res = ObjectMapper.Map<List<BookingDto>>(bookings);

            return new PagedResultDto<BookingDto>(input.MaxResultCount, res);
        }

        public override async Task<BookingDto> CreateAsync(CreateUpdateBookingDto input)
        {
            CheckCreatePermission();
            var booking = ObjectMapper.Map<Booking>(input);
            booking.BookedDates = String.Join(",", input.BookedDates.Cast<string>().ToArray());
            await Repository.InsertAsync(booking);

            CurrentUnitOfWork.SaveChanges();

            if (input.Miscellaneous != null)
            {
                foreach (var miscellaneous in input.Miscellaneous)
                {
                    //var selectedMi = _miscellaneousRepository.GetAll()
                    //    .Where(p => p.Name == miscellaneous.Name)
                    //    .FirstOrDefault();
                    var miscellaneousBooking = new MiscellaneousBooking(booking.Id, miscellaneous.Id, miscellaneous.Quantity)
                    {
                    };
                    //booking.MiscellaneousBookings.Add(miscellaneousBooking);
                    await _miscellaneousBookingRepository.InsertAsync(miscellaneousBooking);
                }

            }
            if (input.Facilities != null)
            {
                foreach (var facility in input.Facilities)
                {
                    var facilityBooking = new FacilityBooking(booking.Id, facility.Id, booking.BookedDates)
                    {
                    };
                    await _facilityBookingRepository.InsertAsync(facilityBooking);
                }

            }
            CurrentUnitOfWork.SaveChanges();

            return MapToEntityDto(booking);
        }

        //public override async Task<BookingDto> UpdateAsync(BookingDto input)
        //{
        //    CheckUpdatePermission();

        //    var booking = Repository.GetAllIncluding(x => x.FacilityBookings, x => x.MiscellaneousBookings).FirstOrDefault(x => x.Id == input.Id);

        //    //enrollment = ObjectMapper.Map<Enrollment>(input);

        //    MapToEntity(input, booking);

        //    await Repository.UpdateAsync(booking);

        //    if (input.Miscellaneous != null)
        //    {
        //        var selectedMiscellaneousHS = new HashSet<int>();
        //        foreach (var miscellaneous in input.Miscellaneous)
        //        {
        //            var selectedMiscellaneous = _miscellaneousRepository.GetAll()
        //                .Where(p => p.Name == miscellaneous.Name)
        //                .FirstOrDefault();
        //            selectedMiscellaneousHS.Add(selectedMiscellaneous.Id);
        //        }

        //        var dbCourseEnrollments = _courseRepository.GetAll();
        //        var dbCourses = new HashSet<int>(booking.EnrollmentCourses.Select(c => c.CourseId));
        //        EnrollmentCourse courseEnrollment;

        //        foreach (var course in dbCourseEnrollments)
        //        {

        //            if (selectedMiscellaneousHS.Contains(course.Id))
        //            {
        //                if (!dbCourses.Contains(course.Id))
        //                {
        //                    courseEnrollment = new EnrollmentCourse(booking.Id, course.Id) { };
        //                    booking.EnrollmentCourses.Add(courseEnrollment);
        //                    //await _courseEnrollmentRepository.InsertAsync(courseEnrollment);
        //                }
        //            }
        //            else
        //            {
        //                if (dbCourses.Contains(course.Id))
        //                {
        //                    courseEnrollment = booking.EnrollmentCourses.Where(x => x.CourseId == course.Id).Single();
        //                    booking.EnrollmentCourses.Remove(courseEnrollment);
        //                    //await _courseEnrollmentRepository.DeleteAsync(courseEnrollment);
        //                }
        //            }
        //        }
        //    }

        //    if (input.Subjects != null)
        //    {
        //        var selectedSubjectsHS = new HashSet<int>();
        //        foreach (var subject in input.Subjects)
        //        {
        //            var selectedSubject = _subjectRepository.GetAll()
        //                .Where(p => p.Code == subject)
        //                .FirstOrDefault();
        //            selectedSubjectsHS.Add(selectedSubject.Id);
        //        }

        //        var dbSubjectEnrollments = _subjectRepository.GetAll();
        //        var dbSubjects = new HashSet<int>(booking.EnrollmentSubjects.Select(c => c.SubjectId));
        //        EnrollmentSubject enrollmentSubject;

        //        foreach (var subject in dbSubjectEnrollments)
        //        {

        //            if (selectedSubjectsHS.Contains(subject.Id))
        //            {
        //                if (!dbSubjects.Contains(subject.Id))
        //                {
        //                    enrollmentSubject = new EnrollmentSubject(booking.Id, subject.Id) { };
        //                    booking.EnrollmentSubjects.Add(enrollmentSubject);
        //                    //await _enrollmentsubjectRepository.InsertAsync(enrollmentSubject);
        //                }
        //            }
        //            else
        //            {
        //                if (dbSubjects.Contains(subject.Id))
        //                {
        //                    enrollmentSubject = booking.EnrollmentSubjects.Where(x => x.SubjectId == subject.Id).Single();
        //                    booking.EnrollmentSubjects.Remove(enrollmentSubject);
        //                    //await _enrollmentsubjectRepository.DeleteAsync(enrollmentSubject);
        //                }
        //            }
        //        }
        //    }
        //    CurrentUnitOfWork.SaveChanges();

        //    return await GetAsync(input);
        //}

        public int MyProperty { get; set; }

        public async Task<ListResultDto<ClientDto>> GetClients()
        {
            var clients = await _clientRepository.GetAllListAsync();
            return new ListResultDto<ClientDto>(ObjectMapper.Map<List<ClientDto>>(clients));
        }

        public async Task<ListResultDto<FacilityDto>> GetFacilities()
        {
            var facilites = await _facilityRepository.GetAllListAsync();
            return new ListResultDto<FacilityDto>(ObjectMapper.Map<List<FacilityDto>>(facilites));
        }

        public async Task<ListResultDto<MiscellaneousDto>> GetMiscellaneous()
        {
            var miscellaneous = await _miscellaneousRepository.GetAllListAsync();
            return new ListResultDto<MiscellaneousDto>(ObjectMapper.Map<List<MiscellaneousDto>>(miscellaneous));
        }
    }
}

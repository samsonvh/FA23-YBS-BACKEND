using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YBS.Data.Context;
using YBS.Data.Models;
using YBS.Data.Repositories;
using YBS.Data.Repositories.Implements;

namespace YBS.Data.UnitOfWorks.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly YBSContext _context;
        private readonly IGenericRepositoty<Account> _accountRepository;
        private readonly IGenericRepositoty<Member> _memberRepository;
        private readonly IGenericRepositoty<Company> _companyRepository;
        private readonly IGenericRepositoty<MembershipPackage> _membershipPackageRepository;
        private readonly IGenericRepositoty<Role> _roleRepository;
        private readonly IGenericRepositoty<RefreshToken> _refreshTokenRepository;
        private readonly IGenericRepositoty<Yacht> _yachtRepository;
        private readonly IGenericRepositoty<YachtType> _yachtTypeRepository;
        private readonly IGenericRepositoty<Route> _routeRepository;
        private readonly IGenericRepositoty<Booking> _bookingRepository;
        private readonly IGenericRepositoty<Trip> _tripRepository;
        private readonly IGenericRepositoty<PriceMapper> _priceMapperRepository;
        private readonly IGenericRepositoty<Guest> _guestRepository;
        private readonly IGenericRepositoty<ServicePackage> _servicePackageRepository;
        private readonly IGenericRepositoty<Payment> _paymentRepository;
        private readonly IGenericRepositoty<Transaction> _transactionRepository;

        public UnitOfWork(YBSContext context)
        {
            _context = context;
        }
        public IGenericRepositoty<Account> AccountRepository
        {
            get
            {
                if (_accountRepository is not null)
                {
                    return _accountRepository;
                }
                return new GenericRepository<Account>(_context);
            }
        }
        public IGenericRepositoty<Member> MemberRepository
        {
            get
            {
                if (_memberRepository is not null)
                {
                    return _memberRepository;
                }
                return new GenericRepository<Member>(_context);
            }
        }

        public IGenericRepositoty<Company> CompanyRepository
        {
            get
            {
                if (_companyRepository is not null)
                {
                    return _companyRepository;
                }
                return new GenericRepository<Company>(_context);
            }
        }

        public IGenericRepositoty<MembershipPackage> MembershipPackageRepository
        {
            get
            {
                if (_membershipPackageRepository is not null)
                {
                    return _membershipPackageRepository;
                }
                return new GenericRepository<MembershipPackage>(_context);
            }
        }
        public IGenericRepositoty<Role> RoleRepository
        {
            get
            {
                if (_roleRepository is not null)
                {
                    return _roleRepository;
                }
                return new GenericRepository<Role>(_context);
            }
        }

        public IGenericRepositoty<RefreshToken> RefreshTokenRepository 
        {
            get
            {
                if (_refreshTokenRepository is not null)
                {
                    return _refreshTokenRepository;
                }
                return new GenericRepository<RefreshToken>(_context);
            }
        }

        public IGenericRepositoty<Yacht> YachRepository
        {
            get
            {
                if (_yachtRepository is not null)
                {
                    return _yachtRepository;
                }
                return new GenericRepository<Yacht>(_context);
            }
        }

        public IGenericRepositoty<YachtType> YachTypeRepository
        {
            get
            {
                if (_yachtTypeRepository is not null)
                {
                    return _yachtTypeRepository;
                }
                return new GenericRepository<YachtType>(_context);
            }
        }

        public IGenericRepositoty<Route> RouteRepository
        {
            get
            {
                if (_routeRepository is not null)
                {
                    return _routeRepository;
                }
                return new GenericRepository<Route>(_context);
            }
        }

        public IGenericRepositoty<Booking> BookingRepository
        {
            get
            {
                if (_bookingRepository is not null)
                {
                    return _bookingRepository;
                }
                return new GenericRepository<Booking>(_context);
            }
        }

        public IGenericRepositoty<Trip> TripRepository
        {
            get
            {
                if (_tripRepository is not null)
                {
                    return _tripRepository;
                }
                return new GenericRepository<Trip>(_context);
            }
        }

        public IGenericRepositoty<PriceMapper> PriceMapperRepository
        {
            get
            {
                if (_priceMapperRepository is not null)
                {
                    return _priceMapperRepository;
                }
                return new GenericRepository<PriceMapper>(_context);
            }
        }

        public IGenericRepositoty<Guest> GuestRepository
        {
            get
            {
                if (_guestRepository is not null)
                {
                    return _guestRepository;
                }
                return new GenericRepository<Guest>(_context);
            }
        }

        public IGenericRepositoty<ServicePackage> ServicePackageRepository
        {
            get
            {
                if (_servicePackageRepository is not null)
                {
                    return _servicePackageRepository;
                }
                return new GenericRepository<ServicePackage>(_context);
            }
        }

        public IGenericRepositoty<Payment> PaymentRepository
        {
            get
            {
                if (_paymentRepository is not null)
                {
                    return _paymentRepository;
                }
                return new GenericRepository<Payment>(_context);
            }
        }

        public IGenericRepositoty<Transaction> TransactionRepository
        {
            get
            {
                if (_transactionRepository is not null)
                {
                    return _transactionRepository;
                }
                return new GenericRepository<Transaction>(_context);
            }
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
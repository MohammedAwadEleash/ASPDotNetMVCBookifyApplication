﻿using Bookify.Application.Comman.Repositories;

namespace Bookify.Application.Comman.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepository<Area> Areas { get; }
        IBaseRepository<Author> Authors { get; }
        IBookRepository Books { get; }
        IBaseRepository<BookCategory> BookCategories { get; }
        IBaseRepository<BookCopy> BookCopies { get; }

        IBaseRepository<Category> Categories { get; }
        IBaseRepository<Governorate> Governorates { get; }
        IBaseRepository<Rental> Rentals { get; }
        IBaseRepository<RentalCopy> RentalCopies { get; }
        IBaseRepository<Subscriber> Subscribers { get; }
        IBaseRepository<Subscription> Subscriptions { get; }



        int Complete();

    }
}

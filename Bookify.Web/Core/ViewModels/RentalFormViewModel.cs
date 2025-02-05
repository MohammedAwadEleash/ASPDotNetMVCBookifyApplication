﻿namespace Bookify.Web.Core.ViewModels
{
    public class RentalFormViewModel
    {

        public int? Id { get; set; }



        public string SubscriberKey { get; set; } = null!;

        public IList<int> SelectedCopies { get; set; } = new List<int>();




        public int? MaxAllowedCopies { get; set; }



        public IEnumerable<BookCopyViewModel> CurrentCopies { get; set; } = new List<BookCopyViewModel>();



    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewContosoUniversity.Models.CustomerSupport
{
    public class ViewModelSearchCustomer
    {
        private string _firstName;
        private string _lastName;

        private IEnumerable<ViewModelSearchCustomerResults> _searchResults;
        private IEnumerable<ViewModelSearchCustomerResults> _recentlyViewed;
        public ViewModelSearchCustomer(string FirstName, string LastName)
        {
            _firstName = FirstName;
            _lastName = LastName;
        }
        public ViewModelSearchCustomer()
        {

        }
        [DataType(DataType.Text)]
        [Required, MaxLength(45)]
        [Display(Name = "First Name")]
        public string FirstName
        {
            get
            {

                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        [DataType(DataType.Text)]
        [Required, MaxLength(45)]
        [Display(Name = "Last Name")]
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        public IEnumerable<ViewModelSearchCustomerResults> SearchResults
        {
            get
            {
                return _searchResults;
            }
            set
            {
                _searchResults = value;
            }
        }
        public IEnumerable<ViewModelSearchCustomerResults> RecentlyViewed
        {
            get
            {
                return _recentlyViewed;
            }
            set
            {
                _recentlyViewed = value;
            }
        }
    }
}

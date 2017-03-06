using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewContosoUniversity.Models.CustomerSupport
{
    public class ViewModelSearchCustomerResults
    {
        private string _firstName;
        private string _lastName;
        private DateTime _lastinteractiondate;
        private string _communicationchannel;
        private string _relationship;
        private string _contactperson;

        [DataType(DataType.Text)]
        [Required, MaxLength(10)]
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
        [Required, MaxLength(10)]
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
        [DataType(DataType.DateTime)]
        [Required]
        [Display(Name = "Last Interaction Date")]
        public DateTime LastInteractionDate
        {
            get
            {
                return _lastinteractiondate;
            }
            set
            {
                _lastinteractiondate = value;
            }
        }
        [DataType(DataType.Text)]
        [Required, MaxLength(10)]
        [Display(Name = "By Phone or email or person")]
        public string CommunicationChannel
        {
            get
            {
                return _communicationchannel;
            }
            set
            {
                _communicationchannel = value;
            }
        }

        [DataType(DataType.Text)]
        [Required, MaxLength(150)]
        [Display(Name = "Interacted With Person")]
        public string ContactPerson
        {
            get
            {
                return _contactperson;
            }
            set
            {
                _contactperson = value;
            }
        }
        [DataType(DataType.Text)]
        [Required, MaxLength(10)]
        [Display(Name = "RelationShip")]
        public string RelationShip
        {
            get
            {
                return _relationship;
            }
            set
            {
                _relationship = value;
            }
        }
    }
}
